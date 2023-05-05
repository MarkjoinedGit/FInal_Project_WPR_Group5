using EnglishCentreManagement.Interfaces;
using EnglishCentreManagement.Model;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace EnglishCentreManagement.Database
{
    public class TeacherDAO : ITeacherDao
    {
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.connStr);
        IEnterprise_infoDAO enterprise_InfoDAO = new Enterprise_infoDAO();

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

        public Teacher getByID(string id)
        {
            string sqlStr = string.Format("SELECT* FROM GIAOVIEN WHERE MaGiaoVien = '{0}'", id);
            try
            {
                DataTable dtUser = DBConnection.getData(conn, sqlStr);
                return new Teacher
                {
                    Enter_Infor = enterprise_InfoDAO.getById(new string(dtUser.Rows[0]["MaGiaoVien"].ToString())),
                    NamePerson = new string (dtUser.Rows[0]["TenGiaoVien"].ToString()),
                    DateBorn = new DateTime(Convert.ToDateTime(dtUser.Rows[0]["NgaySinh"]).Year, Convert.ToDateTime(dtUser.Rows[0]["NgaySinh"]).Month, Convert.ToDateTime(dtUser.Rows[0]["NgaySinh"]).Day),
                    Gender = new string(dtUser.Rows[0]["GioiTinh"].ToString()),
                    Address = new string(dtUser.Rows[0]["DiaChi"].ToString()),
                    PhoneNum = new string(dtUser.Rows[0]["SoDienThoai"].ToString()),
                    IdentityCard = new string(dtUser.Rows[0]["ChungMinhNhanDan"].ToString()),
                    BankNumber = new string(dtUser.Rows[0]["SoTaiKhoan"].ToString()),
                    RankLevel = Convert.ToDouble(dtUser.Rows[0]["RankLevel"])
                };
            }
            catch { }

            return new Teacher();
        }
    }
}
