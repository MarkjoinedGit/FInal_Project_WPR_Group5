using EnglishCentreManagement.Model;
using System.Data.SqlClient;

namespace EnglishCentreManagement.Database
{
    public class TeacherDAO
    {
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.connStr);
        public void Them(Teacher Tea)
        {
            string str = string.Format("INSERT INTO GIAOVIEN VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}')", Tea.Enter_Infor.ID,  Tea.NamePerson,  Tea.DateBorn, Tea.Gender, Tea.Address, Tea.PhoneNum, Tea.IdentityCard);
            DBConnection.ThucThi(conn, str);
        }
        public void Xoa(Teacher Tea)
        {
            string str = string.Format("DELETE FROM GIAOVIEN  WHERE MaGiaoVien = '{0}')", Tea.Enter_Infor.ID);
            DBConnection.ThucThi(conn, str);
        }
        public void Sua(Teacher Tea)
        {
            string str = string.Format("UPDATE GIAOVIEN SET TenGiaoVien = '{0}', NgaySinh = '{1}', GioiTinh = '{2}', DiaChi = '{3}', SoDienThoai ='{4}' ChungMinhNhanDan ='{5}' WHERE MaGiaoVien = '{6}'", Tea.NamePerson, Tea.DateBorn, Tea.Gender, Tea.Address, Tea.PhoneNum, Tea.IdentityCard, Tea.Enter_Infor.ID);
            DBConnection.ThucThi(conn, str);
        }
    }
}
