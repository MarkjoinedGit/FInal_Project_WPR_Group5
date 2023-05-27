using EnglishCentreManagement.Interfaces;
using EnglishCentreManagement.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using System.Windows;

namespace EnglishCentreManagement.Database
{
    public class FinalResultDAO:IFinalResultDAO
    {
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.connStr);
        public void Add(FinalResult finalResult)
        {
            string sqlStr = String.Format("INSERT INTO FINALRESULT VALUES ('{0}','{1}','{2}','{3}','{4}','{5}')", finalResult.IdClassroom, finalResult.IdStudent, finalResult.DiemQuaTrinh, finalResult.DiemCuoiKi, finalResult.DiemTongKet, finalResult.LenLop.GetHashCode());
            DBConnection.Execute(conn,sqlStr);
        }
        public void Update(FinalResult finalResult)
        {
            string sqlStr = String.Format("UPDATE FINALRESULT SET MaHocVien='{1}',DiemQuaTrinh='{2}',DiemCuoiKy='{3}',DiemTongKet='{4}',LenLop='{5}' WHERE Malop='{0}'", finalResult.IdClassroom, finalResult.IdStudent, finalResult.DiemQuaTrinh, finalResult.DiemCuoiKi, finalResult.DiemTongKet, finalResult.LenLop.GetHashCode());
            DBConnection.Execute(conn,sqlStr);
        }
        public void Delete(FinalResult finalResult)
        {
            string sqlStr = String.Format("DELETE FROM FINALRESULT WHERE Malop='{0}'", finalResult.IdClassroom);
            DBConnection.Execute(conn,sqlStr);
        }
        public List<FinalResult> GetListAllByIdClassroom(string IdClass)
        {
            List<FinalResult > list = new List<FinalResult>();
            string sqlStr = String.Format("SELECT * FROM FINALRESULT WHERE MaLop='{0}'", IdClass);
            DataTable dt=DBConnection.getData(conn,sqlStr);
            if(dt.Rows.Count > 0 && IdClass!=null) 
            {
                foreach(DataRow dr in dt.Rows) 
                {
                    list.Add(new FinalResult
                    {
                        IdClassroom = new string(dr["MaLop"].ToString()),
                        IdStudent = new string(dr["MaHocVien"].ToString()),
                        DiemQuaTrinh = Convert.ToDouble(dr["DiemQuaTrinh"]),
                        DiemCuoiKi = Convert.ToDouble(dr["DiemCuoiKy"]),
                        DiemTongKet = Convert.ToDouble(dr["DiemTongKet"]),
                        LenLop = Convert.ToBoolean(dr["LenLop"])
                    });
                }
            }
            return list;
        }
        public double GraduateRate(Teacher teacher)
        {
            string sqlStr = string.Format("select * from FINALRESULT, LOPHOC WHERE FINALRESULT.MaLop=LOPHOC.MaLop AND MaGiaoVien='{0}'",teacher.Enter_Infor.ID);
            DataTable dt=DBConnection.getData(conn,sqlStr);
            if (dt.Rows.Count <= 0) return 0.0;
            int count = 0;
            foreach(DataRow dr in dt.Rows) 
            {
                if (Convert.ToBoolean(dr["LenLop"]) == true)
                {
                    count++;
                }
            }
            return (double)count/(dt.Rows.Count);
        }
    }
}
