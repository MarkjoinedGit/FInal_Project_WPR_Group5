using EnglishCentreManagement.Interfaces;
using EnglishCentreManagement.Model;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace EnglishCentreManagement.Database
{
    public class Enterprise_infoDAO : IEnterprise_infoDAO
    {
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.connStr);

        public void Add(Enterprise_Infor enterprise_Infor)
        {
            throw new System.NotImplementedException();
        }

        public bool AuthenticateEnterpriseInfor(string Username, string Password)
        {
            bool validUser;
            string sqlStr = string.Format("SELECT* FROM DANGNHAP WHERE TenDangNhap = '{0}' AND MatKhau = '{0}'", Username, Password);
            validUser = DBConnection.CheckValid(conn, sqlStr);
            return validUser;
        }

        public void Delete(Enterprise_Infor enterprise_Infor)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Enterprise_Infor> getAll()
        {
            throw new System.NotImplementedException();
        }

        public Enterprise_Infor getById(string id)
        {
            throw new System.NotImplementedException();
        }

        public Enterprise_Infor getByUserName(string userName)
        {
            throw new System.NotImplementedException();
        }

        public string getRole(string userName)
        {
            throw new System.NotImplementedException();
        }

        public void Update(Enterprise_Infor enterprise_Infor)
        {
            throw new System.NotImplementedException();
        }

        //public string getNameById(string id)
        //{
        //    string sqlStr = string.Format("SELECT* FROM HOCVIEN, GIANGVIEN, QUANLY")
        //}
    }
}
