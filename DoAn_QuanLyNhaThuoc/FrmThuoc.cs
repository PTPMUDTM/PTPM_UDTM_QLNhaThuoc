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
    public partial class FrmThuoc : DevExpress.XtraEditors.XtraForm
    {
        public FrmThuoc()
        {
            InitializeComponent();
        }
        QLThuoc QL = new QLThuoc();
        private void FrmThuoc_Load(object sender, EventArgs e)
        {
         
           
        }
    }
}