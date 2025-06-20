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
            this.lblTitulo = new System.Windows.Forms.Label();
            this.gbDatos = new System.Windows.Forms.GroupBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblApellido = new System.Windows.Forms.Label();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.lblDNI = new System.Windows.Forms.Label();
            this.txtDNI = new System.Windows.Forms.TextBox();
            this.lblTipo = new System.Windows.Forms.Label();
            this.rbSocio = new System.Windows.Forms.RadioButton();
            this.rbNoSocio = new System.Windows.Forms.RadioButton();
            this.chkAptoFisico = new System.Windows.Forms.CheckBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.gbDatos.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblTitulo.Location = new System.Drawing.Point(100, 20);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(300, 30);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Registro de Socios/No Socios";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTitulo.Click += new System.EventHandler(this.lblTitulo_Click);
            // 
            // gbDatos
            // 
            this.gbDatos.BackColor = System.Drawing.Color.White;
            this.gbDatos.Controls.Add(this.lblNombre);
            this.gbDatos.Controls.Add(this.txtNombre);
            this.gbDatos.Controls.Add(this.lblApellido);
            this.gbDatos.Controls.Add(this.txtApellido);
            this.gbDatos.Controls.Add(this.lblDNI);
            this.gbDatos.Controls.Add(this.txtDNI);
            this.gbDatos.Controls.Add(this.lblTipo);
            this.gbDatos.Controls.Add(this.rbSocio);
            this.gbDatos.Controls.Add(this.rbNoSocio);
            this.gbDatos.Controls.Add(this.chkAptoFisico);
            this.gbDatos.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.gbDatos.Location = new System.Drawing.Point(50, 70);
            this.gbDatos.Name = "gbDatos";
            this.gbDatos.Size = new System.Drawing.Size(400, 270);
            this.gbDatos.TabIndex = 1;
            this.gbDatos.TabStop = false;
            this.gbDatos.Text = "Datos Personales";
            // 
            // lblNombre
            // 
            this.lblNombre.Font = new System.Drawing.Font("Arial", 9F);
            this.lblNombre.Location = new System.Drawing.Point(20, 30);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(100, 20);
            this.lblNombre.TabIndex = 0;
            this.lblNombre.Text = "Nombre:";
            this.lblNombre.Click += new System.EventHandler(this.lblNombre_Click);
            // 
            // txtNombre
            // 
            this.txtNombre.KeyPress += new KeyPressEventHandler(this.txtNombre_KeyPress);
            this.txtApellido.KeyPress += new KeyPressEventHandler(this.txtApellido_KeyPress);
            this.txtNombre.Font = new System.Drawing.Font("Arial", 9F);
            this.txtNombre.Location = new System.Drawing.Point(130, 28);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(250, 21);
            this.txtNombre.TabIndex = 1;
            this.txtNombre.TextChanged += new System.EventHandler(this.txtNombre_TextChanged);
            // 
            // lblApellido
            // 
            this.lblApellido.Font = new System.Drawing.Font("Arial", 9F);
            this.lblApellido.Location = new System.Drawing.Point(20, 70);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new System.Drawing.Size(100, 20);
            this.lblApellido.TabIndex = 2;
            this.lblApellido.Text = "Apellido:";
            this.lblApellido.Click += new System.EventHandler(this.lblApellido_Click);
            // 
            // txtApellido
            // 
            this.txtApellido.Font = new System.Drawing.Font("Arial", 9F);
            this.txtApellido.Location = new System.Drawing.Point(130, 68);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(250, 21);
            this.txtApellido.TabIndex = 3;
            this.txtApellido.TextChanged += new System.EventHandler(this.txtApellido_TextChanged);
            // 
            // lblDNI
            // 
            this.lblDNI.Font = new System.Drawing.Font("Arial", 9F);
            this.lblDNI.Location = new System.Drawing.Point(20, 110);
            this.lblDNI.Name = "lblDNI";
            this.lblDNI.Size = new System.Drawing.Size(100, 20);
            this.lblDNI.TabIndex = 4;
            this.lblDNI.Text = "DNI:";
            this.lblDNI.Click += new System.EventHandler(this.lblDNI_Click);
            // 
            // txtDNI
            // 
            this.txtDNI.Font = new System.Drawing.Font("Arial", 9F);
            this.txtDNI.Location = new System.Drawing.Point(130, 108);
            this.txtDNI.Name = "txtDNI";
            this.txtDNI.Size = new System.Drawing.Size(250, 21);
            this.txtDNI.TabIndex = 5;
            this.txtDNI.TextChanged += new System.EventHandler(this.txtDNI_TextChanged);
            this.txtDNI.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDNI_KeyPress);
            // 
            // lblTipo
            // 
            this.lblTipo.Font = new System.Drawing.Font("Arial", 9F);
            this.lblTipo.Location = new System.Drawing.Point(20, 150);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(100, 20);
            this.lblTipo.TabIndex = 6;
            this.lblTipo.Text = "Tipo:";
            this.lblTipo.Click += new System.EventHandler(this.lblTipo_Click);
            // 
            // rbSocio
            // 
            this.rbSocio.Checked = true;
            this.rbSocio.Font = new System.Drawing.Font("Arial", 9F);
            this.rbSocio.Location = new System.Drawing.Point(130, 148);
            this.rbSocio.Name = "rbSocio";
            this.rbSocio.Size = new System.Drawing.Size(80, 25);
            this.rbSocio.TabIndex = 7;
            this.rbSocio.TabStop = true;
            this.rbSocio.Text = "Socio";
            this.rbSocio.CheckedChanged += new System.EventHandler(this.rbSocio_CheckedChanged);
            // 
            // rbNoSocio
            // 
            this.rbNoSocio.Font = new System.Drawing.Font("Arial", 9F);
            this.rbNoSocio.Location = new System.Drawing.Point(230, 148);
            this.rbNoSocio.Name = "rbNoSocio";
            this.rbNoSocio.Size = new System.Drawing.Size(100, 25);
            this.rbNoSocio.TabIndex = 8;
            this.rbNoSocio.Text = "No Socio";
            this.rbNoSocio.CheckedChanged += new System.EventHandler(this.rbNoSocio_CheckedChanged);
            // 
            // chkAptoFisico
            // 
            this.chkAptoFisico.BackColor = System.Drawing.Color.Transparent;
            this.chkAptoFisico.Font = new System.Drawing.Font("Arial", 9F);
            this.chkAptoFisico.Location = new System.Drawing.Point(130, 190);
            this.chkAptoFisico.Name = "chkAptoFisico";
            this.chkAptoFisico.Size = new System.Drawing.Size(200, 25);
            this.chkAptoFisico.TabIndex = 9;
            this.chkAptoFisico.Text = "Entregó Apto Físico";
            this.chkAptoFisico.UseVisualStyleBackColor = false;
            this.chkAptoFisico.CheckedChanged += new System.EventHandler(this.chkAptoFisico_CheckedChanged);
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Location = new System.Drawing.Point(50, 360);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(100, 35);
            this.btnGuardar.TabIndex = 2;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.Crimson;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(350, 360);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(100, 35);
            this.btnCancelar.TabIndex = 3;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // FormRegistro
            // 
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(484, 411);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.gbDatos);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnCancelar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FormRegistro";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registro de Socios/No Socios";
            this.Load += new System.EventHandler(this.FormRegistro_Load);
            this.gbDatos.ResumeLayout(false);
            this.gbDatos.PerformLayout();
            this.ResumeLayout(false);

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

            //Validar entrega de apto físico
            if (!chkAptoFisico.Checked)
            {
                MessageBox.Show("Debe entregar el Apto Físico para registrarse.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false; // Detiene el flujo para que no continúe con el guardado
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

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Solo se permiten letras en el campo Nombre.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Solo se permiten letras en el campo Apellido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtApellido_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDNI_TextChanged(object sender, EventArgs e)
        {

        }

        private void rbSocio_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rbNoSocio_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void lblNombre_Click(object sender, EventArgs e)
        {

        }

        private void lblApellido_Click(object sender, EventArgs e)
        {

        }

        private void lblDNI_Click(object sender, EventArgs e)
        {

        }

        private void lblTipo_Click(object sender, EventArgs e)
        {

        }

        private void lblTitulo_Click(object sender, EventArgs e)
        {

        }

        private void FormRegistro_Load(object sender, EventArgs e)
        {

        }
    }
}