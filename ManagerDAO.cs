using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnglishCentreManagement.Model;
using System.Data;
using System.Data.SqlClient;
namespace EnglishCentreManagement.Database
{
    public class ManagerDAO
    {
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.connStr);
        public void Them(SqlConnection conn, Manager Mger)
        {
            string str = string.Format("INSERT INTO NGQUANLY(TenNguoiQuanLy , MaNguoiQuanLy , NgaySinh, DiaChi, SoDienThoai, Email, ChungMinhNhanDan)" + " VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}')", Mger.nameperson, Mger.enterprise_infor.id, Mger.dateborn, Mger.address, Mger.phonenum, Mger.enterprise_infor.email, Mger.identitycard);
            DBConnection.ThucThi(conn, str);
        }
        public void Xoa(SqlConnection conn, Manager Mger)
        {
            string str = string.Format("DELETE FROM NGQUANLY WHERE MaNguoiQuanLy = '{0}')", Mger.enterprise_infor.id);
            DBConnection.ThucThi(conn, str);
        }
        public void Sua(SqlConnection conn, Manager Mger)
        {
            string str = string.Format("UPDATE NGQUANLY SET TenNguoiQuanLy = '{0}', MaNguoiQuanLy = '{1}', NgaySinh = '{2}', DiaChi = '{3}', SoDienThoai ='{4}', Email = '{5}', ChungMinhNhanDan ='{6}' WHERE  MaHocSinh = '{7}'", Mger.nameperson, Mger.enterprise_infor.id, Mger.dateborn, Mger.address, Mger.phonenum, Mger.enterprise_infor.email, Mger.identitycard, Mger.enterprise_infor.id);
            DBConnection.ThucThi(conn, str);
        }
    }
}
