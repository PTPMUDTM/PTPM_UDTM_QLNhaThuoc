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
    public partial class frPQuyen : DevExpress.XtraEditors.XtraForm
    {
        public frPQuyen()
        {
            InitializeComponent();
        }
        RegisterBLLDAL rg = new RegisterBLLDAL();
        private void simpleButton2_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {

        }
        
        private void simpleButton4_Click(object sender, EventArgs e)
        {

        }

        private void frPQuyen_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            gridControl1.DataSource = rg.getNguoiDung();
            gridControl2.DataSource = rg.getNhomNguoiDung();
            gridControl3.DataSource = rg.getNguoiDung();
            comboBox1.DataSource = rg.getNhomNguoiDung();
            comboBox1.ValueMember = "manhom";
            comboBox1.DisplayMember = "tennhom";
            gridControl4.DataSource = rg.getNDNhomNDtheomaNhom("admin");
               gridControl5.DataSource = rg.getNhomNguoiDung();
             rg.loadPQ(gridControl6,"NV");
           // gridControl6.DataSource = rg.getPhanQuyen("admin");
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void btn_Xoa_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            this.Close();
        }

        private void bnXoa_Click(object sender, EventArgs e)
        {
            string row = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, TenDN).ToString();
            if(rg.XoaTaiKhoan(row))
            {
                MessageBox.Show("Xoa Thanh Cong");
                 gridControl1.DataSource = rg.getNguoiDung();
            }
            else
            {
                MessageBox.Show("Xoa That Bai");
            }    
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string ma = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, TenDN).ToString();
            string matkhau = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, MatKhau).ToString();
            Boolean hd = Boolean.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, HoatDong).ToString());
            
                if(rg.SuaTaiKhoan(ma, matkhau, hd))
            {
                MessageBox.Show("Sua Thanh Cong");
                gridControl1.DataSource = rg.getNguoiDung();

            }
                else
            {
                MessageBox.Show("Sua That Bai");

            }    
                
           
         }

        private void btnThem_Click(object sender, EventArgs e)
        {
            Program.frgt = new frmRegister();
            Program.frgt.Show();
            gridControl1.DataSource = rg.getNguoiDung();
        }

        private void btnXoaNhom_Click(object sender, EventArgs e)
        {
            string row = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, MaNhom).ToString();
            if (rg.XoaNhom(row))
            {
                MessageBox.Show("Xoa Thanh Cong");
                gridControl2.DataSource = rg.getNhomNguoiDung();
            }
            else
            {
                MessageBox.Show("Xoa That Bai");
            }
        }

        private void btnThemNhom_Click(object sender, EventArgs e)
        {
            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtTaiKhoan.Text.Length > 0 && txtMatkhau.Text.Length > 0)
            {
                try
                {

                    rg.ThemNhom(txtTaiKhoan.Text, txtMatkhau.Text, txtRematkhau.Text);
                    gridControl2.DataSource = rg.getNhomNguoiDung();
                    MessageBox.Show("Thêm Nhóm Thành Công");
                }
                catch
                {
                    MessageBox.Show("Thêm Nhóm Thất Bại");
                }

            }
            else
            {
                MessageBox.Show("Vui Lòng Nhập Mã Nhóm Và Tên Nhóm ");

            }
        }

        private void btnSuaNhom_Click(object sender, EventArgs e)
        {
            string manhom = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, MaNhom).ToString();
            string tennhom = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, TenNhom).ToString();
            string ghichu = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, GhiChu).ToString();

            if (rg.SuaNhomNguoidung(manhom, tennhom,ghichu))
            {
                MessageBox.Show("Sua Thanh Cong");
                gridControl1.DataSource = rg.getNhomNguoiDung();

            }
            else
            {
                MessageBox.Show("Sua That Bai");

            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            gridControl4.DataSource = rg.getNDNhomNDtheomaNhom(comboBox1.SelectedValue.ToString());
        }

        private void simpleButton1_Click_1(object sender, EventArgs e)
        {
            string a = "";
            
                a =gridView3.GetRowCellValue(gridView3.FocusedRowHandle, TDN).ToString();
            



                if (rg.ThemNguoiDungVaoNhom(a, comboBox1.SelectedValue.ToString(), ""))
                {
                    MessageBox.Show("Thêm Người Dùng Vào Nhóm Thành Công");
                    gridControl4.Refresh();
                }
                else
                {
                    MessageBox.Show("Thêm Người Dùng Vào Nhóm Thất Bại");
                }    
           
           
           

        }
      
        private void simpleButton2_Click_1(object sender, EventArgs e)
        {
            string a = "";
            
            try
            {
                 a = gridView4.GetRowCellValue(gridView4.FocusedRowHandle, TenDangNhap1).ToString();
             //   b = gridView4.GetRowCellValue(gridView4.FocusedRowHandle, MaNhomNguoiDung).ToString();
            }
            catch(Exception ex)
            {
              
                MessageBox.Show("Tài Khoản Không Tồn Tai");

            }
            
                if (rg.XoaNguoiDungKhoiNhom(a,comboBox1.SelectedValue.ToString()))
                {
                    MessageBox.Show("Xoa Thanh Cong");

                }
                else
                {
                    MessageBox.Show("Xoa That Bai");
                }
            
             
               
           
            
            
        }

        private void gridControl4_Click(object sender, EventArgs e)
        {

        }

        private void gridControl3_Click(object sender, EventArgs e)
        {

        }

        private void gridControl5_Click(object sender, EventArgs e)
        {
            


        }

        private void gridView5_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            string manhom = gridView5.GetRowCellValue(gridView5.FocusedRowHandle, MaNhom2).ToString();
            rg.loadPQ(gridControl6,manhom);
      
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {

        }

        private void btnDelte_Click(object sender, EventArgs e)
        {

        }
    }
}