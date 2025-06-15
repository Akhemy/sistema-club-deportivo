using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using ClubDeportivoSystem.Data;

namespace ClubDeportivoSystem.Forms
{
    public class FormVencimientos : Form
    {
        private Label lblTitulo;
        private GroupBox gbFiltros;
        private Label lblFecha;
        private DateTimePicker dtpFechaHasta;
        private Button btnConsultar;
        private Button btnExportar;
        private DataGridView dgvVencimientos;
        private Label lblTotal;
        private Button btnCerrar;
        private DataGridViewTextBoxColumn NumeroSocio;
        private DataGridViewTextBoxColumn Nombre;
        private DataGridViewTextBoxColumn Apellido;
        private DataGridViewTextBoxColumn DNI;
        private DataGridViewTextBoxColumn EstadoCuota;
        private DataGridViewTextBoxColumn FechaUltimaCuota;
        private DataGridViewTextBoxColumn Situacion;
        private CuotaDAO cuotaDAO;

        public FormVencimientos()
        {
            cuotaDAO = new CuotaDAO();
            InitializeComponent();
            CargarVencimientos();
        }

        private void InitializeComponent()
        {
            this.lblTitulo = new System.Windows.Forms.Label();
            this.gbFiltros = new System.Windows.Forms.GroupBox();
            this.lblFecha = new System.Windows.Forms.Label();
            this.dtpFechaHasta = new System.Windows.Forms.DateTimePicker();
            this.btnConsultar = new System.Windows.Forms.Button();
            this.btnExportar = new System.Windows.Forms.Button();
            this.dgvVencimientos = new System.Windows.Forms.DataGridView();
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.NumeroSocio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Apellido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DNI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EstadoCuota = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaUltimaCuota = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Situacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbFiltros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVencimientos)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblTitulo.Location = new System.Drawing.Point(274, 20);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(346, 30);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Listado de Cuotas por Vencer";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTitulo.Click += new System.EventHandler(this.lblTitulo_Click);
            // 
            // gbFiltros
            // 
            this.gbFiltros.BackColor = System.Drawing.Color.White;
            this.gbFiltros.Controls.Add(this.lblFecha);
            this.gbFiltros.Controls.Add(this.dtpFechaHasta);
            this.gbFiltros.Controls.Add(this.btnConsultar);
            this.gbFiltros.Controls.Add(this.btnExportar);
            this.gbFiltros.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.gbFiltros.Location = new System.Drawing.Point(50, 70);
            this.gbFiltros.Name = "gbFiltros";
            this.gbFiltros.Size = new System.Drawing.Size(800, 80);
            this.gbFiltros.TabIndex = 1;
            this.gbFiltros.TabStop = false;
            this.gbFiltros.Text = "Filtros de Consulta";
            // 
            // lblFecha
            // 
            this.lblFecha.Font = new System.Drawing.Font("Arial", 9F);
            this.lblFecha.Location = new System.Drawing.Point(20, 30);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(150, 20);
            this.lblFecha.TabIndex = 0;
            this.lblFecha.Text = "Mostrar vencimientos hasta:";
            // 
            // dtpFechaHasta
            // 
            this.dtpFechaHasta.Location = new System.Drawing.Point(180, 28);
            this.dtpFechaHasta.Name = "dtpFechaHasta";
            this.dtpFechaHasta.Size = new System.Drawing.Size(150, 23);
            this.dtpFechaHasta.TabIndex = 1;
            this.dtpFechaHasta.Value = new System.DateTime(2025, 7, 14, 21, 26, 25, 101);
            // 
            // btnConsultar
            // 
            this.btnConsultar.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnConsultar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConsultar.ForeColor = System.Drawing.Color.White;
            this.btnConsultar.Location = new System.Drawing.Point(350, 26);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(100, 30);
            this.btnConsultar.TabIndex = 2;
            this.btnConsultar.Text = "Consultar";
            this.btnConsultar.UseVisualStyleBackColor = false;
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // btnExportar
            // 
            this.btnExportar.BackColor = System.Drawing.Color.Green;
            this.btnExportar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportar.ForeColor = System.Drawing.Color.White;
            this.btnExportar.Location = new System.Drawing.Point(470, 26);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(100, 30);
            this.btnExportar.TabIndex = 3;
            this.btnExportar.Text = "Exportar";
            this.btnExportar.UseVisualStyleBackColor = false;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // dgvVencimientos
            // 
            this.dgvVencimientos.AllowUserToAddRows = false;
            this.dgvVencimientos.AllowUserToDeleteRows = false;
            this.dgvVencimientos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvVencimientos.BackgroundColor = System.Drawing.Color.White;
            this.dgvVencimientos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvVencimientos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NumeroSocio,
            this.Nombre,
            this.Apellido,
            this.DNI,
            this.EstadoCuota,
            this.FechaUltimaCuota,
            this.Situacion});
            this.dgvVencimientos.Location = new System.Drawing.Point(50, 156);
            this.dgvVencimientos.Name = "dgvVencimientos";
            this.dgvVencimientos.ReadOnly = true;
            this.dgvVencimientos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvVencimientos.Size = new System.Drawing.Size(800, 300);
            this.dgvVencimientos.TabIndex = 2;
            this.dgvVencimientos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvVencimientos_CellContentClick);
            // 
            // lblTotal
            // 
            this.lblTotal.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.lblTotal.Location = new System.Drawing.Point(50, 480);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(200, 20);
            this.lblTotal.TabIndex = 3;
            this.lblTotal.Text = "Total de socios: 0";
            // 
            // btnCerrar
            // 
            this.btnCerrar.BackColor = System.Drawing.Color.Crimson;
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.ForeColor = System.Drawing.Color.White;
            this.btnCerrar.Location = new System.Drawing.Point(750, 510);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(100, 35);
            this.btnCerrar.TabIndex = 4;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // NumeroSocio
            // 
            this.NumeroSocio.HeaderText = "Nº Socio";
            this.NumeroSocio.Name = "NumeroSocio";
            this.NumeroSocio.ReadOnly = true;
            // 
            // Nombre
            // 
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            // 
            // Apellido
            // 
            this.Apellido.HeaderText = "Apellido";
            this.Apellido.Name = "Apellido";
            this.Apellido.ReadOnly = true;
            // 
            // DNI
            // 
            this.DNI.HeaderText = "DNI";
            this.DNI.Name = "DNI";
            this.DNI.ReadOnly = true;
            // 
            // EstadoCuota
            // 
            this.EstadoCuota.HeaderText = "Estado Cuota";
            this.EstadoCuota.Name = "EstadoCuota";
            this.EstadoCuota.ReadOnly = true;
            // 
            // FechaUltimaCuota
            // 
            this.FechaUltimaCuota.HeaderText = "Última Cuota";
            this.FechaUltimaCuota.Name = "FechaUltimaCuota";
            this.FechaUltimaCuota.ReadOnly = true;
            // 
            // Situacion
            // 
            this.Situacion.HeaderText = "Situación";
            this.Situacion.Name = "Situacion";
            this.Situacion.ReadOnly = true;
            // 
            // FormVencimientos
            // 
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(884, 561);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.gbFiltros);
            this.Controls.Add(this.dgvVencimientos);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.btnCerrar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FormVencimientos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Listado de Cuotas por Vencer";
            this.gbFiltros.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVencimientos)).EndInit();
            this.ResumeLayout(false);

        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            CargarVencimientos();
        }

        private void CargarVencimientos()
        {
            try
            {
                dgvVencimientos.Rows.Clear();

                DateTime fechaHasta = dtpFechaHasta.Value;
                List<object> vencimientos = cuotaDAO.ObtenerCuotasPorVencer(fechaHasta);

                foreach (dynamic vencimiento in vencimientos)
                {
                    int rowIndex = dgvVencimientos.Rows.Add();
                    DataGridViewRow row = dgvVencimientos.Rows[rowIndex];

                    row.Cells["NumeroSocio"].Value = vencimiento.NumeroSocio;
                    row.Cells["Nombre"].Value = vencimiento.Nombre;
                    row.Cells["Apellido"].Value = vencimiento.Apellido;
                    row.Cells["DNI"].Value = vencimiento.DNI;
                    row.Cells["EstadoCuota"].Value = vencimiento.EstadoCuota;

                    if (vencimiento.FechaUltimaCuota != null)
                    {
                        row.Cells["FechaUltimaCuota"].Value = ((DateTime)vencimiento.FechaUltimaCuota).ToString("dd/MM/yyyy");
                    }
                    else
                    {
                        row.Cells["FechaUltimaCuota"].Value = "Nunca";
                    }

                    row.Cells["Situacion"].Value = vencimiento.Situacion;

                    // Colorear filas según situación
                    switch (vencimiento.Situacion.ToString().ToLower())
                    {
                        case "vencida":
                            row.DefaultCellStyle.BackColor = Color.LightCoral;
                            break;
                        case "por vencer":
                            row.DefaultCellStyle.BackColor = Color.LightYellow;
                            break;
                        case "nunca pagó":
                            row.DefaultCellStyle.BackColor = Color.LightPink;
                            break;
                        default:
                            row.DefaultCellStyle.BackColor = Color.White;
                            break;
                    }
                }

                lblTotal.Text = $"Total de socios: {vencimientos.Count}";

                if (vencimientos.Count == 0)
                {
                    MessageBox.Show("No se encontraron socios con cuotas por vencer en la fecha seleccionada.",
                                  "Sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar vencimientos: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvVencimientos.Rows.Count == 0)
                {
                    MessageBox.Show("No hay datos para exportar.", "Sin datos",
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Simular exportación
                string contenido = "REPORTE DE CUOTAS POR VENCER\n";
                contenido += $"Fecha de consulta: {DateTime.Now:dd/MM/yyyy HH:mm}\n";
                contenido += $"Vencimientos hasta: {dtpFechaHasta.Value:dd/MM/yyyy}\n";
                contenido += new string('=', 50) + "\n\n";

                contenido += "Nº Socio\tNombre\tApellido\tDNI\tEstado\tÚlt.Cuota\tSituación\n";
                contenido += new string('-', 80) + "\n";

                foreach (DataGridViewRow row in dgvVencimientos.Rows)
                {
                    if (row.IsNewRow) continue;

                    contenido += $"{row.Cells["NumeroSocio"].Value}\t";
                    contenido += $"{row.Cells["Nombre"].Value}\t";
                    contenido += $"{row.Cells["Apellido"].Value}\t";
                    contenido += $"{row.Cells["DNI"].Value}\t";
                    contenido += $"{row.Cells["EstadoCuota"].Value}\t";
                    contenido += $"{row.Cells["FechaUltimaCuota"].Value}\t";
                    contenido += $"{row.Cells["Situacion"].Value}\n";
                }

                contenido += new string('-', 80) + "\n";
                contenido += $"Total de socios: {dgvVencimientos.Rows.Count - 1}";

                MessageBox.Show("Exportación completada:\n\n" +
                              "El reporte se ha generado exitosamente.\n" +
                              "Se puede imprimir o guardar según necesidad.\n\n" +
                              $"Total registros: {dgvVencimientos.Rows.Count - 1}",
                              "Exportar Reporte", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al exportar: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblTitulo_Click(object sender, EventArgs e)
        {

        }

        private void dgvVencimientos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}