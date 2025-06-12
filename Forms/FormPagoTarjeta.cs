using ClubDeportivoSystem.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace ClubDeportivoSystem.Forms
{
    public partial class FormPagoTarjeta : Form
    {
        public bool PagoExitoso { get; private set; }
        public decimal Monto { get; }


        //Constructor
        public FormPagoTarjeta(decimal monto)
        {
            InitializeComponent();
            Monto = monto;
            cmbCuotas.SelectedIndex = 0;
            ActualizarMontoFinal(); // mostrar el total al iniciar

        }

        private void lblTituloTarjeta_Click(object sender, EventArgs e)
        {

        }

        private void gbDatosTarjeta_Enter(object sender, EventArgs e)
        {

        }

        private void lblTitular_Click(object sender, EventArgs e)
        {

        }

        private void lblVencimientoTarjeta_Click(object sender, EventArgs e)
        {

        }

        private void lblCVV_Click(object sender, EventArgs e)
        {

        }

        private void txtTitular_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNumeroTarjeta_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtVencimientoTarjeta1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {

                DialogResult = DialogResult.OK;
                Close();   // vuelve a FormPagos
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void lblCuotas_Click(object sender, EventArgs e)
        {

        }

        private void cmbCuotas_SelectedIndexChanged(object sender, EventArgs e)
        {
        
            ActualizarMontoFinal();
        
        }

        private void lblTotal_Click(object sender, EventArgs e)
        {

        }

        private void lblTotalCuota_Click(object sender, EventArgs e)
        {

        }

        //FUNCION PARA VALIDAR CAMPOS
        private bool ValidarCampos()
        {
            // Número de tarjeta
            if (string.IsNullOrWhiteSpace(txtNumeroTarjeta.Text))
            {
                MostrarError("Por favor, ingrese el número de la tarjeta.", txtNumeroTarjeta);
                return false;
            }
            if (!txtNumeroTarjeta.Text.All(char.IsDigit) || txtNumeroTarjeta.Text.Length != 16)
            {
                txtNumeroTarjeta.BackColor = Color.MistyRose;
                MostrarError("El número de tarjeta debe tener 16 dígitos.", txtNumeroTarjeta);
                return false;
            }
            else
            {
                txtNumeroTarjeta.BackColor = Color.White;
            }

                // Titular
                var palabrasValidas = Regex.Matches(txtTitular.Text, @"\b[A-Za-zÁÉÍÓÚÑáéíóúñ]+\b");
            if (string.IsNullOrWhiteSpace(txtTitular.Text) || palabrasValidas.Count < 2)
            {
                // Validar al menos dos palabras reales (con letras)
                MostrarError("Por favor, ingrese nombre y apellido válidos.", txtTitular);
                txtTitular.BackColor = Color.MistyRose;
                return false;
            }
            else
            {
                txtTitular.BackColor = Color.White;
            }

            // Vencimiento
            if (string.IsNullOrWhiteSpace(txtVencimientoTarjeta1.Text))
            {
                MostrarError("Por favor, ingrese la fecha de vencimiento.", txtVencimientoTarjeta1);
                return false;
            }
            if (!DateTime.TryParseExact(
                    txtVencimientoTarjeta1.Text,
                    new[] { "MM/yy", "MM/yyyy" },
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.None,
                    out DateTime fechaVto))
            {
                txtVencimientoTarjeta1.BackColor = Color.MistyRose;
                MostrarError("La fecha de vencimiento debe ser MM/AA o MM/AAAA.", txtVencimientoTarjeta1);
                return false;
            }
            DateTime ultimoDiaMes = new DateTime(fechaVto.Year, fechaVto.Month,
                DateTime.DaysInMonth(fechaVto.Year, fechaVto.Month));

            if (ultimoDiaMes < DateTime.Today)
            {
                txtVencimientoTarjeta1.BackColor = Color.MistyRose;
                MostrarError("La tarjeta ya está vencida.", txtVencimientoTarjeta1);
                return false;
            }
            else
            {
                txtVencimientoTarjeta1.BackColor = Color.White;
            }

            // CVV
            if (string.IsNullOrWhiteSpace(txtCVV.Text))
            {
                MostrarError("Por favor, ingrese el CVV.", txtCVV);
                return false;
            }
            if (!txtCVV.Text.All(char.IsDigit) || (txtCVV.Text.Length != 3 && txtCVV.Text.Length != 4))
            {
                txtCVV.BackColor = Color.MistyRose;
                MostrarError("El CVV debe tener 3 o 4 dígitos.", txtCVV);
                return false;
            }
            else
            {
                txtCVV.BackColor = Color.White;
            }

            // Confirmar el pago
            var (montoFinal, cuotas) = CalcularMontoFinal();
            string mensaje = $"¿Confirmar el pago?\nTotal: {cuotas} cuota/s de ${montoFinal / cuotas:F2}";

            if (MessageBox.Show(mensaje, "Confirmar Pago", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                PagoExitoso = true;
                return true;
            }
            else
            {
                PagoExitoso = false;
                return false;
            }
        }

        //FUNCION PARA DETERMINAR CUOTAS
        private int ObtenerCantidadDeCuotas()
        {
            if (cmbCuotas.SelectedItem != null)
            {
                string seleccion = cmbCuotas.SelectedItem?.ToString() ?? "";
                if (seleccion.Contains("6")) return 6;
                if (seleccion.Contains("3")) return 3;
                return 1;// Por defecto 1 cuota
            }
            return 1; // También por defecto, si no hay selección
        }

        //Calculo de cuotas y total en el formulario
        private void ActualizarMontoFinal()
        {
            var (montoFinal, cuotas) = CalcularMontoFinal();
            lblTotal.Text = $"Total a pagar: ${montoFinal:F2}";
            lblTotalCuota.Text = $"Total a pagar: {cuotas} cuota/s de ${montoFinal / cuotas:F2}";
        }

        private (decimal montoFinal, int cuotas) CalcularMontoFinal()
        {
            int cuotas = ObtenerCantidadDeCuotas();
            decimal descuento = 0.0m;

            if (cuotas == 3)
                descuento = 0.10m;
            else if (cuotas == 6)
                descuento = 0.15m;

            decimal montoFinal = Monto - (Monto * descuento);
            return (montoFinal, cuotas);
        }

        private static void MostrarError(string mensaje, Control controlConError)
        {
            MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            controlConError.Focus();
        }
    }
}
