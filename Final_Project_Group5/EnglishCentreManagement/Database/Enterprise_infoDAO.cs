using EnglishCentreManagement.Interfaces;
using EnglishCentreManagement.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

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
            string sqlStr = string.Format("SELECT* FROM DANGNHAP WHERE TenDangNhap = '{0}' AND MatKhau = '{1}'", Username, Password);
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

        public Enterprise_Infor? getById(string id)
        {
            string sqlStr = string.Format("SELECT* FROM DANGNHAP WHERE MaNguoiDangNhap = '{0}'", id);
            try
            {
                DataTable dtUser = DBConnection.getData(conn, sqlStr);
                return new Enterprise_Infor
                {
                    ID = dtUser.Rows[0]["MaNguoiDangNhap"].ToString(),
                    Title = dtUser.Rows[0]["ChucVu"].ToString(),
                    Email = dtUser.Rows[0]["Email"].ToString(),
                    UserName = dtUser.Rows[0]["TenDangNhap"].ToString(),
                    Password = dtUser.Rows[0]["MatKhau"].ToString()
                };
            }

            catch
            {
                MessageBox.Show("Null data");
            }

            return null;
        }

        public Enterprise_Infor getByUserName(string Username, string Password)
        {
            string sqlStr = string.Format("SELECT* FROM DANGNHAP WHERE TenDangNhap = '{0}' AND MatKhau = '{1}'", Username, Password);
            try
            {
                DataTable dtUser = DBConnection.getData(conn, sqlStr);
                return new Enterprise_Infor
                {
                    ID = dtUser.Rows[0]["MaNguoiDangNhap"].ToString(),
                    Title = dtUser.Rows[0]["ChucVu"].ToString(),
                    Email = dtUser.Rows[0]["Email"].ToString(),
                    UserName = dtUser.Rows[0]["TenDangNhap"].ToString(),
                    Password = dtUser.Rows[0]["MatKhau"].ToString()
                };
            }

            catch
            {
                MessageBox.Show("Null data");
            }

            return null;
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
