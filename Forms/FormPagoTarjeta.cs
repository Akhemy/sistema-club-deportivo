using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                PagoExitoso = true;
                MessageBox.Show("Pago realizado con éxito.", "Éxito",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();   // vuelve a FormPagos
            }
        }

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
                MostrarError("El número de tarjeta debe tener 16 dígitos.", txtNumeroTarjeta);
                return false;
            }

            // Titular
            if (string.IsNullOrWhiteSpace(txtTitular.Text))
            {
                MostrarError("Por favor, ingrese el nombre del titular.", txtTitular);
                return false;
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
                MostrarError("La fecha de vencimiento debe ser MM/AA o MM/AAAA.", txtVencimientoTarjeta1);
                return false;
            }
            DateTime ultimoDiaMes = new DateTime(fechaVto.Year, fechaVto.Month,
                DateTime.DaysInMonth(fechaVto.Year, fechaVto.Month));

            if (ultimoDiaMes < DateTime.Today)
            {
                MostrarError("La tarjeta ya está vencida.", txtVencimientoTarjeta1);
                return false;
            }

            // CVV
            if (string.IsNullOrWhiteSpace(txtCVV.Text))
            {
                MostrarError("Por favor, ingrese el CVV.", txtCVV);
                return false;
            }
            if (!txtCVV.Text.All(char.IsDigit) || (txtCVV.Text.Length != 3 && txtCVV.Text.Length != 4))
            {
                MostrarError("El CVV debe tener 3 o 4 dígitos.", txtCVV);
                return false;
            }

            return true;
        }

        private static void MostrarError(string mensaje, Control controlConError)
        {
            MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            controlConError.Focus();
        }


        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
