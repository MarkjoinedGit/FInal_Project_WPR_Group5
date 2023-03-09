using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf_FinalProject_1._1.CSFile
{
    public class Enterprise_Infor
    {
        // Fields - Information that's used in organization
        private string sID;
        private string sTitle;
        private string sEmail;
        private string sNickName;
        private string sPassword;
        // Properties 
        public string ID
        {
            get { return sID; }
            set { sID = value; }
        }
        public string Title
        {
            get { return sTitle; }
            set { sTitle = value; }
        }
        public string Email
        {
            get { return sEmail; }
            set { sEmail = value; }
        }
        public string NickName
        {
            get { return sNickName; }
            set { sNickName = value; }
        }
        public string Password
        {
            get { return sPassword; }
            set { sPassword = value; }
        }
        // Finalizers
        ~Enterprise_Infor() { }
        //Methods
        public Enterprise_Infor(string ID, string Title, string Email, string NickName, string Password)
        {
            this.ID = ID;
            this.Title = Title;
            this.Email = Email;
            this.NickName = NickName;
            this.Password = Password;
        }
    }
}
