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
    public partial class FormMain : DevExpress.XtraEditors.XtraForm
    {
        public FormMain()
        {
            InitializeComponent();
        }
        private string tenDangNhap;

        public string TenDangNhap
        {
            get { return tenDangNhap; }
            set { tenDangNhap = value; }
        }
        RegisterBLLDAL NguoiDung = new RegisterBLLDAL();

        private Form KiemTraTon(Type ftype)
        {
            foreach(Form f in this.MdiChildren)
            {
                if(f.GetType()==ftype)
                {
                    return f;
                }    
            }
            return null;
        }
        private void FormMain_Load(object sender, EventArgs e)
        {

            Form pq = this.KiemTraTon(typeof(FormTrangChu));
            if (pq != null)
            {
                pq.Activate();

            }
            else
            {

                FormTrangChu fr = new FormTrangChu();
                fr.MdiParent = this;
                fr.Dock = DockStyle.Fill;
                fr.Show();
            }
            List<string> nhomND = NguoiDung.getMaNhomNguoiDung(tenDangNhap);
            foreach (string item in nhomND)
            {
                DataTable dsQuyen = NguoiDung.getMaManHinh(item);
                foreach (DataRow mh in dsQuyen.Rows)
                {
                    FindMenuPhanQuyen(this.menuStrip1.Items, mh[1].ToString(), Convert.ToBoolean(mh[2].ToString()));
                }
            }

        }
        private void FindMenuPhanQuyen(ToolStripItemCollection mnuItems, string PScreenName, bool pEnable)
        {

            foreach (ToolStripItem menu in mnuItems)
            {
                if (menu is ToolStripMenuItem && ((ToolStripMenuItem)(menu)).DropDownItems.Count > 0)
                {
                    FindMenuPhanQuyen(((ToolStripMenuItem)(menu)).DropDownItems, PScreenName, pEnable);
                    menu.Enabled = CheckAllMenuChildVisible(((ToolStripMenuItem)(menu)).DropDownItems);
                    menu.Visible = menu.Enabled;
                }
                else if (string.Equals(PScreenName, menu.Tag))
                {
                    menu.Enabled = pEnable;
                    menu.Visible = pEnable;
                }
            }
        }

        private bool CheckAllMenuChildVisible(ToolStripItemCollection mnuItems)
        {
            foreach (ToolStripItem menuItem in mnuItems)
            {
                if (menuItem is ToolStripMenuItem && menuItem.Enabled)
                {
                    return true;

                }
                else if (menuItem is ToolStripSeparator)
                {
                    continue;
                }
            }
            return false;

        }

        private void đăngNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLogin fr = new frmLogin();
            fr.MdiParent = this;
            fr.Dock = DockStyle.Fill;
            fr.Show();
        }

        private void đăngKýToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
                frmRegister fr = new frmRegister();
                
                fr.Show();
            

        }

        private void phânQuyềnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form pq = this.KiemTraTon(typeof(frPQuyen));
            if(pq!=null)
            {
                pq.Activate();

            }   
            else
            {

                frPQuyen fr = new frPQuyen();
                fr.MdiParent = this;
                fr.Dock = DockStyle.Fill;
                fr.Show();
            }


        }

        private void quảnLýToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        

        private void HT_Click(object sender, EventArgs e)
        {

        }

        private void thốngKêBáoCáoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
