using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL_DAL1;
namespace DoAn_QuanLyNhaThuoc
{
    public partial class frmChangePassword : DevExpress.XtraEditors.XtraForm
    {
        public frmChangePassword()
        {
            InitializeComponent();
        }
        RegisterBLLDAL rg = new RegisterBLLDAL();
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtTaiKhoan.Text.Length > 0 && txtMatkhauCu.Text.Length > 0 && txtMatKhauMoi.Text == txtNhapLaiMatKhau.Text&&txtNhapLaiMatKhau.Text.Length>0)
            {
                
                    if(rg.DoiMatKhau(txtTaiKhoan.Text, txtMatkhauCu.Text, txtMatKhauMoi.Text))
                {
                    MessageBox.Show("Đổi Mật Khẩu Thành Công");
                }
                    
                else
                {
                    MessageBox.Show("Đổi Mật Khẩu Thất Bại");
                }

                this.Close();
                

            }
            else
            {
                MessageBox.Show("Vui Lòng Nhập Tài Khoản Mật Khẩu, Hoặc Mật Khẩu Không Trùng Khớp");
            }
        }
    }
}