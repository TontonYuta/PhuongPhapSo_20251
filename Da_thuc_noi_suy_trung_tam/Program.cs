using Da_thuc_noi_suy_trung_tam;
using System;
using System.Windows.Forms;

namespace NewtonCentralWinForms
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
