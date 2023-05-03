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
    public class ResultDAO : IResultDAO
    {
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.connStr);

        public List<TestResult> getResultByIdTest(string idTest)
        {
            string sqlStr = string.Format("SELECT * FROM RESULT WHERE MaBaiKiemTra = '{0}'", idTest);
            DataTable dt = DBConnection.getData(conn, sqlStr);
            List<TestResult> listTst = new List<TestResult>();
            foreach (DataRow dr in dt.Rows)
            {
                TestResult rsl = new TestResult 
                { 
                    IdTest = new string(Convert.ToString(dr["MaBaiKiemTra"])),
                    IdStudent = new string(Convert.ToString(dr["MaHocVien"])),
                    Point = Convert.ToDouble(dr["Diem"])
                };
                if (rsl != null)
                    listTst.Add(rsl);
            }
            return listTst;
        }

        public void UpdateTestResultByList(List<TestResult> results)
        {
            string sqlStr;
            foreach(TestResult rsl in results)
            {
                sqlStr = string.Format("UPDATE RESULT SET Diem = '{0}' WHERE MaBaiKiemTra = '{1}' and MaHocVien = '{2}'", rsl.Point, rsl.IdTest, rsl.IdStudent);
                DBConnection.Execute(conn,sqlStr);
            }
        }
    }
}
