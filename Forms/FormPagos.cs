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
        private Persona socioEncontrado;
        private GroupBox gbTipoPago;
        private RadioButton rbTarjeta;
        private RadioButton rbEfectivo;
        private Socio datosDelSocio;

        public FormPagos()
        {
            personaDAO = new PersonaDAO();
            socioDAO = new SocioDAO();
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.lblTitulo = new System.Windows.Forms.Label();
            this.gbDatosPago = new System.Windows.Forms.GroupBox();
            this.lblSocio = new System.Windows.Forms.Label();
            this.txtBuscarSocio = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.lblDatosSocio = new System.Windows.Forms.Label();
            this.lblNombreSocio = new System.Windows.Forms.Label();
            this.lblNumeroSocio = new System.Windows.Forms.Label();
            this.lblEstadoCuota = new System.Windows.Forms.Label();
            this.lblTipo = new System.Windows.Forms.Label();
            this.rbMensual = new System.Windows.Forms.RadioButton();
            this.rbDiaria = new System.Windows.Forms.RadioButton();
            this.lblMonto = new System.Windows.Forms.Label();
            this.txtMonto = new System.Windows.Forms.TextBox();
            this.btnPagar = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.gbTipoPago = new System.Windows.Forms.GroupBox();
            this.rbEfectivo = new System.Windows.Forms.RadioButton();
            this.rbTarjeta = new System.Windows.Forms.RadioButton();
            this.gbDatosPago.SuspendLayout();
            this.gbTipoPago.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblTitulo.Location = new System.Drawing.Point(200, 20);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(200, 30);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Cobro de Cuota";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gbDatosPago
            // 
            this.gbDatosPago.BackColor = System.Drawing.Color.White;
            this.gbDatosPago.Controls.Add(this.gbTipoPago);
            this.gbDatosPago.Controls.Add(this.lblSocio);
            this.gbDatosPago.Controls.Add(this.txtBuscarSocio);
            this.gbDatosPago.Controls.Add(this.btnBuscar);
            this.gbDatosPago.Controls.Add(this.lblDatosSocio);
            this.gbDatosPago.Controls.Add(this.lblNombreSocio);
            this.gbDatosPago.Controls.Add(this.lblNumeroSocio);
            this.gbDatosPago.Controls.Add(this.lblEstadoCuota);
            this.gbDatosPago.Controls.Add(this.lblTipo);
            this.gbDatosPago.Controls.Add(this.rbMensual);
            this.gbDatosPago.Controls.Add(this.rbDiaria);
            this.gbDatosPago.Controls.Add(this.lblMonto);
            this.gbDatosPago.Controls.Add(this.txtMonto);
            this.gbDatosPago.Controls.Add(this.btnPagar);
            this.gbDatosPago.Controls.Add(this.btnCerrar);
            this.gbDatosPago.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.gbDatosPago.Location = new System.Drawing.Point(50, 70);
            this.gbDatosPago.Name = "gbDatosPago";
            this.gbDatosPago.Size = new System.Drawing.Size(500, 393);
            this.gbDatosPago.TabIndex = 1;
            this.gbDatosPago.TabStop = false;
            this.gbDatosPago.Text = "Datos del Pago";
            // 
            // lblSocio
            // 
            this.lblSocio.Font = new System.Drawing.Font("Arial", 9F);
            this.lblSocio.Location = new System.Drawing.Point(20, 30);
            this.lblSocio.Name = "lblSocio";
            this.lblSocio.Size = new System.Drawing.Size(180, 20);
            this.lblSocio.TabIndex = 0;
            this.lblSocio.Text = "Buscar Socio (DNI o Nombre):";
            // 
            // txtBuscarSocio
            // 
            this.txtBuscarSocio.Font = new System.Drawing.Font("Arial", 9F);
            this.txtBuscarSocio.Location = new System.Drawing.Point(20, 50);
            this.txtBuscarSocio.Name = "txtBuscarSocio";
            this.txtBuscarSocio.Size = new System.Drawing.Size(300, 21);
            this.txtBuscarSocio.TabIndex = 1;
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.ForeColor = System.Drawing.Color.White;
            this.btnBuscar.Location = new System.Drawing.Point(330, 48);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(80, 30);
            this.btnBuscar.TabIndex = 2;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // lblDatosSocio
            // 
            this.lblDatosSocio.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.lblDatosSocio.Location = new System.Drawing.Point(20, 90);
            this.lblDatosSocio.Name = "lblDatosSocio";
            this.lblDatosSocio.Size = new System.Drawing.Size(120, 20);
            this.lblDatosSocio.TabIndex = 3;
            this.lblDatosSocio.Text = "Datos del Socio:";
            // 
            // lblNombreSocio
            // 
            this.lblNombreSocio.Font = new System.Drawing.Font("Arial", 9F);
            this.lblNombreSocio.Location = new System.Drawing.Point(20, 115);
            this.lblNombreSocio.Name = "lblNombreSocio";
            this.lblNombreSocio.Size = new System.Drawing.Size(300, 20);
            this.lblNombreSocio.TabIndex = 4;
            this.lblNombreSocio.Text = "Nombre: -";
            // 
            // lblNumeroSocio
            // 
            this.lblNumeroSocio.Font = new System.Drawing.Font("Arial", 9F);
            this.lblNumeroSocio.Location = new System.Drawing.Point(330, 115);
            this.lblNumeroSocio.Name = "lblNumeroSocio";
            this.lblNumeroSocio.Size = new System.Drawing.Size(100, 20);
            this.lblNumeroSocio.TabIndex = 5;
            this.lblNumeroSocio.Text = "Nº Socio: -";
            // 
            // lblEstadoCuota
            // 
            this.lblEstadoCuota.Font = new System.Drawing.Font("Arial", 9F);
            this.lblEstadoCuota.Location = new System.Drawing.Point(20, 140);
            this.lblEstadoCuota.Name = "lblEstadoCuota";
            this.lblEstadoCuota.Size = new System.Drawing.Size(200, 20);
            this.lblEstadoCuota.TabIndex = 6;
            this.lblEstadoCuota.Text = "Estado Cuota: -";
            // 
            // lblTipo
            // 
            this.lblTipo.Font = new System.Drawing.Font("Arial", 9F);
            this.lblTipo.Location = new System.Drawing.Point(20, 180);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(100, 20);
            this.lblTipo.TabIndex = 7;
            this.lblTipo.Text = "Tipo de Cuota:";
            // 
            // rbMensual
            // 
            this.rbMensual.Checked = true;
            this.rbMensual.Font = new System.Drawing.Font("Arial", 9F);
            this.rbMensual.Location = new System.Drawing.Point(130, 178);
            this.rbMensual.Name = "rbMensual";
            this.rbMensual.Size = new System.Drawing.Size(80, 25);
            this.rbMensual.TabIndex = 8;
            this.rbMensual.TabStop = true;
            this.rbMensual.Text = "Mensual";
            this.rbMensual.CheckedChanged += new System.EventHandler(this.rbTipoCuota_CheckedChanged);
            // 
            // rbDiaria
            // 
            this.rbDiaria.Font = new System.Drawing.Font("Arial", 9F);
            this.rbDiaria.Location = new System.Drawing.Point(220, 178);
            this.rbDiaria.Name = "rbDiaria";
            this.rbDiaria.Size = new System.Drawing.Size(80, 25);
            this.rbDiaria.TabIndex = 9;
            this.rbDiaria.Text = "Diaria";
            this.rbDiaria.CheckedChanged += new System.EventHandler(this.rbTipoCuota_CheckedChanged);
            // 
            // lblMonto
            // 
            this.lblMonto.Font = new System.Drawing.Font("Arial", 9F);
            this.lblMonto.Location = new System.Drawing.Point(20, 220);
            this.lblMonto.Name = "lblMonto";
            this.lblMonto.Size = new System.Drawing.Size(50, 20);
            this.lblMonto.TabIndex = 10;
            this.lblMonto.Text = "Monto:";
            // 
            // txtMonto
            // 
            this.txtMonto.BackColor = System.Drawing.Color.LightYellow;
            this.txtMonto.Font = new System.Drawing.Font("Arial", 9F);
            this.txtMonto.Location = new System.Drawing.Point(80, 218);
            this.txtMonto.Name = "txtMonto";
            this.txtMonto.ReadOnly = true;
            this.txtMonto.Size = new System.Drawing.Size(150, 21);
            this.txtMonto.TabIndex = 11;
            // 
            // btnPagar
            // 
            this.btnPagar.BackColor = System.Drawing.Color.Green;
            this.btnPagar.Enabled = false;
            this.btnPagar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPagar.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.btnPagar.ForeColor = System.Drawing.Color.White;
            this.btnPagar.Location = new System.Drawing.Point(23, 334);
            this.btnPagar.Name = "btnPagar";
            this.btnPagar.Size = new System.Drawing.Size(100, 35);
            this.btnPagar.TabIndex = 12;
            this.btnPagar.Text = "Pagar";
            this.btnPagar.UseVisualStyleBackColor = false;
            this.btnPagar.Click += new System.EventHandler(this.btnPagar_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.BackColor = System.Drawing.Color.Crimson;
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.btnCerrar.ForeColor = System.Drawing.Color.White;
            this.btnCerrar.Location = new System.Drawing.Point(352, 334);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(100, 35);
            this.btnCerrar.TabIndex = 13;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // gbTipoPago
            // 
            this.gbTipoPago.Controls.Add(this.rbTarjeta);
            this.gbTipoPago.Controls.Add(this.rbEfectivo);
            this.gbTipoPago.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.gbTipoPago.Location = new System.Drawing.Point(23, 254);
            this.gbTipoPago.Name = "gbTipoPago";
            this.gbTipoPago.Size = new System.Drawing.Size(390, 64);
            this.gbTipoPago.TabIndex = 16;
            this.gbTipoPago.TabStop = false;
            this.gbTipoPago.Text = "Tipo de Pago";
            this.gbTipoPago.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // rbEfectivo
            // 
            this.rbEfectivo.AutoSize = true;
            this.rbEfectivo.Checked = true;
            this.rbEfectivo.Font = new System.Drawing.Font("Arial", 9F);
            this.rbEfectivo.Location = new System.Drawing.Point(91, 22);
            this.rbEfectivo.Name = "rbEfectivo";
            this.rbEfectivo.Size = new System.Drawing.Size(67, 19);
            this.rbEfectivo.TabIndex = 14;
            this.rbEfectivo.TabStop = true;
            this.rbEfectivo.Text = "Efectivo";
            this.rbEfectivo.UseVisualStyleBackColor = true;
            this.rbEfectivo.CheckedChanged += new System.EventHandler(this.rbEfectivo_CheckedChanged);
            // 
            // rbTarjeta
            // 
            this.rbTarjeta.AutoSize = true;
            this.rbTarjeta.Font = new System.Drawing.Font("Arial", 9F);
            this.rbTarjeta.Location = new System.Drawing.Point(271, 22);
            this.rbTarjeta.Name = "rbTarjeta";
            this.rbTarjeta.Size = new System.Drawing.Size(62, 19);
            this.rbTarjeta.TabIndex = 14;
            this.rbTarjeta.Text = "Tarjeta";
            this.rbTarjeta.UseVisualStyleBackColor = true;
            this.rbTarjeta.CheckedChanged += new System.EventHandler(this.rbTarjeta_CheckedChanged);
            // 
            // FormPagos
            // 
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(584, 501);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.gbDatosPago);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FormPagos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cobro de Cuota";
            this.gbDatosPago.ResumeLayout(false);
            this.gbDatosPago.PerformLayout();
            this.gbTipoPago.ResumeLayout(false);
            this.gbTipoPago.PerformLayout();
            this.ResumeLayout(false);

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

                if (!rbEfectivo.Checked && !rbTarjeta.Checked)
                {
                    MessageBox.Show("Seleccione un medio de pago (Efectivo o Tarjeta).", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string medioPago = rbEfectivo.Checked ? "Efectivo" : "Tarjeta";

                // Si es TARJETA => abrir formulario de datos de tarjeta
                if (rbTarjeta.Checked)
                {
                    using (var frmTarjeta = new FormPagoTarjeta(monto))
                    {
                        if (frmTarjeta.ShowDialog() != DialogResult.OK)
                        {
                            // Usuario canceló o datos inválidos.
                            return;
                        }
                    }
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

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void rbEfectivo_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rbTarjeta_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}