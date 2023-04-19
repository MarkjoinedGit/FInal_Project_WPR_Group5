using EnglishCentreManagement.Model;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace EnglishCentreManagement.Database
{
    public class TeacherDAO
    {
        static SqlConnection conn = new SqlConnection(Properties.Settings.Default.connStr);

        public void Add(Teacher Tea)
        {
            string strSQL = string.Format("INSERT INTO GIAOVIEN VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}')", Tea.Enter_Infor.ID,  Tea.NamePerson,  Tea.DateBorn, Tea.Gender, Tea.Address, Tea.PhoneNum, Tea.IdentityCard, Tea.BankNumber, Tea.RankLevel);
            DBConnection.Execute(conn, strSQL);
        }

        public void Delete(Teacher Tea)
        {
            string strSQL = string.Format("DELETE FROM GIAOVIEN  WHERE MaGiaoVien = '{0}')", Tea.Enter_Infor.ID);
            DBConnection.Execute(conn, strSQL);
        }

        public void Update(Teacher Tea)
        {
            string strSQL = string.Format("UPDATE GIAOVIEN SET TenGiaoVien = '{0}', NgaySinh = '{1}', GioiTinh = '{2}', DiaChi = '{3}', SoDienThoai ='{4}' ChungMinhNhanDan ='{5}', SoTaiKhoan = '{6}', RankLevel = '{7}' WHERE MaGiaoVien = '{8}'", Tea.NamePerson, Tea.DateBorn, Tea.Gender, Tea.Address, Tea.PhoneNum, Tea.IdentityCard, Tea.BankNumber, Tea.RankLevel, Tea.Enter_Infor.ID);
            DBConnection.Execute(conn, strSQL);
        }

        public static Teacher? findTeacherByID(string id)
        {
            string strSQL = string.Format("SELECT * FROM GIAOVIEN WHERE MaGiaoVien = '{0}'", id);
            try
            {
                DataTable dtTeacher = DBConnection.getData(conn, strSQL);
                if (dtTeacher.Rows.Count > 0)
                {
                    DataRow teacherRow = dtTeacher.Rows[0];
                    Teacher teacher = new Teacher(
                       teacherRow["MaGiaoVien"].ToString(),
                       teacherRow["TenGiaoVien"].ToString(),
                       Convert.ToDateTime(teacherRow["NgaySinh"]),
                       teacherRow["GioiTinh"].ToString(),
                       teacherRow["DiaChi"].ToString(),
                       teacherRow["SoDienThoai"].ToString(),
                       teacherRow["ChungMinhNhanDan"].ToString(),
                       teacherRow["SoTaiKhoan"].ToString(),
                       Convert.ToDouble(teacherRow["RankLevel"]));
                    return teacher;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cannot find the information of the teacher or " + ex.Message);
            }

            return null;

        }
    }
}
