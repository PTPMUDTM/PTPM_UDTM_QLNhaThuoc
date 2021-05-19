using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraGrid;
using BLL_DAL1.DataSet1TableAdapters;

namespace BLL_DAL1
{
   public class RegisterBLLDAL
    {
        QLNhaThuocDataContext QLNT = new QLNhaThuocDataContext();
        public void ThemTK(string tk, string mk,Boolean hd)
        {
            
                NGUOIDUNG nd = new NGUOIDUNG();
                nd.TENDN = tk;
                nd.MATKHAU = mk;
                nd.HOATDONG = hd;
               
                QLNT.NGUOIDUNGs.InsertOnSubmit(nd);
                QLNT.SubmitChanges();
        }
        public void ThemNhom(string manhom, string tennhom, string ghichu)
        {

            NHOMNGUOIDUNG nd = new NHOMNGUOIDUNG();
            nd.MANHOM = manhom;
            nd.TENNHOM = tennhom;
            nd.GHICHU = ghichu;

            QLNT.NHOMNGUOIDUNGs.InsertOnSubmit(nd);
            QLNT.SubmitChanges();
        }
        public bool DoiMatKhau(string tk, string mkcu, string mkmoi)
        {
            try
            {
                NGUOIDUNG nd = new NGUOIDUNG();
                nd = QLNT.NGUOIDUNGs.Where(t => t.TENDN == tk).Single();
                nd = QLNT.NGUOIDUNGs.Where(t => t.MATKHAU == mkcu).Single();
                if (nd != null)
                {
                    nd.MATKHAU = mkmoi;


                    QLNT.SubmitChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
            
        }
        public bool SuaTaiKhoan(string tk, string mk,bool hoatdong)
        {

            NGUOIDUNG nd = new NGUOIDUNG();
            nd = QLNT.NGUOIDUNGs.Where(t => t.TENDN == tk).FirstOrDefault();
          
            if (nd != null)
            {
             
                nd.MATKHAU = mk;
                nd.HOATDONG = hoatdong;
                QLNT.SubmitChanges();


                return true;
            }
            else
            {
                return false;
            }

        }
        public bool SuaNhomNguoidung(string manhom, string tennhom, string ghichu)
        {

            NHOMNGUOIDUNG nd = new NHOMNGUOIDUNG();
            nd = QLNT.NHOMNGUOIDUNGs.Where(t => t.MANHOM== manhom).FirstOrDefault();

            if (nd != null)
            {

                nd.TENNHOM= tennhom;
                nd.GHICHU =ghichu;
                QLNT.SubmitChanges();


                return true;
            }
            else
            {
                return false;
            }

        }
        public bool XoaTaiKhoan(string tk)
        {
            NGUOIDUNG nd = new NGUOIDUNG();
            if(tk!=null)
            {
                try
                {
                    nd = QLNT.NGUOIDUNGs.Where(t => t.TENDN == tk).FirstOrDefault();
                    QLNT.NGUOIDUNGs.DeleteOnSubmit(nd);
                    QLNT.SubmitChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }    
            else
            {
                return false;
            }
        }
        public bool XoaNhom(string manhom)
        {
            NHOMNGUOIDUNG nnd= new NHOMNGUOIDUNG();
            if (manhom != null)
            {
                try
                {
                    nnd = QLNT.NHOMNGUOIDUNGs.Where(t => t.MANHOM == manhom).FirstOrDefault();
                    QLNT.NHOMNGUOIDUNGs.DeleteOnSubmit(nnd);

                    QLNT.SubmitChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public List<NGUOIDUNG> getNguoiDung()
        {
           
            return QLNT.NGUOIDUNGs.Select(k => k).ToList<NGUOIDUNG>();
        }
        public List<NHOMNGUOIDUNG> getNhomNguoiDung()
        {

            return QLNT.NHOMNGUOIDUNGs.Select(k => k).ToList<NHOMNGUOIDUNG>();
        }
        public DataGridView getNND1()
        {
            DataGridView dt = new DataGridView();
            dt.Refresh();
            var list = from p in QLNT.NHOMNGUOIDUNGs
                       select p;
            
            
            dt.DataSource = list;
            return dt;
        }
       public IQueryable<QL_NGUOIDUNGNHOMNGUOIDUNG> getNDNhomNDtheomaNhom(string manhom)
        {
            return QLNT.QL_NGUOIDUNGNHOMNGUOIDUNGs.Where(t => t.MANHOM == manhom);
        }

        public bool ThemNguoiDungVaoNhom(string tk,string manhom,string ghichu)
        {
           
            try
            {
                QL_NGUOIDUNGNHOMNGUOIDUNG nnd = new QL_NGUOIDUNGNHOMNGUOIDUNG();
                nnd.TENDN = tk;
                nnd.MANHOM = manhom;
                nnd.GHICHU = ghichu;
                QLNT.QL_NGUOIDUNGNHOMNGUOIDUNGs.InsertOnSubmit(nnd);
                QLNT.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }

           
        }
        public bool XoaNguoiDungKhoiNhom(string tk,string mk)
        {
           QL_NGUOIDUNGNHOMNGUOIDUNG nd = new QL_NGUOIDUNGNHOMNGUOIDUNG();
            if(tk!=null)
            {
                try
                {
                    nd = QLNT.QL_NGUOIDUNGNHOMNGUOIDUNGs.Where(t => t.TENDN == tk&&t.MANHOM==mk).FirstOrDefault();
                  
                    QLNT.QL_NGUOIDUNGNHOMNGUOIDUNGs.DeleteOnSubmit(nd);
                    QLNT.SubmitChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }    
            else
            {
                return false;
            }    

        }

        public IQueryable<PHANQUYEN> getManHinh()
        {
            return QLNT.PHANQUYENs.Select(k => k);
        }
        public IQueryable<QL_NGUOIDUNGNHOMNGUOIDUNG> getNDNND(string tendn)
        {
            return QLNT.QL_NGUOIDUNGNHOMNGUOIDUNGs.Where(k => k.TENDN==tendn);
        }
        public GridControl getPhanQuyen(string manhomND)
        {
            var pq = (from ph in QLNT.PHANQUYENs
                     join c in QLNT.MANHINHs on ph.MAMH equals c.MAMH
                      where ph.MANHOM == manhomND
                     select new
                     {
                         c.MAMH,
                         c.TENMH,
                         ph.COQUYEN

                     }).ToList();
            GridControl dt = new GridControl();
            dt.DataSource = pq;
            return dt;
        }

        // test
        public void loadPQ(GridControl ctrol, string manhomND)
        {
            var pq = (from ph in QLNT.PHANQUYENs
                      join c in QLNT.MANHINHs on ph.MAMH equals c.MAMH
                      where ph.MANHOM == manhomND
                      select new
                      {
                          c.MAMH,
                          c.TENMH,
                          ph.COQUYEN
                      }).ToList();

            ctrol.DataSource = pq;
        }
        public bool KiemTraKhoaChinhTenDangNhap(string tendangnhap)
        {
            NGUOIDUNG nd = new NGUOIDUNG();
            
                nd = QLNT.NGUOIDUNGs.Where(t => t.TENDN == tendangnhap).FirstOrDefault();
            
           
            if(nd!=null)
            {
                return true;
            }
            else
            {
                return false;
            }

           
        }
        public List<String> getMaNhomNguoiDung(string tendn)
        {
           
            List<string> kqMNND = new List<string>();
             QL_NGUOIDUNGNHOMNGUOIDUNGTableAdapter da = new QL_NGUOIDUNGNHOMNGUOIDUNGTableAdapter();

            DataTable dtlq = da.GetDataByDSNND(tendn);                  
         
            for(int i = 0; i < dtlq.Rows.Count;i++)
            {
                kqMNND.Add(dtlq.Rows[i].ItemArray[1].ToString());
            }

            return kqMNND;
        }
        public DataTable getMaManHinh(string MaNND)
        {          
            PHANQUYENTableAdapter da = new PHANQUYENTableAdapter();
            return da.GetDataByDSMH(MaNND);
        }
    }


}
