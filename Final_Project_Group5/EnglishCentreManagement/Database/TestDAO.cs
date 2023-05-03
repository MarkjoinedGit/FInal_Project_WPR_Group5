﻿using EnglishCentreManagement.Interfaces;
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
    public class TestDAO : ITestDAO
    {
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.connStr);

        public void Add(Test tst)
        {
            string sqlStr = string.Format("INSERT INTO TEST VALUES ('{0}', '{1}', '{2}', '{3}', '{4}')", tst.IDTest, tst.IDClassRoom, tst.TimeTesting, tst.DateTesting, tst.Description);
            DBConnection.Execute(conn, sqlStr);
        }

        public void DeleteTestByID(string idTest)
        {
            string sqlStr = string.Format("EXEC sp_XoaBaiKiem '{0}'", idTest);
            DBConnection.Execute(conn, sqlStr);
        }

        public Test? getTestByID(string idTest)
        {
            string sqlStr = string.Format("SELECT* FROM TEST WHERE MaBaiKiemTra = '{0}'", idTest);
            DataTable dt = DBConnection.getData(conn, sqlStr);
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                return new Test
                {
                    IDTest = new string(Convert.ToString(dr["MaBaiKiemTra"])),
                    IDClassRoom = new string(Convert.ToString(dr["MaLop"])),
                    TimeTesting = new string(Convert.ToString(dr["ThoiGian"])),
                    DateTesting = new DateTime(Convert.ToDateTime(dr["NgayKiemTra"]).Year, Convert.ToDateTime(dr["NgayKiemTra"]).Month, Convert.ToDateTime(dr["NgayKiemTra"]).Day),
                    Description = new string(Convert.ToString(dr["MoTa"]))
                };
            }
            return null;
        }

        public List<Test> getListByIDClass(string idClassroom)
        {
            string sqlStr = string.Format("SELECT MaBaiKiemTra FROM TEST WHERE MaLop = '{0}'", idClassroom);
            DataTable dt = DBConnection.getData(conn, sqlStr);
            List<Test> listTst = new List<Test>();
            foreach (DataRow dr in dt.Rows)
            {
                Test? tst = getTestByID(new string(Convert.ToString(dr["MaBaiKiemTra"])));
                if (tst != null)
                    listTst.Add(tst);
            }
            return listTst;
        }
    }
}
