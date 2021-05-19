using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;
namespace BLL_DAL1
{
   public static class XuLyDangNhap
   {
        public const int CONNECT_SUCCESS = 1;
        public const int CONNECT_FAIL = 0;
        public const int INACTIVE = 2;
        //return:
        //0: Empty connection string
        //1: Succeed to connect
        //2: Fail to connect

        public static int Check_Connection()
        {
            string cs = BLL_DAL1.Properties.Settings.Default.ConnectionString;
            if (string.IsNullOrEmpty(cs))
            {
                return 0;
            }
            try
            {
                SqlConnection conn = new SqlConnection(cs);
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                conn.Close();
                return 1;
            }
            catch { 
                return 2;
            }
        }
        
        public static int Try_Login(string user, string password)
        {
            SqlConnection conn = new SqlConnection(BLL_DAL1.Properties.Settings.Default.ConnectionString);
            SqlDataAdapter da = new SqlDataAdapter("select * from NguoiDung where TenDN ='"+user+"' and MatKhau='"+password+"'", conn);
            DataTable tbl = new DataTable();
            da.Fill(tbl);
            if (tbl.Rows.Count == 0)
            {
                return CONNECT_FAIL;
            }
            if (tbl.Rows[0][2].ToString() == "False")
            {
                return INACTIVE;
            }
            return CONNECT_SUCCESS;
        }

        public static DataTable Get_Server_Names()
        {
            return SqlDataSourceEnumerator.Instance.GetDataSources();
        }

        public static List<string> Get_Databases(string server, string user, string password)
        {
            List<string> list = new List<string>();
            string cs = "Data Source="+server+";Initial Catalog=master;User ID="+user+";Password="+password;
            SqlConnection con = new SqlConnection(cs);
            SqlDataAdapter da = new SqlDataAdapter("select name from sys.databases",con);
            DataTable table=new DataTable();
            try
            {
                da.Fill(table);
                for (int i = 0; i < table.Rows.Count; i++)
                    list.Add(table.Rows[i][0].ToString());
                return list;
            }
            catch
            {
                return list;
            }
        }

        public static void Change_Connection_String(string server, string user, string password, string database)
        {
            BLL_DAL1.Properties.Settings.Default.ConnectionString="Data Source=" + server + ";Initial Catalog="+database+";User ID=" + user + ";Password=" + password;
        }
   
    }
}
