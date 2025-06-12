using System;
using System.Windows.Forms;

namespace ClubDeportivoSystem.Forms
{
    public partial class FormConfigDB : Form
    {
        public string Server { get; private set; }
        public string Port { get; private set; }
        public string Database { get; private set; }
        public string Username { get; private set; }
        public string Password { get; private set; }
        public bool ConfigurationSaved { get; private set; } = false;

        private TextBox txtServer;
        private TextBox txtPort;
        private TextBox txtDatabase;
        private TextBox txtUsername;
        private TextBox txtPassword;
        private Button btnSave;
        private Button btnCancel;
        private Button btnTest;
        private Label lblServer;
        private Label lblPort;
        private Label lblDatabase;
        private Label lblUsername;
        private Label lblPassword;
        private Label lblTitle;

        public FormConfigDB()
        {
            InitializeComponent();
           // LoadDefaultValues();
        }

        private void InitializeComponent()
        {
            this.Text = "Configuración de Base de Datos";
            this.Size = new System.Drawing.Size(400, 350);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            // Título
            lblTitle = new Label();
            lblTitle.Text = "Configuración de Conexión MySQL";
            lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            lblTitle.Location = new System.Drawing.Point(50, 20);
            lblTitle.Size = new System.Drawing.Size(300, 25);
            lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // Servidor
            lblServer = new Label();
            lblServer.Text = "Servidor:";
            lblServer.Location = new System.Drawing.Point(30, 60);
            lblServer.Size = new System.Drawing.Size(80, 20);

            txtServer = new TextBox();
            txtServer.Location = new System.Drawing.Point(120, 58);
            txtServer.Size = new System.Drawing.Size(200, 20);

            // Puerto
            lblPort = new Label();
            lblPort.Text = "Puerto:";
            lblPort.Location = new System.Drawing.Point(30, 90);
            lblPort.Size = new System.Drawing.Size(80, 20);

            txtPort = new TextBox();
            txtPort.Location = new System.Drawing.Point(120, 88);
            txtPort.Size = new System.Drawing.Size(200, 20);

            // Base de Datos
            lblDatabase = new Label();
            lblDatabase.Text = "Base de Datos:";
            lblDatabase.Location = new System.Drawing.Point(30, 120);
            lblDatabase.Size = new System.Drawing.Size(80, 20);

            txtDatabase = new TextBox();
            txtDatabase.Location = new System.Drawing.Point(120, 118);
            txtDatabase.Size = new System.Drawing.Size(200, 20);

            // Usuario
            lblUsername = new Label();
            lblUsername.Text = "Usuario:";
            lblUsername.Location = new System.Drawing.Point(30, 150);
            lblUsername.Size = new System.Drawing.Size(80, 20);

            txtUsername = new TextBox();
            txtUsername.Location = new System.Drawing.Point(120, 148);
            txtUsername.Size = new System.Drawing.Size(200, 20);

            // Contraseña
            lblPassword = new Label();
            lblPassword.Text = "Contraseña:";
            lblPassword.Location = new System.Drawing.Point(30, 180);
            lblPassword.Size = new System.Drawing.Size(80, 20);

            txtPassword = new TextBox();
            txtPassword.Location = new System.Drawing.Point(120, 178);
            txtPassword.Size = new System.Drawing.Size(200, 20);
            txtPassword.UseSystemPasswordChar = true;

            // Botones
            btnTest = new Button();
            btnTest.Text = "Probar Conexión";
            btnTest.Location = new System.Drawing.Point(30, 220);
            btnTest.Size = new System.Drawing.Size(120, 30);
            btnTest.Click += BtnTest_Click;

            btnSave = new Button();
            btnSave.Text = "Guardar";
            btnSave.Location = new System.Drawing.Point(160, 220);
            btnSave.Size = new System.Drawing.Size(80, 30);
            btnSave.Click += BtnSave_Click;

            btnCancel = new Button();
            btnCancel.Text = "Cancelar";
            btnCancel.Location = new System.Drawing.Point(250, 220);
            btnCancel.Size = new System.Drawing.Size(80, 30);
            btnCancel.Click += BtnCancel_Click;

            // Agregar controles al formulario
            this.Controls.Add(lblTitle);
            this.Controls.Add(lblServer);
            this.Controls.Add(txtServer);
            this.Controls.Add(lblPort);
            this.Controls.Add(txtPort);
            this.Controls.Add(lblDatabase);
            this.Controls.Add(txtDatabase);
            this.Controls.Add(lblUsername);
            this.Controls.Add(txtUsername);
            this.Controls.Add(lblPassword);
            this.Controls.Add(txtPassword);
            this.Controls.Add(btnTest);
            this.Controls.Add(btnSave);
            this.Controls.Add(btnCancel);
        }

       /* private void LoadDefaultValues()
        {
            txtServer.Text = "localhost";
            txtPort.Text = "3306";
            txtDatabase.Text = "club_deportivo";
            txtUsername.Text = "root";
            txtPassword.Text = "root";
        }
       */



        private void BtnTest_Click(object sender, EventArgs e)
        {
            if (ValidateFields())
            {
                try
                {
                    // Crear conexión temporal para probar
                    string testConnectionString = $"Server={txtServer.Text};Port={txtPort.Text};Database={txtDatabase.Text};Uid={txtUsername.Text};Pwd={txtPassword.Text};";

                    using (var connection = new MySql.Data.MySqlClient.MySqlConnection(testConnectionString))
                    {
                        connection.Open();
                        MessageBox.Show("¡Conexión exitosa!", "Prueba de Conexión",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error en la conexión:\n{ex.Message}", "Error de Conexión",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (ValidateFields())
            {
                Server = txtServer.Text;
                Port = txtPort.Text;
                Database = txtDatabase.Text;
                Username = txtUsername.Text;
                Password = txtPassword.Text;
                ConfigurationSaved = true;

                MessageBox.Show("Configuración guardada correctamente.", "Configuración",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private bool ValidateFields()
        {
            if (string.IsNullOrWhiteSpace(txtServer.Text))
            {
                MessageBox.Show("El campo Servidor es obligatorio.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtServer.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtPort.Text))
            {
                MessageBox.Show("El campo Puerto es obligatorio.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPort.Focus();
                return false;
            }

            if (!int.TryParse(txtPort.Text, out int port) || port <= 0 || port > 65535)
            {
                MessageBox.Show("El puerto debe ser un número válido entre 1 y 65535.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPort.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtDatabase.Text))
            {
                MessageBox.Show("El campo Base de Datos es obligatorio.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDatabase.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                MessageBox.Show("El campo Usuario es obligatorio.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Focus();
                return false;
            }

            return true;
        }
    }
}