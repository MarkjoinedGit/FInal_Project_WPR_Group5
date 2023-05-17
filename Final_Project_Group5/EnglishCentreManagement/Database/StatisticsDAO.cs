using EnglishCentreManagement.ENUM;
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
    public class StatisticsDAO : IStatisticsDao
    {
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.connStr);

        public Statistics CreateStatistics(string idTeacher)
        {
            Statistics stat = new Statistics();
            string strSql = string.Format("SELECT * FROM LOPHOC WHERE MaGiaoVien = '{0}'", idTeacher);
            DataTable dtLH = DBConnection.getData(conn, strSql);
            stat.NumberOfClass = dtLH.Rows.Count;

            foreach(DataRow dr in dtLH.Rows)
            {
                strSql = string.Format("SELECT count(MaHocVien) SLHV FROM HocVienTrongLop WHERE MaLop = '{0}'", new string(dr["MaLop"].ToString()));
                DataTable dtSub = DBConnection.getData(conn, strSql);
                stat.NumberOfStudent+=Convert.ToInt32(dtSub.Rows[0]["SLHV"]);
            }

            if (stat.GraduateRate > 0.9)
                stat.Evaluation = EVALUTE.Excellent;            
            else if (stat.GraduateRate > 0.5)
                stat.Evaluation = EVALUTE.Good;
            else
                stat.Evaluation = EVALUTE.Medium;

            return stat;
        }
    }
}
