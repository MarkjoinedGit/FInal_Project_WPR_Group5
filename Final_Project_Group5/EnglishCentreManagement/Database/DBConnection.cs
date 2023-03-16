using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EnglishCentreManagement.Database
{
    public class DBConnection
    {
        public static SqlConnection conn
        {
            get; set;
        }

        private static DBConnection ins;
        public static DBConnection Ins
        {
            get
            {
                if(ins == null)
                    ins = new DBConnection();
                return ins;
            }
            set { ins = value; }
        }

        private DBConnection()
        {
             conn = new SqlConnection(Properties.Settings.Default.connStr);
            //DBConnection.ins.conn
        }

        public static DataTable getData(string sqlStr)
        {
            try
            {
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(sqlStr, conn);
                DataTable dtSinhVien = new DataTable();
                adapter.Fill(dtSinhVien);

                return dtSinhVien;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            finally
            {
                conn.Close();
            }
#pragma warning disable CS8603 // Possible null reference return.
            return null;
#pragma warning restore CS8603 // Possible null reference return.
        }

        public static void ThucThi(string sqlStr)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sqlStr, conn);
                if (cmd.ExecuteNonQuery()>0)
                {
                    MessageBox.Show("Thuc thi thanh cong");

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Thuc thi that bai" + ex);
            }

            finally
            {
                conn.Close();
            }
        }
    }
}
