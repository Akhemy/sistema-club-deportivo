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
            btnCerrar.Click += BtnCerrar_Click;
            txtBuscarSocio.MaxLength = 8;

        }

        private void InitializeComponent()
        {
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.txtBuscarSocio = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.pnlCarnet = new System.Windows.Forms.Panel();
            this.lblCarnetTitulo = new System.Windows.Forms.Label();
            this.lblDatos = new System.Windows.Forms.Label();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.pnlCarnet.SuspendLayout();
            this.SuspendLayout();
            this.txtBuscarSocio.KeyPress += new KeyPressEventHandler(this.txtBuscarSocio_KeyPress);

            // 
            // lblTitulo
            // 
            this.lblTitulo.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblTitulo.Location = new System.Drawing.Point(200, 20);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(300, 30);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Generar Carnet de Socio";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTitulo.Click += new System.EventHandler(this.lblTitulo_Click);
            // 
            // lblBuscar
            // 
            this.lblBuscar.Font = new System.Drawing.Font("Arial", 10F);
            this.lblBuscar.Location = new System.Drawing.Point(50, 80);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new System.Drawing.Size(120, 20);
            this.lblBuscar.TabIndex = 1;
            this.lblBuscar.Text = "Buscar socio (DNI):";
            // 
            // txtBuscarSocio
            // 
            this.txtBuscarSocio.Font = new System.Drawing.Font("Arial", 10F);
            this.txtBuscarSocio.Location = new System.Drawing.Point(180, 78);
            this.txtBuscarSocio.Name = "txtBuscarSocio";
            this.txtBuscarSocio.Size = new System.Drawing.Size(200, 23);
            this.txtBuscarSocio.TabIndex = 2;
            this.txtBuscarSocio.TextChanged += new System.EventHandler(this.txtBuscarSocio_TextChanged);
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.btnBuscar.ForeColor = System.Drawing.Color.White;
            this.btnBuscar.Location = new System.Drawing.Point(400, 76);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(80, 30);
            this.btnBuscar.TabIndex = 3;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // pnlCarnet
            // 
            this.pnlCarnet.BackColor = System.Drawing.Color.White;
            this.pnlCarnet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCarnet.Controls.Add(this.lblCarnetTitulo);
            this.pnlCarnet.Controls.Add(this.lblDatos);
            this.pnlCarnet.Location = new System.Drawing.Point(50, 130);
            this.pnlCarnet.Name = "pnlCarnet";
            this.pnlCarnet.Size = new System.Drawing.Size(600, 280);
            this.pnlCarnet.TabIndex = 4;
            this.pnlCarnet.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlCarnet_Paint);
            // 
            // lblCarnetTitulo
            // 
            this.lblCarnetTitulo.BackColor = System.Drawing.Color.DodgerBlue;
            this.lblCarnetTitulo.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold);
            this.lblCarnetTitulo.ForeColor = System.Drawing.Color.White;
            this.lblCarnetTitulo.Location = new System.Drawing.Point(0, 0);
            this.lblCarnetTitulo.Name = "lblCarnetTitulo";
            this.lblCarnetTitulo.Size = new System.Drawing.Size(600, 40);
            this.lblCarnetTitulo.TabIndex = 0;
            this.lblCarnetTitulo.Text = "CARNET DE SOCIO";
            this.lblCarnetTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblCarnetTitulo.Click += new System.EventHandler(this.lblCarnetTitulo_Click);
            // 
            // lblDatos
            // 
            this.lblDatos.Font = new System.Drawing.Font("Arial", 12F);
            this.lblDatos.ForeColor = System.Drawing.Color.Gray;
            this.lblDatos.Location = new System.Drawing.Point(30, 80);
            this.lblDatos.Name = "lblDatos";
            this.lblDatos.Size = new System.Drawing.Size(540, 170);
            this.lblDatos.TabIndex = 1;
            this.lblDatos.Text = "Ingrese un DNI y presione \'Buscar\' para generar el carnet...";
            this.lblDatos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblDatos.Click += new System.EventHandler(this.lblDatos_Click);
            // 
            // btnImprimir
            // 
            this.btnImprimir.BackColor = System.Drawing.Color.Green;
            this.btnImprimir.Enabled = false;
            this.btnImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImprimir.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.btnImprimir.ForeColor = System.Drawing.Color.White;
            this.btnImprimir.Location = new System.Drawing.Point(250, 430);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(100, 35);
            this.btnImprimir.TabIndex = 5;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.UseVisualStyleBackColor = false;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.BackColor = System.Drawing.Color.Crimson;
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.btnCerrar.ForeColor = System.Drawing.Color.White;
            this.btnCerrar.Location = new System.Drawing.Point(370, 430);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(100, 35);
            this.btnCerrar.TabIndex = 6;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click_1);
            // 
            // FormCarnet
            // 
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(684, 511);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.lblBuscar);
            this.Controls.Add(this.txtBuscarSocio);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.pnlCarnet);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.btnCerrar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FormCarnet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Club Deportivo - Generar Carnet";
            this.pnlCarnet.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                string dni = txtBuscarSocio.Text.Trim();

                if (string.IsNullOrWhiteSpace(dni))
                {
                    MessageBox.Show("Ingrese un DNI para buscar.", "Validación",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (dni.Length < 7 || dni.Length > 8)
                {
                    MessageBox.Show("El DNI debe tener entre 7 y 8 dígitos.", "Validación",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtBuscarSocio.Focus();
                    return;
                }

                if (dni.StartsWith("0"))
                {
                    MessageBox.Show("El DNI no puede comenzar con 0.", "Validación",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtBuscarSocio.Focus();
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

        private void txtBuscarSocio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Solo se permiten números para el DNI.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtBuscarSocio_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblTitulo_Click(object sender, EventArgs e)
        {

        }

        private void lblCarnetTitulo_Click(object sender, EventArgs e)
        {

        }

        private void lblDatos_Click(object sender, EventArgs e)
        {

        }

        private void pnlCarnet_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnCerrar_Click_1(object sender, EventArgs e)
        {

        }
    }
}