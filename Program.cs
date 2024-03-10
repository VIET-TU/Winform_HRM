using HRM_Desktop.Member;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HRM_Desktop
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //Tài Làm Authen sẽ chỉnh lại để chạy Login
            //Application.Run(new AuthenticationForm());
            // Quyền, Thành, sẽ chỉnh lại để chạy Main Menu

            new Connection();
            Application.Run(new MainMenuForm());
            if (Connection.db == null)
            {
                MessageBox.Show("Connect false", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    }
}
