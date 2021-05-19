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
    public partial class frmRegister : DevExpress.XtraEditors.XtraForm
    {
        public frmRegister()
        {
            InitializeComponent();
        }
        RegisterBLLDAL rg = new RegisterBLLDAL();
        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if(txtTaiKhoan.Text.Length>0&&txtMatkhau.Text.Length>0&&txtMatkhau.Text==txtRematkhau.Text)
            {
                try
                {
                    rg.ThemTK(txtTaiKhoan.Text, txtMatkhau.Text,true);
                    MessageBox.Show("Đăng Ký Thành Công");
                }
                catch
                {
                    MessageBox.Show("Đăng Ký Thất Bại");
                }

            }
            else
            {
                MessageBox.Show("Vui Lòng Nhập Tài Khoản Mật Khẩu Hoặc Mật Khẩu Không Trùng Khớp");
            }
            this.Close();
        }
    }
}