/*
using System;
using System.Windows.Forms;
using ClubDeportivoSystem.Forms;  // ← IMPORTANTE: Esta línea nueva

namespace ClubDeportivoSystem
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormLogin());  // ←  FormLogin
        }
    }
}
*/
using System;
using System.Windows.Forms;
using ClubDeportivoSystem.Forms;

namespace ClubDeportivoSystem
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Mostrar configuración de BD
            using (var configForm = new FormConfigDB())
            {
                if (configForm.ShowDialog() != DialogResult.OK)
                {
                    MessageBox.Show("La aplicación no puede iniciar sin configuración.",
                                  "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // Cierra la aplicación si se cancela
                }
            }

            //Iniciar login
            Application.Run(new FormLogin());
        }
    }
}
