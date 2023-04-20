using EnglishCentreManagement.Interfaces;
using EnglishCentreManagement.Model;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace EnglishCentreManagement.Database
{
    public class StudentDAO : IStudentDao
    {
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.connStr);
        Enterprise_infoDAO enterprise_InfoDAO = new Enterprise_infoDAO();

        public void Add(Student Stu)
        {
            string str = string.Format("INSERT INTO HOCSINH VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}')", Stu.Enter_Infor.ID, Stu.NamePerson, Stu.DateBorn, Stu.Gender, Stu.Address, Stu.PhoneNum, Stu.IdentityCard, Stu.BankNumber, Stu.RankLevel);
            DBConnection.Execute(conn, str);
        }

        public void Delete(Student Stu)
        {
            string str = string.Format("DELETE FROM HOCSINH WHERE MaHocVien = '{0}')", Stu.Enter_Infor.ID);
            DBConnection.Execute(conn, str);
        }

        public void Update(Student Stu)
        {
            string str = string.Format("UPDATE HOCSINH SET TenHocVien = '{0}', NgaySinh = '{1}', GioiTinh = '{2}', DiaChi = '{3}', SoDienThoai ='{4}', ChungMinhNhanDan ='{5}', SoTaiKhoan = '{6}', RankLevel = '{7}' WHERE  MaHocVien = '{8}'", Stu.NamePerson, Stu.DateBorn, Stu.Gender, Stu.Address, Stu.PhoneNum, Stu.IdentityCard, Stu.BankNumber, Stu.RankLevel, Stu.Enter_Infor.ID);
            DBConnection.Execute(conn, str);
        }

        public Student? getById(string id)
        {
            string sqlStr = string.Format("SELECT* FROM HOCVIEN WHERE MaHocVien = '{0}'", id);
            try
            {
                DataTable dtUser = DBConnection.getData(conn, sqlStr);
                return new Student
                {
                    Enter_Infor = enterprise_InfoDAO.getById(dtUser.Rows[0]["MaHocVien"].ToString()),
                    NamePerson = dtUser.Rows[0]["TenHocVien"].ToString(),
                    DateBorn = new DateOnly(Convert.ToDateTime(dtUser.Rows[0]["NgaySinh"]).Year, Convert.ToDateTime(dtUser.Rows[0]["NgaySinh"]).Month, Convert.ToDateTime(dtUser.Rows[0]["NgaySinh"]).Day),
                    Gender = dtUser.Rows[0]["GioiTinh"].ToString(),
                    Address = dtUser.Rows[0]["DiaChi"].ToString(),
                    PhoneNum = dtUser.Rows[0]["SoDienThoai"].ToString(),
                    IdentityCard = dtUser.Rows[0]["ChungMinhNhanDan"].ToString(),
                    BankNumber = dtUser.Rows[0]["SoTaiKhoan"].ToString(),
                    RankLevel = Convert.ToDouble(dtUser.Rows[0]["RankLevel"])
                };
            }

            catch
            {
                MessageBox.Show("Null data");
            }

            return null;
        }
    }
}
