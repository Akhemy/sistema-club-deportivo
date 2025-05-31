using System;
using System.Drawing;
using System.Windows.Forms;
using ClubDeportivoSystem.Models;
using ClubDeportivoSystem.Data;

namespace ClubDeportivoSystem.Forms
{
    public class FormPagos : Form
    {
        private Label lblTitulo;
        private GroupBox gbDatosPago;
        private Label lblSocio;
        private TextBox txtBuscarSocio;
        private Button btnBuscar;
        private Label lblDatosSocio;
        private Label lblNombreSocio;
        private Label lblNumeroSocio;
        private Label lblEstadoCuota;
        private Label lblTipoPersona;  // Nueva label para mostrar tipo de persona
        private Label lblTipo;
        private RadioButton rbMensual;
        private RadioButton rbDiaria;
        private Label lblMonto;
        private TextBox txtMonto;
        private Button btnPagar;
        private Button btnCerrar;

        private PersonaDAO personaDAO;
        private SocioDAO socioDAO;
        private Persona personaEncontrada;  // Cambié el nombre para ser más genérico
        private Socio datosDelSocio;

        public FormPagos()
        {
            personaDAO = new PersonaDAO();
            socioDAO = new SocioDAO();
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            // Configurar formulario
            this.Text = "Cobro de Cuota";
            this.Size = new Size(600, 520);  // Aumenté la altura para el nuevo campo
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.BackColor = Color.LightGray;

            // Título
            lblTitulo = new Label();
            lblTitulo.Text = "Cobro de Cuota";
            lblTitulo.Font = new Font("Arial", 16, FontStyle.Bold);
            lblTitulo.ForeColor = Color.DarkBlue;
            lblTitulo.Location = new Point(200, 20);
            lblTitulo.Size = new Size(200, 30);
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;

            // GroupBox Datos del Pago
            gbDatosPago = new GroupBox();
            gbDatosPago.Text = "Datos del Pago";
            gbDatosPago.Location = new Point(50, 70);
            gbDatosPago.Size = new Size(500, 370);  // Aumenté la altura
            gbDatosPago.BackColor = Color.White;
            gbDatosPago.Font = new Font("Arial", 10, FontStyle.Bold);

            // Label Socio
            lblSocio = new Label();
            lblSocio.Text = "Buscar Persona (DNI o Nombre):";  // Cambié el texto
            lblSocio.Location = new Point(20, 30);
            lblSocio.Size = new Size(200, 20);
            lblSocio.Font = new Font("Arial", 9);

            // TextBox Buscar Socio
            txtBuscarSocio = new TextBox();
            txtBuscarSocio.Location = new Point(20, 50);
            txtBuscarSocio.Size = new Size(300, 25);
            txtBuscarSocio.Font = new Font("Arial", 9);

            // Botón Buscar
            btnBuscar = new Button();
            btnBuscar.Text = "Buscar";
            btnBuscar.Location = new Point(330, 48);
            btnBuscar.Size = new Size(80, 30);
            btnBuscar.BackColor = Color.DodgerBlue;
            btnBuscar.ForeColor = Color.White;
            btnBuscar.FlatStyle = FlatStyle.Flat;
            btnBuscar.Click += new EventHandler(btnBuscar_Click);

            // Label Datos del Socio
            lblDatosSocio = new Label();
            lblDatosSocio.Text = "Datos de la Persona:";  // Cambié el texto
            lblDatosSocio.Location = new Point(20, 90);
            lblDatosSocio.Size = new Size(150, 20);
            lblDatosSocio.Font = new Font("Arial", 9, FontStyle.Bold);

            // Labels para mostrar datos del socio
            lblNombreSocio = new Label();
            lblNombreSocio.Text = "Nombre: -";
            lblNombreSocio.Location = new Point(20, 115);
            lblNombreSocio.Size = new Size(300, 20);
            lblNombreSocio.Font = new Font("Arial", 9);

            lblNumeroSocio = new Label();
            lblNumeroSocio.Text = "Nº Socio: -";
            lblNumeroSocio.Location = new Point(330, 115);
            lblNumeroSocio.Size = new Size(100, 20);
            lblNumeroSocio.Font = new Font("Arial", 9);

            // Nueva label para tipo de persona
            lblTipoPersona = new Label();
            lblTipoPersona.Text = "Tipo: -";
            lblTipoPersona.Location = new Point(20, 140);
            lblTipoPersona.Size = new Size(150, 20);
            lblTipoPersona.Font = new Font("Arial", 9, FontStyle.Bold);

            lblEstadoCuota = new Label();
            lblEstadoCuota.Text = "Estado Cuota: -";
            lblEstadoCuota.Location = new Point(180, 140);
            lblEstadoCuota.Size = new Size(200, 20);
            lblEstadoCuota.Font = new Font("Arial", 9);

            // Label Tipo
            lblTipo = new Label();
            lblTipo.Text = "Tipo de Cuota:";
            lblTipo.Location = new Point(20, 180);
            lblTipo.Size = new Size(100, 20);
            lblTipo.Font = new Font("Arial", 9);

            // RadioButton Mensual
            rbMensual = new RadioButton();
            rbMensual.Text = "Mensual";
            rbMensual.Location = new Point(130, 178);
            rbMensual.Size = new Size(80, 25);
            rbMensual.Font = new Font("Arial", 9);
            rbMensual.Checked = true;
            rbMensual.CheckedChanged += new EventHandler(rbTipoCuota_CheckedChanged);

            // RadioButton Diaria
            rbDiaria = new RadioButton();
            rbDiaria.Text = "Diaria";
            rbDiaria.Location = new Point(220, 178);
            rbDiaria.Size = new Size(80, 25);
            rbDiaria.Font = new Font("Arial", 9);
            rbDiaria.CheckedChanged += new EventHandler(rbTipoCuota_CheckedChanged);

            // Label Monto
            lblMonto = new Label();
            lblMonto.Text = "Monto:";
            lblMonto.Location = new Point(20, 220);
            lblMonto.Size = new Size(50, 20);
            lblMonto.Font = new Font("Arial", 9);

            // TextBox Monto
            txtMonto = new TextBox();
            txtMonto.Location = new Point(80, 218);
            txtMonto.Size = new Size(150, 25);
            txtMonto.Font = new Font("Arial", 9);
            txtMonto.ReadOnly = true;
            txtMonto.BackColor = Color.LightYellow;

            // Botón Pagar
            btnPagar = new Button();
            btnPagar.Text = "Pagar";
            btnPagar.Location = new Point(50, 300);  // Ajusté la posición
            btnPagar.Size = new Size(100, 35);
            btnPagar.BackColor = Color.Green;
            btnPagar.ForeColor = Color.White;
            btnPagar.FlatStyle = FlatStyle.Flat;
            btnPagar.Font = new Font("Arial", 10, FontStyle.Bold);
            btnPagar.Enabled = false;
            btnPagar.Click += new EventHandler(btnPagar_Click);

            // Botón Cerrar
            btnCerrar = new Button();
            btnCerrar.Text = "Cerrar";
            btnCerrar.Location = new Point(350, 300);  // Ajusté la posición
            btnCerrar.Size = new Size(100, 35);
            btnCerrar.BackColor = Color.Crimson;
            btnCerrar.ForeColor = Color.White;
            btnCerrar.FlatStyle = FlatStyle.Flat;
            btnCerrar.Font = new Font("Arial", 10, FontStyle.Bold);
            btnCerrar.Click += new EventHandler(btnCerrar_Click);

            // Agregar controles al GroupBox
            gbDatosPago.Controls.Add(lblSocio);
            gbDatosPago.Controls.Add(txtBuscarSocio);
            gbDatosPago.Controls.Add(btnBuscar);
            gbDatosPago.Controls.Add(lblDatosSocio);
            gbDatosPago.Controls.Add(lblNombreSocio);
            gbDatosPago.Controls.Add(lblNumeroSocio);
            gbDatosPago.Controls.Add(lblTipoPersona);  // Nueva label
            gbDatosPago.Controls.Add(lblEstadoCuota);
            gbDatosPago.Controls.Add(lblTipo);
            gbDatosPago.Controls.Add(rbMensual);
            gbDatosPago.Controls.Add(rbDiaria);
            gbDatosPago.Controls.Add(lblMonto);
            gbDatosPago.Controls.Add(txtMonto);
            gbDatosPago.Controls.Add(btnPagar);
            gbDatosPago.Controls.Add(btnCerrar);

            // Agregar controles al formulario
            this.Controls.Add(lblTitulo);
            this.Controls.Add(gbDatosPago);

            // Calcular monto inicial
            CalcularMonto();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                string busqueda = txtBuscarSocio.Text.Trim();

                if (string.IsNullOrEmpty(busqueda))
                {
                    MessageBox.Show("Ingrese un DNI o nombre para buscar.", "Validación",
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Buscar por DNI primero
                personaEncontrada = personaDAO.ObtenerPersonaPorDNI(busqueda);

                // Si no encuentra por DNI, buscar por nombre
                if (personaEncontrada == null)
                {
                    MessageBox.Show("No se encontró ninguna persona con ese DNI.", "No encontrado",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarDatosPersona();
                    return;
                }

                // Manejar tanto socios como no socios
                if (personaEncontrada.TipoPersona == "socio")
                {
                    // Obtener datos del socio
                    datosDelSocio = socioDAO.ObtenerSocioPorPersonaId(personaEncontrada.Id);

                    if (datosDelSocio != null)
                    {
                        MostrarDatosSocio();
                        btnPagar.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("Error al obtener datos del socio.", "Error",
                                      MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (personaEncontrada.TipoPersona == "no_socio")
                {
                    // Para no socios, solo permitir cuota diaria
                    MostrarDatosNoSocio();
                    btnPagar.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Persona no encontrada, datos no válidos.", "Tipo no válido",
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    LimpiarDatosPersona();
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al buscar persona: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MostrarDatosSocio()
        {
            lblNombreSocio.Text = $"Nombre: {personaEncontrada.NombreCompleto}";
            lblNumeroSocio.Text = $"Nº Socio: {datosDelSocio.NumeroSocio}";
            lblTipoPersona.Text = "Tipo: SOCIO";
            lblTipoPersona.ForeColor = Color.Blue;
            lblEstadoCuota.Text = $"Estado Cuota: {datosDelSocio.EstadoCuota.ToUpper()}";

            // Cambiar color según estado
            switch (datosDelSocio.EstadoCuota.ToLower())
            {
                case "al_dia":
                    lblEstadoCuota.ForeColor = Color.Green;
                    break;
                case "vencida":
                    lblEstadoCuota.ForeColor = Color.Red;
                    break;
                default:
                    lblEstadoCuota.ForeColor = Color.Orange;
                    break;
            }

            // Los socios pueden pagar cuota mensual o diaria?
            rbMensual.Enabled = true;
            rbDiaria.Enabled = false;
        }

        private void MostrarDatosNoSocio()
        {
            lblNombreSocio.Text = $"Nombre: {personaEncontrada.NombreCompleto}";
            lblNumeroSocio.Text = "Nº Socio: No aplica";
            lblTipoPersona.Text = "Tipo: NO SOCIO";
            lblTipoPersona.ForeColor = Color.Purple;
            lblEstadoCuota.Text = "Estado Cuota: Pago por día";
            lblEstadoCuota.ForeColor = Color.Gray;

            // Los no socios solo pueden pagar cuota diaria
            rbMensual.Enabled = false;
            rbDiaria.Enabled = true;
            rbDiaria.Checked = true;  // Forzar selección de cuota diaria

            CalcularMonto();  // Recalcular monto para cuota diaria
        }

        private void LimpiarDatosPersona()
        {
            lblNombreSocio.Text = "Nombre: -";
            lblNumeroSocio.Text = "Nº Socio: -";
            lblTipoPersona.Text = "Tipo: -";
            lblTipoPersona.ForeColor = Color.Black;
            lblEstadoCuota.Text = "Estado Cuota: -";
            lblEstadoCuota.ForeColor = Color.Black;
            btnPagar.Enabled = false;
            personaEncontrada = null;
            datosDelSocio = null;

            // Restaurar opciones de radio buttons
            rbMensual.Enabled = true;
            rbDiaria.Enabled = true;
            rbMensual.Checked = true;
        }

        private void rbTipoCuota_CheckedChanged(object sender, EventArgs e)
        {
            CalcularMonto();
        }

        private void CalcularMonto()
        {
            if (rbMensual.Checked)
            {
                txtMonto.Text = "$ 15000.00";
            }
            else
            {
                txtMonto.Text = "$ 2000.00";
            }
        }

        private void btnPagar_Click(object sender, EventArgs e)
        {
            try
            {
                if (personaEncontrada == null)
                {
                    MessageBox.Show("Debe buscar y seleccionar una persona primero.", "Validación",
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string tipoCuota = rbMensual.Checked ? "mensual" : "diaria";
                decimal monto = rbMensual.Checked ? 15000.00m : 2000.00m;

                // Validar que no socios solo puedan pagar cuota diaria
                if (personaEncontrada.TipoPersona == "noSocio" && rbMensual.Checked)
                {
                    MessageBox.Show("Los no socios solo pueden pagar cuota diaria.", "Restricción",
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Confirmar pago
                string tipoPersonaTexto = personaEncontrada.TipoPersona == "socio" ?
                    $"Nº Socio: {datosDelSocio.NumeroSocio}" : "Tipo: No Socio";

                string mensaje = $"¿Confirma el pago?\n\n" +
                                $"Persona: {personaEncontrada.NombreCompleto}\n" +
                                $"{tipoPersonaTexto}\n" +
                                $"Tipo: Cuota {tipoCuota}\n" +
                                $"Monto: $ {monto:F2}";

                if (MessageBox.Show(mensaje, "Confirmar Pago", MessageBoxButtons.YesNo,
                                  MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    // Registrar pago en la base de datos
                    CuotaDAO cuotaDAO = new CuotaDAO();
                    bool pagoExitoso = false;

                    if (personaEncontrada.TipoPersona == "socio")
                    {
                        // Registrar pago para socio
                        pagoExitoso = cuotaDAO.RegistrarPago(datosDelSocio.Id, monto, tipoCuota, "Efectivo");
                    }
                    else
                    {
                        // Registrar pago para no socio (necesitarás implementar este método)
                        pagoExitoso = cuotaDAO.RegistrarPagoNoSocio(personaEncontrada.Id, monto, "Efectivo");
                    }

                    if (pagoExitoso)
                    {
                        string mensajeExito = $"¡Pago registrado exitosamente!\n\n" +
                                             $"Persona: {personaEncontrada.NombreCompleto}\n" +
                                             $"{tipoPersonaTexto}\n" +
                                             $"Tipo: Cuota {tipoCuota}\n" +
                                             $"Monto: $ {monto:F2}\n" +
                                             $"Fecha: {DateTime.Now:dd/MM/yyyy HH:mm}";

                        if (personaEncontrada.TipoPersona == "socio")
                        {
                            mensajeExito += $"\nEstado del socio: AL DÍA";
                        }

                        MessageBox.Show(mensajeExito, "¡Pago Exitoso!",
                                      MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Actualizar datos del socio en pantalla si es socio
                        if (personaEncontrada.TipoPersona == "socio" && datosDelSocio != null)
                        {
                            datosDelSocio.EstadoCuota = "al_dia";
                            MostrarDatosSocio();
                        }

                        // Limpiar formulario para siguiente pago
                        txtBuscarSocio.Clear();
                        LimpiarDatosPersona();
                        rbMensual.Checked = true;
                    }
                    else
                    {
                        MessageBox.Show("Error al registrar el pago en la base de datos.",
                                      "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inesperado al procesar el pago: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}