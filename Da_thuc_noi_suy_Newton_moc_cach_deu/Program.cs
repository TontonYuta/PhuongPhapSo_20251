using System;
using System.Windows.Forms;

namespace NewtonInterpolationWinForms
{
    internal static class Program
    {
        /// <summary>
        /// Điểm vào chính của ứng dụng.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1()); // chạy Form1
        }
    }
}
