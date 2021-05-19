using DevExpress.XtraGrid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using BLL_DAL1.DataSet1TableAdapters;

namespace BLL_DAL1
{
  public  class QLThuoc
    {
        
        QLNhaThuocDataContext QLNT = new QLNhaThuocDataContext();
        public void LoadGridThuoc(GridControl grv)
        {
            var tuthuoc = from t in QLNT.Thuocs
                        select t;

            grv.DataSource = tuthuoc;
        }

        public IQueryable<Thuoc> GetGRVThuoc()
        {
            return QLNT.Thuocs.Select(t => t);
        }
        //public DataTable ALLThuoc()
        //{
        //    ThuocTableAdapter da = new ThuocTableAdapter();
        //    return da.GetDataByThuoc();
        //}
    }
}
