using EnglishCentreManagement.Model;
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
    public class ShiftDAO
    {
        static SqlConnection conn = new SqlConnection(Properties.Settings.Default.connStr);

        public static Shift? findShiftByID(string id)
        {
            string strSQL = string.Format("SELECT * FROM CA WHERE MaCa = '{0}'", id);
            try
            {
                DataTable dtShift = DBConnection.getData(conn, strSQL);
                if (dtShift.Rows.Count > 0)
                {
                    DataRow dt = dtShift.Rows[0];

                    Shift course = new Shift
                    {
                        IDShift = dt["MaCa"].ToString(),
                        StartingTime = TimeSpan.Parse(dt["ThoiGianBatDau"].ToString()),
                        Endingtime = TimeSpan.Parse(dt["ThoiGianKetThuc"].ToString())
                };
                    return course;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cannot find the information of the teacher or " + ex.Message);
            }

            return null;

        }

        public static List<string> getAllShiftID()
        {
            string sqlStr = string.Format("Select MaCa From Ca");
            DataTable dtShift =  DBConnection.getData(conn, sqlStr);
            List<string> list = new List<string>();
            foreach(DataRow dr in dtShift.Rows)
            {
                list.Add(dr["MaCa"].ToString());    
            }

            return list;
        }
    }
}
