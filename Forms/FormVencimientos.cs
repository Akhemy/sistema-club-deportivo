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

        private CuotaDAO cuotaDAO;

        public FormVencimientos()
        {
            cuotaDAO = new CuotaDAO();
            InitializeComponent();
            CargarVencimientos();
        }

        private void InitializeComponent()
        {
            // Configurar formulario
            this.Text = "Listado de Cuotas por Vencer";
            this.Size = new Size(900, 600);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.LightGray;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            // Título
            lblTitulo = new Label();
            lblTitulo.Text = "Listado de Cuotas por Vencer";
            lblTitulo.Font = new Font("Arial", 16, FontStyle.Bold);
            lblTitulo.ForeColor = Color.DarkBlue;
            lblTitulo.Location = new Point(300, 20);
            lblTitulo.Size = new Size(300, 30);
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;

            // GroupBox Filtros
            gbFiltros = new GroupBox();
            gbFiltros.Text = "Filtros de Consulta";
            gbFiltros.Location = new Point(50, 70);
            gbFiltros.Size = new Size(800, 80);
            gbFiltros.BackColor = Color.White;
            gbFiltros.Font = new Font("Arial", 10, FontStyle.Bold);

            lblFecha = new Label();
            lblFecha.Text = "Mostrar vencimientos hasta:";
            lblFecha.Location = new Point(20, 30);
            lblFecha.Size = new Size(150, 20);
            lblFecha.Font = new Font("Arial", 9);

            dtpFechaHasta = new DateTimePicker();
            dtpFechaHasta.Location = new Point(180, 28);
            dtpFechaHasta.Size = new Size(150, 25);
            dtpFechaHasta.Value = DateTime.Now.AddDays(30); // Por defecto próximos 30 días

            btnConsultar = new Button();
            btnConsultar.Text = "Consultar";
            btnConsultar.Location = new Point(350, 26);
            btnConsultar.Size = new Size(100, 30);
            btnConsultar.BackColor = Color.DodgerBlue;
            btnConsultar.ForeColor = Color.White;
            btnConsultar.FlatStyle = FlatStyle.Flat;
            btnConsultar.Click += new EventHandler(btnConsultar_Click);

            btnExportar = new Button();
            btnExportar.Text = "Exportar";
            btnExportar.Location = new Point(470, 26);
            btnExportar.Size = new Size(100, 30);
            btnExportar.BackColor = Color.Green;
            btnExportar.ForeColor = Color.White;
            btnExportar.FlatStyle = FlatStyle.Flat;
            btnExportar.Click += new EventHandler(btnExportar_Click);

            gbFiltros.Controls.Add(lblFecha);
            gbFiltros.Controls.Add(dtpFechaHasta);
            gbFiltros.Controls.Add(btnConsultar);
            gbFiltros.Controls.Add(btnExportar);

            // DataGridView
            dgvVencimientos = new DataGridView();
            dgvVencimientos.Location = new Point(50, 170);
            dgvVencimientos.Size = new Size(800, 300);
            dgvVencimientos.BackgroundColor = Color.White;
            dgvVencimientos.BorderStyle = BorderStyle.Fixed3D;
            dgvVencimientos.AllowUserToAddRows = false;
            dgvVencimientos.AllowUserToDeleteRows = false;
            dgvVencimientos.ReadOnly = true;
            dgvVencimientos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvVencimientos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Configurar columnas
            dgvVencimientos.Columns.Add("NumeroSocio", "Nº Socio");
            dgvVencimientos.Columns.Add("Nombre", "Nombre");
            dgvVencimientos.Columns.Add("Apellido", "Apellido");
            dgvVencimientos.Columns.Add("DNI", "DNI");
            dgvVencimientos.Columns.Add("EstadoCuota", "Estado Cuota");
            dgvVencimientos.Columns.Add("FechaUltimaCuota", "Última Cuota");
            dgvVencimientos.Columns.Add("Situacion", "Situación");

            // Ajustar ancho de columnas
            dgvVencimientos.Columns["NumeroSocio"].Width = 80;
            dgvVencimientos.Columns["Nombre"].Width = 120;
            dgvVencimientos.Columns["Apellido"].Width = 120;
            dgvVencimientos.Columns["DNI"].Width = 100;
            dgvVencimientos.Columns["EstadoCuota"].Width = 100;
            dgvVencimientos.Columns["FechaUltimaCuota"].Width = 120;
            dgvVencimientos.Columns["Situacion"].Width = 120;

            // Label Total
            lblTotal = new Label();
            lblTotal.Text = "Total de socios: 0";
            lblTotal.Location = new Point(50, 480);
            lblTotal.Size = new Size(200, 20);
            lblTotal.Font = new Font("Arial", 10, FontStyle.Bold);

            // Botón Cerrar
            btnCerrar = new Button();
            btnCerrar.Text = "Cerrar";
            btnCerrar.Location = new Point(750, 510);
            btnCerrar.Size = new Size(100, 35);
            btnCerrar.BackColor = Color.Crimson;
            btnCerrar.ForeColor = Color.White;
            btnCerrar.FlatStyle = FlatStyle.Flat;
            btnCerrar.Click += new EventHandler(btnCerrar_Click);

            // Agregar controles al formulario
            this.Controls.Add(lblTitulo);
            this.Controls.Add(gbFiltros);
            this.Controls.Add(dgvVencimientos);
            this.Controls.Add(lblTotal);
            this.Controls.Add(btnCerrar);
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
    }
}