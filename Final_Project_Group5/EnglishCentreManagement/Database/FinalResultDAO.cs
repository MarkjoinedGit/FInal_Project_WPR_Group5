using EnglishCentreManagement.Interfaces;
using EnglishCentreManagement.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishCentreManagement.Database
{
    public class FinalResultDAO : IFinalResultDAO
    {

        SqlConnection conn = new SqlConnection(Properties.Settings.Default.connStr);

        public FinalResult GetFinalResult(string idStudent, string idClassroom)
        {
            string sqlStr = string.Format("SELECT * FROM FINALRESULT WHERE MaHocVien = '{0}' AND MaLop = '{1}'", idStudent, idClassroom);
            DataTable dt = DBConnection.getData(conn, sqlStr);
            if (dt != null)
            {
                FinalResult result = new FinalResult
                {
                    IdStudent = new string(dt.Rows[0]["MaHocVien"].ToString()),
                    IdClassroom = new string(dt.Rows[0]["MaLop"].ToString()),
                    ProcessPoint = Convert.ToDouble(dt.Rows[0]["DiemQuaTrinh"]),
                    FinalTestPoint = Convert.ToDouble(dt.Rows[0]["DiemCuoiKy"]),
                    FinalPoint = Convert.ToDouble(dt.Rows[0]["DiemTongKet"]),
                    UpClass = Convert.ToBoolean(dt.Rows[0]["LenLop"])
                };

                return result;
            }
            return new FinalResult();
        }
    }
}
