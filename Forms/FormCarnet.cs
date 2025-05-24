using System;
using System.Drawing;
using System.Windows.Forms;
using ClubDeportivoSystem.Models;
using ClubDeportivoSystem.Data;

namespace ClubDeportivoSystem.Forms
{
    public class FormCarnet : Form
    {
        private Label lblTitulo;
        private GroupBox gbBuscarSocio;
        private Label lblBuscar;
        private TextBox txtBuscarSocio;
        private Button btnBuscar;
        private GroupBox gbDatosSocio;
        private Label lblDatos;
        private Label lblNombre;
        private Label lblNumeroSocio;
        private Label lblDNI;
        private Label lblEstado;
        private GroupBox gbCarnet;
        private Panel pnlCarnet;
        private Label lblCarnetTitulo;
        private Label lblCarnetNombre;
        private Label lblCarnetNumero;
        private Label lblCarnetDNI;
        private Label lblCarnetEmision;
        private Label lblCarnetVencimiento;
        private Button btnGenerarCarnet;
        private Button btnImprimir;
        private Button btnCerrar;

        private PersonaDAO personaDAO;
        private SocioDAO socioDAO;
        private CarnetDAO carnetDAO;
        private Persona socioEncontrado;
        private Socio datosDelSocio;
        private Carnet carnetGenerado;

        public FormCarnet()
        {
            personaDAO = new PersonaDAO();
            socioDAO = new SocioDAO();
            carnetDAO = new CarnetDAO();
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            // Configurar formulario
            this.Text = "Club Deportivo - Generar Carnet";
            this.Size = new Size(800, 600);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.BackColor = Color.LightGray;

            // Título
            lblTitulo = new Label();
            lblTitulo.Text = "Club Deportivo - Generar Carnet";
            lblTitulo.Font = new Font("Arial", 16, FontStyle.Bold);
            lblTitulo.ForeColor = Color.DarkBlue;
            lblTitulo.Location = new Point(250, 20);
            lblTitulo.Size = new Size(300, 30);
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;

            // GroupBox Buscar Socio
            gbBuscarSocio = new GroupBox();
            gbBuscarSocio.Text = "Buscar Socio";
            gbBuscarSocio.Location = new Point(50, 70);
            gbBuscarSocio.Size = new Size(700, 80);
            gbBuscarSocio.BackColor = Color.White;

            lblBuscar = new Label();
            lblBuscar.Text = "Ingrese DNI o Número de Socio:";
            lblBuscar.Location = new Point(20, 25);
            lblBuscar.Size = new Size(180, 20);

            txtBuscarSocio = new TextBox();
            txtBuscarSocio.Location = new Point(210, 23);
            txtBuscarSocio.Size = new Size(200, 25);

            btnBuscar = new Button();
            btnBuscar.Text = "Buscar";
            btnBuscar.Location = new Point(420, 21);
            btnBuscar.Size = new Size(80, 30);
            btnBuscar.BackColor = Color.DodgerBlue;
            btnBuscar.ForeColor = Color.White;
            btnBuscar.FlatStyle = FlatStyle.Flat;
            btnBuscar.Click += new EventHandler(btnBuscar_Click);

            gbBuscarSocio.Controls.Add(lblBuscar);
            gbBuscarSocio.Controls.Add(txtBuscarSocio);
            gbBuscarSocio.Controls.Add(btnBuscar);

            // GroupBox Datos del Socio
            gbDatosSocio = new GroupBox();
            gbDatosSocio.Text = "Datos del Socio";
            gbDatosSocio.Location = new Point(50, 170);
            gbDatosSocio.Size = new Size(350, 150);
            gbDatosSocio.BackColor = Color.White;

            lblDatos = new Label();
            lblDatos.Text = "Seleccione un socio para ver sus datos";
            lblDatos.Location = new Point(20, 30);
            lblDatos.Size = new Size(300, 20);
            lblDatos.ForeColor = Color.Gray;

            lblNombre = new Label();
            lblNombre.Text = "Nombre: -";
            lblNombre.Location = new Point(20, 30);
            lblNombre.Size = new Size(300, 20);
            lblNombre.Visible = false;

            lblNumeroSocio = new Label();
            lblNumeroSocio.Text = "Nº Socio: -";
            lblNumeroSocio.Location = new Point(20, 55);
            lblNumeroSocio.Size = new Size(150, 20);
            lblNumeroSocio.Visible = false;

            lblDNI = new Label();
            lblDNI.Text = "DNI: -";
            lblDNI.Location = new Point(20, 80);
            lblDNI.Size = new Size(200, 20);
            lblDNI.Visible = false;

            lblEstado = new Label();
            lblEstado.Text = "Estado: -";
            lblEstado.Location = new Point(20, 105);
            lblEstado.Size = new Size(200, 20);
            lblEstado.Visible = false;

            gbDatosSocio.Controls.Add(lblDatos);
            gbDatosSocio.Controls.Add(lblNombre);
            gbDatosSocio.Controls.Add(lblNumeroSocio);
            gbDatosSocio.Controls.Add(lblDNI);
            gbDatosSocio.Controls.Add(lblEstado);

            // GroupBox Carnet
            gbCarnet = new GroupBox();
            gbCarnet.Text = "Carnet de Socio";
            gbCarnet.Location = new Point(420, 170);
            gbCarnet.Size = new Size(330, 280);
            gbCarnet.BackColor = Color.White;

            // Panel del Carnet (simula el carnet físico)
            pnlCarnet = new Panel();
            pnlCarnet.Location = new Point(20, 30);
            pnlCarnet.Size = new Size(290, 180);
            pnlCarnet.BackColor = Color.LightBlue;
            pnlCarnet.BorderStyle = BorderStyle.FixedSingle;

            lblCarnetTitulo = new Label();
            lblCarnetTitulo.Text = "CARNET DE SOCIO";
            lblCarnetTitulo.Font = new Font("Arial", 12, FontStyle.Bold);
            lblCarnetTitulo.ForeColor = Color.DarkBlue;
            lblCarnetTitulo.Location = new Point(10, 10);
            lblCarnetTitulo.Size = new Size(270, 25);
            lblCarnetTitulo.TextAlign = ContentAlignment.MiddleCenter;

            lblCarnetNombre = new Label();
            lblCarnetNombre.Text = "Nombre:";
            lblCarnetNombre.Location = new Point(15, 45);
            lblCarnetNombre.Size = new Size(260, 20);
            lblCarnetNombre.Font = new Font("Arial", 9, FontStyle.Bold);

            lblCarnetNumero = new Label();
            lblCarnetNumero.Text = "Nº Socio:";
            lblCarnetNumero.Location = new Point(15, 70);
            lblCarnetNumero.Size = new Size(260, 20);

            lblCarnetDNI = new Label();
            lblCarnetDNI.Text = "DNI:";
            lblCarnetDNI.Location = new Point(15, 95);
            lblCarnetDNI.Size = new Size(260, 20);

            lblCarnetEmision = new Label();
            lblCarnetEmision.Text = "Fecha Emisión:";
            lblCarnetEmision.Location = new Point(15, 120);
            lblCarnetEmision.Size = new Size(260, 20);
            lblCarnetEmision.Font = new Font("Arial", 8);

            lblCarnetVencimiento = new Label();
            lblCarnetVencimiento.Text = "Vencimiento:";
            lblCarnetVencimiento.Location = new Point(15, 140);
            lblCarnetVencimiento.Size = new Size(260, 20);
            lblCarnetVencimiento.Font = new Font("Arial", 8);

            pnlCarnet.Controls.Add(lblCarnetTitulo);
            pnlCarnet.Controls.Add(lblCarnetNombre);
            pnlCarnet.Controls.Add(lblCarnetNumero);
            pnlCarnet.Controls.Add(lblCarnetDNI);
            pnlCarnet.Controls.Add(lblCarnetEmision);
            pnlCarnet.Controls.Add(lblCarnetVencimiento);

            btnGenerarCarnet = new Button();
            btnGenerarCarnet.Text = "Generar Carnet";
            btnGenerarCarnet.Location = new Point(20, 220);
            btnGenerarCarnet.Size = new Size(120, 35);
            btnGenerarCarnet.BackColor = Color.Green;
            btnGenerarCarnet.ForeColor = Color.White;
            btnGenerarCarnet.FlatStyle = FlatStyle.Flat;
            btnGenerarCarnet.Enabled = false;
            btnGenerarCarnet.Click += new EventHandler(btnGenerarCarnet_Click);

            btnImprimir = new Button();
            btnImprimir.Text = "Imprimir";
            btnImprimir.Location = new Point(150, 220);
            btnImprimir.Size = new Size(80, 35);
            btnImprimir.BackColor = Color.Orange;
            btnImprimir.ForeColor = Color.White;
            btnImprimir.FlatStyle = FlatStyle.Flat;
            btnImprimir.Enabled = false;
            btnImprimir.Click += new EventHandler(btnImprimir_Click);

            gbCarnet.Controls.Add(pnlCarnet);
            gbCarnet.Controls.Add(btnGenerarCarnet);
            gbCarnet.Controls.Add(btnImprimir);

            // Botón Cerrar
            btnCerrar = new Button();
            btnCerrar.Text = "Cerrar";
            btnCerrar.Location = new Point(350, 500);
            btnCerrar.Size = new Size(100, 35);
            btnCerrar.BackColor = Color.Crimson;
            btnCerrar.ForeColor = Color.White;
            btnCerrar.FlatStyle = FlatStyle.Flat;
            btnCerrar.Click += new EventHandler(btnCerrar_Click);

            // Agregar controles al formulario
            this.Controls.Add(lblTitulo);
            this.Controls.Add(gbBuscarSocio);
            this.Controls.Add(gbDatosSocio);
            this.Controls.Add(gbCarnet);
            this.Controls.Add(btnCerrar);

           // LimpiarCarnet();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                string busqueda = txtBuscarSocio.Text.Trim();

                if (string.IsNullOrEmpty(busqueda))
                {
                    MessageBox.Show("Ingrese un DNI o número de socio para buscar.", "Validación",
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Buscar por DNI
                socioEncontrado = personaDAO.ObtenerPersonaPorDNI(busqueda);

                if (socioEncontrado == null)
                {
                    // Intentar buscar por número de socio
                    // (implementar método en SocioDAO si es necesario)
                    MessageBox.Show("No se encontró ningún socio con ese DNI.", "No encontrado",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarDatos();
                    return;
                }

                if (socioEncontrado.TipoPersona != "socio")
                {
                    MessageBox.Show("La persona encontrada no es un socio.", "No es socio",
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    LimpiarDatos();
                    return;
                }

                datosDelSocio = socioDAO.ObtenerSocioPorPersonaId(socioEncontrado.Id);

                if (datosDelSocio != null)
                {
                    MostrarDatosSocio();
                    btnGenerarCarnet.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al buscar socio: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MostrarDatosSocio()
        {
            lblDatos.Visible = false;

            lblNombre.Text = $"Nombre: {socioEncontrado.NombreCompleto}";
            lblNombre.Visible = true;

            lblNumeroSocio.Text = $"Nº Socio: {datosDelSocio.NumeroSocio}";
            lblNumeroSocio.Visible = true;

            lblDNI.Text = $"DNI: {socioEncontrado.DNI}";
            lblDNI.Visible = true;

            lblEstado.Text = $"Estado Cuota: {datosDelSocio.EstadoCuota.ToUpper()}";
            lblEstado.Visible = true;

            switch (datosDelSocio.EstadoCuota.ToLower())
            {
                case "al_dia":
                    lblEstado.ForeColor = Color.Green;
                    break;
                case "vencida":
                    lblEstado.ForeColor = Color.Red;
                    break;
                default:
                    lblEstado.ForeColor = Color.Orange;
                    break;
            }
        }

        private void LimpiarDatos()
        {
            lblDatos.Visible = true;
            lblNombre.Visible = false;
            lblNumeroSocio.Visible = false;
            lblDNI.Visible = false;
            lblEstado.Visible = false;
            btnGenerarCarnet.Enabled = false;
            socioEncontrado = null;
            datosDelSocio = null;
            LimpiarCarnet();
        }

        private void btnGenerarCarnet_Click(object sender, EventArgs e)
        {
            try
            {
                if (socioEncontrado == null || datosDelSocio == null)
                {
                    MessageBox.Show("Debe seleccionar un socio primero.", "Validación",
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Verificar si ya tiene carnet activo
                if (carnetDAO.TieneCarnetActivo(datosDelSocio.Id))
                {
                    if (MessageBox.Show("El socio ya tiene un carnet activo. ¿Desea generar uno nuevo?",
                                      "Carnet Existente", MessageBoxButtons.YesNo,
                                      MessageBoxIcon.Question) == DialogResult.No)
                    {
                        return;
                    }
                }

                // Generar nuevo carnet
                carnetGenerado = new Carnet();
                carnetGenerado.SocioId = datosDelSocio.Id;
                carnetGenerado.FechaVencimiento = DateTime.Now.AddYears(1);

                if (carnetDAO.InsertarCarnet(carnetGenerado, datosDelSocio.Id))
                {
                    MostrarCarnet();
                    btnImprimir.Enabled = true;

                    MessageBox.Show("¡Carnet generado exitosamente!", "Éxito",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error al generar el carnet.", "Error",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al generar carnet: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MostrarCarnet()
        {
            lblCarnetNombre.Text = $"Nombre: {socioEncontrado.NombreCompleto}";
            lblCarnetNumero.Text = $"Nº Socio: {datosDelSocio.NumeroSocio}";
            lblCarnetDNI.Text = $"DNI: {socioEncontrado.DNI}";
            lblCarnetEmision.Text = $"Fecha Emisión: {DateTime.Now:dd/MM/yyyy}";
            lblCarnetVencimiento.Text = $"Vencimiento: {DateTime.Now.AddYears(1):dd/MM/yyyy}";
        }

        private void LimpiarCarnet()
        {
            lblCarnetNombre.Text = "Nombre:";
            lblCarnetNumero.Text = "Nº Socio:";
            lblCarnetDNI.Text = "DNI:";
            lblCarnetEmision.Text = "Fecha Emisión:";
            lblCarnetVencimiento.Text = "Vencimiento:";
            btnImprimir.Enabled = false;
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Función de impresión:\n\n" +
                          "- Conectar impresora\n" +
                          "- Configurar formato de carnet\n" +
                          "- Imprimir en tarjeta PVC\n\n" +
                          "¡Carnet listo para entregar!", "Imprimir Carnet",
                          MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
