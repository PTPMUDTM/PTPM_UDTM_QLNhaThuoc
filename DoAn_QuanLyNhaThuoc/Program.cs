using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.UserSkins;
using DevExpress.Skins;

namespace DoAn_QuanLyNhaThuoc
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        public static frmLogin fLogin;
        public static FormMain fMain;
        public static frPQuyen fpq;
        public static FrmThuoc frThuoc;
        public static frmRegister frgt;
        public static frmChangePassword frchangepw;
        public static FormTrangChu frtrangchu;
        [STAThread]
        static void Main()
        {
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            BonusSkins.Register();
            SkinManager.EnableFormSkins();
            fLogin = new frmLogin();
       
            Application.Run(new frmLogin());
        }
    }
}
