using EnglishCentreManagement.Model;
using System.Data.SqlClient;

namespace EnglishCentreManagement.Database
{
    public class ManagerDAO
    {
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.connStr);
        public void Add(Manager Mger)
        {
            string str = string.Format("INSERT INTO NGQUANLY VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}')", Mger.Enter_Infor.ID, Mger.NamePerson, Mger.DateBorn, Mger.Gender, Mger.Address, Mger.PhoneNum, Mger.IdentityCard, Mger.BankNumber);
            DBConnection.Execute(conn, str);
        }

        public void Delete(Manager Mger)
        {
            string str = string.Format("DELETE FROM NGQUANLY WHERE MaNguoiQuanLy = '{0}')", Mger.Enter_Infor.ID);
            DBConnection.Execute(conn, str);
        }

        public void Update(Manager Mger)
        {
            string str = string.Format("UPDATE NGQUANLY SET TenNguoiQuanLy = '{0}', NgaySinh = '{1}', GioiTinh = '{2}', DiaChi ='{3}', SoDienThoai = '{4}', ChungMinhNhanDan ='{5}', SoTaiKhoan = '{6}' WHERE  MaNguoiQuanLy = '{7}'", Mger.NamePerson, Mger.DateBorn, Mger.Gender, Mger.Address, Mger.PhoneNum, Mger.IdentityCard, Mger.BankNumber, Mger.Enter_Infor.ID);
            DBConnection.Execute(conn, str);
        }
    }
}
