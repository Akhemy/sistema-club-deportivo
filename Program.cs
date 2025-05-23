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