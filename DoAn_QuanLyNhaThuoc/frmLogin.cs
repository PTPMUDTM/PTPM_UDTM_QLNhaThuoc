using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using BLL_DAL1;
namespace DoAn_QuanLyNhaThuoc
{
    public partial class frmLogin : DevExpress.XtraEditors.XtraForm
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textEdit1.Text.Trim()))
            {
                MessageBox.Show("Vui long khong bo trong username!");
                return;
            }
            if (string.IsNullOrEmpty(textEdit2.Text.Trim()))
            {
                MessageBox.Show("Vui long khong bo trong mat khau!");
                return;
            }
            int check_connect = XuLyDangNhap.Check_Connection();
            if (check_connect == 0)
            {
                MessageBox.Show("Cau hinh trong, vui long nhap cau hinh!");
                Handle_Server_Config();
                return;
            }
            if (check_connect == 2)
            {
                MessageBox.Show("Cau hinh sai, vui long chon lai cau hinh!");
                Handle_Server_Config();
                return;
            }
            
            Handle_Login();
            
        }
        private void Handle_Login()
        {
            int result = XuLyDangNhap.Try_Login(textEdit1.Text, textEdit2.Text);
            if (result == XuLyDangNhap.CONNECT_FAIL)
            {
                MessageBox.Show("Sai ten dang nhap hoac mat khau!");
                return;
            }
            if (result == XuLyDangNhap.INACTIVE)
            {
                MessageBox.Show("Tai khoan nay da bi khoa!");
                return;
            }
            if (Program.fMain == null || Program.fMain.IsDisposed)
            {
                Program.fMain = new FormMain();
            }
            this.Visible=false;
       
            Program.fMain.TenDangNhap = textEdit1.Text;
            
            Program.fMain.Show();
        }

        private void Handle_Server_Config()
        {
            frmCauHinh form = new frmCauHinh();
            form.ShowDialog();
        }

        private void hyperlinkLabelControl1_Click(object sender, EventArgs e)
        {
            Program.frgt = new frmRegister();
            Program.frgt.Show();
        }
    }
    }
