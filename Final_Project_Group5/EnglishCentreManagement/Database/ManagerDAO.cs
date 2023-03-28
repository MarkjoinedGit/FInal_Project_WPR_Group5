using EnglishCentreManagement.Model;
using System.Data.SqlClient;

namespace EnglishCentreManagement.Database
{
    public class ManagerDAO
    {
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.connStr);
        public void Them(Manager Mger)
        {
            string str = string.Format("INSERT INTO NGQUANLY VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}')", Mger.Enter_Infor.ID, Mger.NamePerson, Mger.DateBorn, Mger.Gender, Mger.Address, Mger.PhoneNum, Mger.IdentityCard);
            DBConnection.ThucThi(conn, str);
        }
        public void Xoa(Manager Mger)
        {
            string str = string.Format("DELETE FROM NGQUANLY WHERE MaNguoiQuanLy = '{0}')", Mger.Enter_Infor.ID);
            DBConnection.ThucThi(conn, str);
        }
        public void Sua(Manager Mger)
        {
            string str = string.Format("UPDATE NGQUANLY SET TenNguoiQuanLy = '{0}', NgaySinh = '{1}', GioiTinh = '{2}', DiaChi ='{3}', SoDienThoai = '{4}', ChungMinhNhanDan ='{5}' WHERE  MaNguoiQuanLy = '{6}'", Mger.NamePerson, Mger.DateBorn, Mger.Gender, Mger.Address, Mger.PhoneNum, Mger.IdentityCard, Mger.Enter_Infor.ID);
            DBConnection.ThucThi(conn, str);
        }
    }
}
