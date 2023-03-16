using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnglishCentreManagement.Model;

namespace EnglishCentreManagement.Database
{
    public class StudentDAO
    {
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.connStr);
        public void Them(SqlConnection conn, Student Stu)
        {
            string str = string.Format("INSERT INTO HOCSINH(TenHocSinh , MaHocSinh , NgaySinh, DiaChi, SoDienThoai, ChungMinhNhanDan)" + " VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}')", Stu.nameperson, Stu.enterprise_infor.id, Stu.dateborn, Stu.address, Stu.phonenum,  Stu.identitycard);
            DBConnection.ThucThi(conn, str);
        }
        public void Xoa(SqlConnection conn, Student Stu)
        {
            string str = string.Format("DELETE FROM HOCSINH  WHERE MaHocSinh = '{0}')", Stu.enterprise_infor.id);
            DBConnection.ThucThi(conn, str);
        }
        public void Sua(SqlConnection conn, Student Stu)
        {
            string str = string.Format("UPDATE HOCSINH SET TenHocSinh = '{0}', MaHocSinh = '{1}', NgaySinh = '{2}', DiaChi = '{3}', SoDienThoai ='{4}', ChungMinhNhanDan ='{5}' WHERE  MaHocSinh = '{6}'", Stu.nameperson, Stu.enterprise_infor.id, Stu.dateborn, Stu.address, Stu.phonenum, Stu.identitycard, Stu.enterprise_infor.id);
            DBConnection.ThucThi(conn, str);
        }
    }
}
