using System;
using System.Drawing;
using System.Windows.Forms;
using ClubDeportivoSystem.Forms;

namespace ClubDeportivoSystem.Forms
{
    public class FormPrincipal : Form
    {
        private Label lblTitulo;
        private Button btnRegistro;
        private Button btnPagos;
        private Button btnCarnet;
        private Button btnVencimientos;
        private Button btnSalir;

        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            // Configurar formulario
            this.Text = "Club Deportivo - Sistema de Gestión";
            this.Size = new Size(800, 600);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.LightGray;

            // Título
            lblTitulo = new Label();
            lblTitulo.Text = "Sistema de Gestión - Club Deportivo";
            lblTitulo.Font = new Font("Arial", 18, FontStyle.Bold);
            lblTitulo.ForeColor = Color.DarkBlue;
            lblTitulo.Location = new Point(200, 50);
            lblTitulo.Size = new Size(400, 40);
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;

            // Botón Registro
            btnRegistro = new Button();
            btnRegistro.Text = "Registro de\nSocios/No Socios";
            btnRegistro.Location = new Point(150, 150);
            btnRegistro.Size = new Size(150, 80);
            btnRegistro.BackColor = Color.LightBlue;
            btnRegistro.Font = new Font("Arial", 10, FontStyle.Bold);
            btnRegistro.Click += new EventHandler(btnRegistro_Click);

            // Botón Pagos
            btnPagos = new Button();
            btnPagos.Text = "Cobro de Cuota\nMensual/Diaria";
            btnPagos.Location = new Point(350, 150);
            btnPagos.Size = new Size(150, 80);
            btnPagos.BackColor = Color.LightGreen;
            btnPagos.Font = new Font("Arial", 10, FontStyle.Bold);
            btnPagos.Click += new EventHandler(btnPagos_Click);

            // Botón Carnet
            btnCarnet = new Button();
            btnCarnet.Text = "Generar Carnet\nde Socio";
            btnCarnet.Location = new Point(550, 150);
            btnCarnet.Size = new Size(150, 80);
            btnCarnet.BackColor = Color.LightCoral;
            btnCarnet.Font = new Font("Arial", 10, FontStyle.Bold);
            btnCarnet.Click += new EventHandler(btnCarnet_Click);

            // Botón Vencimientos
            btnVencimientos = new Button();
            btnVencimientos.Text = "Listado de Cuotas\npor Vencer";
            btnVencimientos.Location = new Point(250, 280);
            btnVencimientos.Size = new Size(150, 80);
            btnVencimientos.BackColor = Color.LightYellow;
            btnVencimientos.Font = new Font("Arial", 10, FontStyle.Bold);
            btnVencimientos.Click += new EventHandler(btnVencimientos_Click);

            // Botón Salir
            btnSalir = new Button();
            btnSalir.Text = "Cerrar Sesión";
            btnSalir.Location = new Point(450, 280);
            btnSalir.Size = new Size(150, 80);
            btnSalir.BackColor = Color.Crimson;
            btnSalir.ForeColor = Color.White;
            btnSalir.Font = new Font("Arial", 10, FontStyle.Bold);
            btnSalir.Click += new EventHandler(btnSalir_Click);

            // Agregar controles
            this.Controls.Add(lblTitulo);
            this.Controls.Add(btnRegistro);
            this.Controls.Add(btnPagos);
            this.Controls.Add(btnCarnet);
            this.Controls.Add(btnVencimientos);
            this.Controls.Add(btnSalir);
        }

        private void btnRegistro_Click(object sender, EventArgs e)
        {
            FormRegistro formRegistro = new FormRegistro();
            formRegistro.ShowDialog();
        }

        private void btnPagos_Click(object sender, EventArgs e)
        {
            FormPagos formPagos = new FormPagos();
            formPagos.ShowDialog();
        }

        private void btnCarnet_Click(object sender, EventArgs e)
        {
            try
            {
                FormCarnet formCarnet = new FormCarnet();
                formCarnet.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al abrir FormCarnet: {ex.Message}",
                               "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnVencimientos_Click(object sender, EventArgs e)
        {
            FormVencimientos formVencimientos = new FormVencimientos();
            formVencimientos.ShowDialog();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro que desea cerrar sesión?", "Confirmar",
                              MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
