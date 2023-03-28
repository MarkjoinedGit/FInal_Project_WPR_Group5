using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace EnglishCentreManagement.Database
{
    public class DBConnection
    {
        public static DataTable getData(SqlConnection conn, string sqlStr)
        {
            try
            {
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(sqlStr, conn);
                DataTable dttable = new DataTable();
                adapter.Fill(dttable);
                return dttable;
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

        public static void ThucThi(SqlConnection conn, string sqlStr)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sqlStr, conn);
                if (cmd.ExecuteNonQuery() > 0)
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
