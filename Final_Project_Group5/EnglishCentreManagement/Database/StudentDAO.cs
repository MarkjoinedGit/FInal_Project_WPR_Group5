using EnglishCentreManagement.Model;
using System.Data.SqlClient;

namespace EnglishCentreManagement.Database
{
    public class StudentDAO
    {
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.connStr);

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
    }
}
