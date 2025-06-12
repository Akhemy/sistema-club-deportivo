using ClubDeportivoSystem.Data;
using ClubDeportivoSystem.Models;
using System;
using System.Drawing;
using System.Windows.Forms;
using static Org.BouncyCastle.Crypto.Engines.SM2Engine;

namespace ClubDeportivoSystem.Forms
{
    public class FormRegistro : Form
    {
        private Label lblTitulo;
        private GroupBox gbDatos;
        private Label lblNombre;
        private TextBox txtNombre;
        private Label lblApellido;
        private TextBox txtApellido;
        private Label lblDNI;
        private TextBox txtDNI;
        private Label lblTipo;
        private RadioButton rbSocio;
        private RadioButton rbNoSocio;
        private CheckBox chkAptoFisico;
        private Button btnGuardar;
        private Button btnCancelar;

        public FormRegistro()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            // Configurar formulario
            this.Text = "Registro de Socios/No Socios";
            this.Size = new Size(500, 450);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.BackColor = Color.LightGray;

            // Título
            lblTitulo = new Label();
            lblTitulo.Text = "Registro de Socios/No Socios";
            lblTitulo.Font = new Font("Arial", 16, FontStyle.Bold);
            lblTitulo.ForeColor = Color.DarkBlue;
            lblTitulo.Location = new Point(100, 20);
            lblTitulo.Size = new Size(300, 30);
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;

            // GroupBox Datos Personales
            gbDatos = new GroupBox();
            gbDatos.Text = "Datos Personales";
            gbDatos.Location = new Point(50, 70);
            gbDatos.Size = new Size(400, 270);
            gbDatos.BackColor = Color.White;
            gbDatos.Font = new Font("Arial", 10, FontStyle.Bold);

            // Label Nombre
            lblNombre = new Label();
            lblNombre.Text = "Nombre:";
            lblNombre.Location = new Point(20, 30);
            lblNombre.Size = new Size(100, 20);
            lblNombre.Font = new Font("Arial", 9);

            // TextBox Nombre
            txtNombre = new TextBox();
            txtNombre.Location = new Point(130, 28);
            txtNombre.Size = new Size(250, 25);
            txtNombre.Font = new Font("Arial", 9);

            // Label Apellido
            lblApellido = new Label();
            lblApellido.Text = "Apellido:";
            lblApellido.Location = new Point(20, 70);
            lblApellido.Size = new Size(100, 20);
            lblApellido.Font = new Font("Arial", 9);

            // TextBox Apellido
            txtApellido = new TextBox();
            txtApellido.Location = new Point(130, 68);
            txtApellido.Size = new Size(250, 25);
            txtApellido.Font = new Font("Arial", 9);

            // Label DNI
            lblDNI = new Label();
            lblDNI.Text = "DNI:";
            lblDNI.Location = new Point(20, 110);
            lblDNI.Size = new Size(100, 20);
            lblDNI.Font = new Font("Arial", 9);

            // TextBox DNI
            txtDNI = new TextBox();
            txtDNI.Location = new Point(130, 108);
            txtDNI.Size = new Size(250, 25);
            txtDNI.Font = new Font("Arial", 9);
            txtDNI.KeyPress += new KeyPressEventHandler(txtDNI_KeyPress);

            // Label Tipo
            lblTipo = new Label();
            lblTipo.Text = "Tipo:";
            lblTipo.Location = new Point(20, 150);
            lblTipo.Size = new Size(100, 20);
            lblTipo.Font = new Font("Arial", 9);

            // RadioButton Socio
            rbSocio = new RadioButton();
            rbSocio.Text = "Socio";
            rbSocio.Location = new Point(130, 148);
            rbSocio.Size = new Size(80, 25);
            rbSocio.Font = new Font("Arial", 9);
            rbSocio.Checked = true; // Seleccionado por defecto

            // RadioButton No Socio
            rbNoSocio = new RadioButton();
            rbNoSocio.Text = "No Socio";
            rbNoSocio.Location = new Point(230, 148);
            rbNoSocio.Size = new Size(100, 25);
            rbNoSocio.Font = new Font("Arial", 9);

            //CheckBox Apto FísicoMore actions
            chkAptoFisico = new CheckBox();
            chkAptoFisico.Text = "Entregó Apto Físico";
            chkAptoFisico.Location = new Point(130, 190);
            chkAptoFisico.Size = new Size(200, 25);
            chkAptoFisico.Font = new Font("Arial", 9);
            chkAptoFisico.BackColor = Color.Transparent;
            chkAptoFisico.CheckedChanged += new EventHandler(chkAptoFisico_CheckedChanged);

            // Botón Guardar
            btnGuardar = new Button();
            btnGuardar.Text = "Guardar";
            btnGuardar.Location = new Point(50, 360);
            btnGuardar.Size = new Size(100, 35);
            btnGuardar.BackColor = Color.DodgerBlue;
            btnGuardar.ForeColor = Color.White;
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.Font = new Font("Arial", 10, FontStyle.Bold);
            btnGuardar.Click += new EventHandler(btnGuardar_Click);

            // Botón Cancelar
            btnCancelar = new Button();
            btnCancelar.Text = "Cancelar";
            btnCancelar.Location = new Point(350, 360);
            btnCancelar.Size = new Size(100, 35);
            btnCancelar.BackColor = Color.Crimson;
            btnCancelar.ForeColor = Color.White;
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.Font = new Font("Arial", 10, FontStyle.Bold);
            btnCancelar.Click += new EventHandler(btnCancelar_Click);

            // Agregar controles al GroupBox
            gbDatos.Controls.Add(lblNombre);
            gbDatos.Controls.Add(txtNombre);
            gbDatos.Controls.Add(lblApellido);
            gbDatos.Controls.Add(txtApellido);
            gbDatos.Controls.Add(lblDNI);
            gbDatos.Controls.Add(txtDNI);
            gbDatos.Controls.Add(lblTipo);
            gbDatos.Controls.Add(rbSocio);
            gbDatos.Controls.Add(rbNoSocio);
            gbDatos.Controls.Add(chkAptoFisico);

            // Agregar controles al formulario
            this.Controls.Add(lblTitulo);
            this.Controls.Add(gbDatos);
            this.Controls.Add(btnGuardar);
            this.Controls.Add(btnCancelar);
        }


        private void chkAptoFisico_CheckedChanged(object sender, EventArgs e) 
        {
            // Podriamos mostrar una fecha de vencimiento si está marcado
        }


        // Solo permitir números en el campo DNI
        private void txtDNI_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Solo se permiten números en el DNI.", "Validación",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar campos
                if (!ValidarDatos())
                    return;

                // Crear instancias de DAO
                PersonaDAO personaDAO = new PersonaDAO();
                SocioDAO socioDAO = new SocioDAO();

                // Verificar si la persona ya existe
                if (personaDAO.ExistePersona(txtDNI.Text.Trim()))
                {
                    MessageBox.Show("Ya existe una persona registrada con este DNI.",
                                  "Persona ya registrada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDNI.Focus();
                    return;
                }

                // Determinar tipo de persona
                string tipoPersona = rbSocio.Checked ? "socio" : "no_socio";

                // Crear nueva persona
                Persona nuevaPersona = new Persona(
                    txtNombre.Text.Trim(),
                    txtApellido.Text.Trim(),
                    txtDNI.Text.Trim(),
                    tipoPersona,
                    chkAptoFisico.Checked
                );

                // Insertar persona en la base de datos
                if (personaDAO.InsertarPersona(nuevaPersona))
                {
                    // Obtener la persona recién insertada para conseguir el ID
                    Persona personaInsertada = personaDAO.ObtenerPersonaPorDNI(txtDNI.Text.Trim());

                    if (personaInsertada != null)
                    {
                        // Si es socio, crear registro en tabla socios
                        if (rbSocio.Checked)
                        {
                            if (socioDAO.InsertarSocio(personaInsertada.Id))
                            {
                                // Obtener el socio para mostrar el número
                                Socio socioCreado = socioDAO.ObtenerSocioPorPersonaId(personaInsertada.Id);

                                string mensaje = $"¡SOCIO registrado exitosamente en la base de datos!\n\n" +
                                               $"Nombre: {nuevaPersona.NombreCompleto}\n" +
                                               $"DNI: {nuevaPersona.DNI}\n" +
                                               $"Número de Socio: {socioCreado?.NumeroSocio}\n" +
                                               $"Apto Físico: {(chkAptoFisico.Checked ? "Entregado" : "No entregado")}\n" +
                                               $"Fecha de registro: {DateTime.Now:dd/MM/yyyy}";

                                MessageBox.Show(mensaje, "¡Registro Exitoso!",
                                              MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("Error: Se registró la persona pero no se pudo crear el socio.",
                                              "Error Parcial", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        else
                        {
                            // Si es no socio, crear registro en tabla no_socios
                            if (socioDAO.InsertarNoSocio(personaInsertada.Id))
                            {
                                string mensaje = $"¡NO SOCIO registrado exitosamente en la base de datos!\n\n" +
                                               $"Nombre: {nuevaPersona.NombreCompleto}\n" +
                                               $"DNI: {nuevaPersona.DNI}\n" +
                                               $"Apto Físico: {(chkAptoFisico.Checked ? "Entregado" : "No entregado")}\n" +
                                               $"Fecha de registro: {DateTime.Now:dd/MM/yyyy}";

                                MessageBox.Show(mensaje, "¡Registro Exitoso!",
                                              MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("Error: Se registró la persona pero no se pudo crear el no socio.",
                                              "Error Parcial", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }

                        // Limpiar formulario después del éxito
                        LimpiarFormulario();
                    }
                    else
                    {
                        MessageBox.Show("Error: No se pudo recuperar la persona insertada.",
                                      "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Error al registrar la persona en la base de datos.",
                                  "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inesperado: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidarDatos()
        {
            // Validar nombre
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("El nombre es obligatorio.", "Validación",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return false;
            }

            // Validar apellido
            if (string.IsNullOrWhiteSpace(txtApellido.Text))
            {
                MessageBox.Show("El apellido es obligatorio.", "Validación",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtApellido.Focus();
                return false;
            }

            // Validar DNI
            if (string.IsNullOrWhiteSpace(txtDNI.Text) || txtDNI.Text.Length < 7)
            {
                MessageBox.Show("El DNI debe tener al menos 7 dígitos.", "Validación",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDNI.Focus();
                return false;
            }

            return true;
        }

        private void LimpiarFormulario()
        {
            txtNombre.Clear();
            txtApellido.Clear();
            txtDNI.Clear();
            rbSocio.Checked = true;
            rbNoSocio.Checked = false;
            chkAptoFisico.Checked = false;
            txtNombre.Focus();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            // Verificar si hay datos ingresados
            if (HayDatosIngresados())
            {
                if (MessageBox.Show("¿Está seguro que desea cancelar? Se perderán los datos ingresados.",
                                  "Confirmar Cancelación", MessageBoxButtons.YesNo,
                                  MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    this.Close();
                }
            }
            else
            {
                // Si no hay datos, cerrar directamente sin advertencia
                this.Close();
            }
        }

        private bool HayDatosIngresados()
        {
            // Verificar si algún campo tiene texto
            if (!string.IsNullOrWhiteSpace(txtNombre.Text) ||
                !string.IsNullOrWhiteSpace(txtApellido.Text) ||
                !string.IsNullOrWhiteSpace(txtDNI.Text))
            {
                return true;
            }

            // Verificar si los radio buttons han cambiado del estado por defecto
            // (por defecto rbSocio está marcado)
            if (!rbSocio.Checked)
            {
                return true;
            }

            // Verificar si el checkbox está marcado
            if (chkAptoFisico.Checked)
            {
                return true;
            }

            return false;
        }
    }
}