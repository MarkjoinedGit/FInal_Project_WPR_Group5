using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using EnglishCentreManagement.Model;

namespace EnglishCentreManagement.Database
{
    public class TeacherDAO
    {

        SqlConnection conn = new SqlConnection(Properties.Settings.Default.connStr);
        public void Them(SqlConnection conn, Teacher Tea)
        {
            string str = string.Format("INSERT INTO GIAOVIEN(TenGiaoVien , MaGiaoVien , NgaySinh, DiaChi, SoDienThoai, Email, ChungMinhNhanDan)" + " VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}')", Tea.nameperson, Tea.enterprise_infor.id, Tea.dateborn, Tea.address, Tea.phonenum, Tea.enterprise_infor.email, Tea.identitycard);
            DBConnection.ThucThi(conn, str);
        }
        public void Xoa(SqlConnection conn, Teacher Tea)
        {
            string str = string.Format("DELETE FROM GIAOVIEN  WHERE MaGiaoVien = '{0}')", Tea.enterprise_infor.id);
            DBConnection.ThucThi(conn, str);
        }
        public void Sua(SqlConnection conn, Teacher Tea)
        {
            string str = string.Format("UPDATE GIAOVIEN SET TenGiaoVien = '{0}', MaGiaoVien = '{1}', NgaySinh = '{2}', DiaChi = '{3}', SoDienThoai ='{4}', Email ='{5}' ChungMinhNhanDan ='{6}' WHERE  MaHocSinh = '{7}'", Tea.nameperson, Tea.enterprise_infor.id, Tea.dateborn, Tea.address, Tea.phonenum, Tea.enterprise_infor.email, Tea.identitycard, Tea.enterprise_infor.email);
            DBConnection.ThucThi(conn, str);
        }
    }
}
