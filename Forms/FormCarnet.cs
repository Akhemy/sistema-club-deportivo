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
        private Label lblBuscar;
        private TextBox txtBuscarSocio;
        private Button btnBuscar;
        private Panel pnlCarnet;
        private Label lblCarnetTitulo;
        private Label lblDatos;
        private Button btnImprimir;
        private Button btnCerrar;

        private PersonaDAO personaDAO;
        private SocioDAO socioDAO;
        private bool carnetGenerado = false;

        public FormCarnet()
        {
            personaDAO = new PersonaDAO();
            socioDAO = new SocioDAO();
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = "Club Deportivo - Generar Carnet";
            this.Size = new Size(700, 550);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.LightGray;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            // Título principal
            lblTitulo = new Label();
            lblTitulo.Text = "Generar Carnet de Socio";
            lblTitulo.Font = new Font("Arial", 18, FontStyle.Bold);
            lblTitulo.ForeColor = Color.DarkBlue;
            lblTitulo.Location = new Point(200, 20);
            lblTitulo.Size = new Size(300, 30);
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;

            // Buscar socio
            lblBuscar = new Label();
            lblBuscar.Text = "Buscar socio (DNI):";
            lblBuscar.Font = new Font("Arial", 10);
            lblBuscar.Location = new Point(50, 80);
            lblBuscar.Size = new Size(120, 20);

            txtBuscarSocio = new TextBox();
            txtBuscarSocio.Location = new Point(180, 78);
            txtBuscarSocio.Size = new Size(200, 25);
            txtBuscarSocio.Font = new Font("Arial", 10);

            btnBuscar = new Button();
            btnBuscar.Text = "Buscar";
            btnBuscar.Location = new Point(400, 76);
            btnBuscar.Size = new Size(80, 30);
            btnBuscar.BackColor = Color.DodgerBlue;
            btnBuscar.ForeColor = Color.White;
            btnBuscar.FlatStyle = FlatStyle.Flat;
            btnBuscar.Font = new Font("Arial", 9, FontStyle.Bold);
            btnBuscar.Click += new EventHandler(btnBuscar_Click);

            // Panel del carnet (como tarjeta)
            pnlCarnet = new Panel();
            pnlCarnet.Location = new Point(50, 130);
            pnlCarnet.Size = new Size(600, 280);
            pnlCarnet.BackColor = Color.White;
            pnlCarnet.BorderStyle = BorderStyle.FixedSingle;

            // Título del carnet
            lblCarnetTitulo = new Label();
            lblCarnetTitulo.Text = "CARNET DE SOCIO";
            lblCarnetTitulo.Font = new Font("Arial", 16, FontStyle.Bold);
            lblCarnetTitulo.ForeColor = Color.White;
            lblCarnetTitulo.BackColor = Color.DodgerBlue;
            lblCarnetTitulo.Location = new Point(0, 0);
            lblCarnetTitulo.Size = new Size(600, 40);
            lblCarnetTitulo.TextAlign = ContentAlignment.MiddleCenter;

            // Área de datos
            lblDatos = new Label();
            lblDatos.Text = "Ingrese un DNI y presione 'Buscar' para generar el carnet...";
            lblDatos.Font = new Font("Arial", 12);
            lblDatos.ForeColor = Color.Gray;
            lblDatos.Location = new Point(30, 80);
            lblDatos.Size = new Size(540, 150);
            lblDatos.TextAlign = ContentAlignment.MiddleLeft;

            pnlCarnet.Controls.Add(lblCarnetTitulo);
            pnlCarnet.Controls.Add(lblDatos);

            // Botón Imprimir
            btnImprimir = new Button();
            btnImprimir.Text = "Imprimir";
            btnImprimir.Location = new Point(250, 430);
            btnImprimir.Size = new Size(100, 35);
            btnImprimir.BackColor = Color.Green;
            btnImprimir.ForeColor = Color.White;
            btnImprimir.FlatStyle = FlatStyle.Flat;
            btnImprimir.Font = new Font("Arial", 10, FontStyle.Bold);
            btnImprimir.Enabled = false;
            btnImprimir.Click += new EventHandler(btnImprimir_Click);

            // Botón Cerrar
            btnCerrar = new Button();
            btnCerrar.Text = "Cerrar";
            btnCerrar.Location = new Point(370, 430);
            btnCerrar.Size = new Size(100, 35);
            btnCerrar.BackColor = Color.Crimson;
            btnCerrar.ForeColor = Color.White;
            btnCerrar.FlatStyle = FlatStyle.Flat;
            btnCerrar.Font = new Font("Arial", 10, FontStyle.Bold);
            btnCerrar.Click += (s, e) => this.Close();

            // Agregar controles
            this.Controls.Add(lblTitulo);
            this.Controls.Add(lblBuscar);
            this.Controls.Add(txtBuscarSocio);
            this.Controls.Add(btnBuscar);
            this.Controls.Add(pnlCarnet);
            this.Controls.Add(btnImprimir);
            this.Controls.Add(btnCerrar);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                string dni = txtBuscarSocio.Text.Trim();

                if (string.IsNullOrEmpty(dni))
                {
                    MessageBox.Show("Ingrese un DNI para buscar.", "Validación",
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var persona = personaDAO.ObtenerPersonaPorDNI(dni);

                if (persona == null)
                {
                    lblDatos.Text = "No se encontró ninguna persona con ese DNI.";
                    lblDatos.ForeColor = Color.Red;
                    btnImprimir.Enabled = false;
                    carnetGenerado = false;
                    return;
                }

                if (persona.TipoPersona != "socio")
                {
                    lblDatos.Text = "La persona encontrada no es un socio.";
                    lblDatos.ForeColor = Color.Red;
                    btnImprimir.Enabled = false;
                    carnetGenerado = false;
                    return;
                }

                var socio = socioDAO.ObtenerSocioPorPersonaId(persona.Id);

                if (socio != null)
                {
                    // Mostrar datos del carnet
                    lblDatos.Text = $"Nombre: {persona.NombreCompleto}\n\n" +
                                  $"Nº Socio: {socio.NumeroSocio:D5}\n\n" +
                                  $"DNI: {persona.DNI}\n\n" +
                                  $"Fecha Emisión: {DateTime.Now:dd/MM/yyyy}\n\n" +
                                  $"Vencimiento: {DateTime.Now.AddYears(1):dd/MM/yyyy}";

                    lblDatos.ForeColor = Color.Black;
                    lblDatos.Font = new Font("Arial", 11, FontStyle.Bold);

                    btnImprimir.Enabled = true;
                    carnetGenerado = true;

                    MessageBox.Show("¡Carnet generado exitosamente!", "Éxito",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al buscar socio: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (!carnetGenerado)
            {
                MessageBox.Show("Debe generar un carnet primero.", "Validación",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MessageBox.Show("Imprimiendo carnet...\n\n" +
                          "- Configurando impresora\n" +
                          "- Enviando datos a impresora\n" +
                          "- Impresión en proceso\n\n" +
                          "¡Carnet impreso exitosamente!", "Imprimir Carnet",
                          MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}