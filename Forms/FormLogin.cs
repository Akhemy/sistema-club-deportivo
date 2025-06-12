using System;
using System.Drawing;
using System.Windows.Forms;

namespace ClubDeportivoSystem.Forms
{
    public class FormLogin : Form
    {
        private Label lblTitulo;
        private Label lblUsuario;
        private Label lblPassword;
        private TextBox txtUsuario;
        private TextBox txtPassword;
        private Button btnIngresar;
        private Button btnSalir;

        public FormLogin()
        {
            InitializeComponent();
            MostrarConfiguracionBD();
        }

        private void MostrarConfiguracionBD()
        {
            FormConfigDB configForm = new FormConfigDB();

            if (configForm.ShowDialog() == DialogResult.OK)
            {
                // Configuración exitosa, continuar con el login
                MessageBox.Show("Base de datos configurada correctamente.", "Configuración Exitosa",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // Usuario canceló, cerrar aplicación
                MessageBox.Show("Es necesario configurar la base de datos para continuar.", "Configuración Requerida",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Application.Exit();
            }
        }




        private void InitializeComponent()
        {
            // Configurar el formulario
            this.Text = "Club Deportivo - Login";
            this.Size = new Size(400, 300);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.BackColor = Color.LightGray;

            // Título
            lblTitulo = new Label();
            lblTitulo.Text = "Club Deportivo - Login";
            lblTitulo.Font = new Font("Arial", 16, FontStyle.Bold);
            lblTitulo.ForeColor = Color.DarkBlue;
            lblTitulo.Location = new Point(80, 30);
            lblTitulo.Size = new Size(240, 30);
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;

            // Label Usuario
            lblUsuario = new Label();
            lblUsuario.Text = "Usuario:";
            lblUsuario.Location = new Point(80, 80);
            lblUsuario.Size = new Size(60, 20);

            // TextBox Usuario
            txtUsuario = new TextBox();
            txtUsuario.Location = new Point(80, 100);
            txtUsuario.Size = new Size(240, 25);
            txtUsuario.Text = "admin";

            // Label Password
            lblPassword = new Label();
            lblPassword.Text = "Contraseña:";
            lblPassword.Location = new Point(80, 130);
            lblPassword.Size = new Size(80, 20);

            // TextBox Password
            txtPassword = new TextBox();
            txtPassword.Location = new Point(80, 150);
            txtPassword.Size = new Size(240, 25);
            txtPassword.PasswordChar = '*';
            txtPassword.Text = "admin";

            // Botón Ingresar
            btnIngresar = new Button();
            btnIngresar.Text = "Ingresar";
            btnIngresar.Location = new Point(80, 200);
            btnIngresar.Size = new Size(100, 35);
            btnIngresar.BackColor = Color.DodgerBlue;
            btnIngresar.ForeColor = Color.White;
            btnIngresar.FlatStyle = FlatStyle.Flat;
            btnIngresar.Click += new EventHandler(btnIngresar_Click);

            // Botón Salir
            btnSalir = new Button();
            btnSalir.Text = "Salir";
            btnSalir.Location = new Point(220, 200);
            btnSalir.Size = new Size(100, 35);
            btnSalir.BackColor = Color.Crimson;
            btnSalir.ForeColor = Color.White;
            btnSalir.FlatStyle = FlatStyle.Flat;
            btnSalir.Click += new EventHandler(btnSalir_Click);

            // Agregar todos los controles al formulario
            this.Controls.Add(lblTitulo);
            this.Controls.Add(lblUsuario);
            this.Controls.Add(txtUsuario);
            this.Controls.Add(lblPassword);
            this.Controls.Add(txtPassword);
            this.Controls.Add(btnIngresar);
            this.Controls.Add(btnSalir);
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (txtUsuario.Text.Trim() == "admin" && txtPassword.Text.Trim() == "admin")
            {
                MessageBox.Show("¡Bienvenido al sistema!", "Acceso Exitoso",
                              MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Abrir FormPrincipal
                FormPrincipal formPrincipal = new FormPrincipal();
                this.Hide();  // Ocultar login
                formPrincipal.ShowDialog();  // Mostrar menú principal
                this.Close();  // Cerrar login cuando se cierre el principal
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos.", "Error de Acceso",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Clear();
                txtUsuario.Focus();
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro que desea salir?", "Confirmar Salida",
                              MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}