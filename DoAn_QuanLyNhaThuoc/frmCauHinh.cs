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
    public partial class frmCauHinh : DevExpress.XtraEditors.XtraForm
    {
        
        public frmCauHinh()
        {
            InitializeComponent();
        }

        private void cbServer_DropDown(object sender, EventArgs e)
        {
            cbServer.DataSource = XuLyDangNhap.Get_Server_Names();
            cbServer.DisplayMember = "ServerName";
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cbServer.Text))
            {
                MessageBox.Show("Vui long chon server!");
                return;
            }
            if (string.IsNullOrEmpty(txtUser.Text))
            {
                MessageBox.Show("Vui long nhap user!");
                return;
            }
            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("Vui long nhap password!");
                return;
            }
            if (string.IsNullOrEmpty(cbDatabase.Text))
            {
                MessageBox.Show("Vui long chon database!");
                return;
            }
            XuLyDangNhap.Change_Connection_String(cbServer.Text, txtUser.Text, txtPassword.Text, cbDatabase.Text);
            MessageBox.Show("Luu thanh cong!");
        }

        private void cbDatabase_DropDown(object sender, EventArgs e)
        {
            cbDatabase.Items.Clear();
            List<string> list = XuLyDangNhap.Get_Databases(cbServer.Text, txtUser.Text, txtPassword.Text);
            cbDatabase.Items.AddRange(list.ToArray());
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}