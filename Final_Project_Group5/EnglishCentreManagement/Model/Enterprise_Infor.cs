namespace EnglishCentreManagement.Model
{
    public class Enterprise_Infor
    {
        // Fields - Information that's used in organization
        private string ID;
        private string Title;
        private string Email;
        private string NickName;
        private string Password;
        // Properties 
        public string id
        {
            get { return this.ID; }
            set { this.ID = value; }
        }
        public string title
        {
            get { return this.Title; }
            set { this.Title = value; }
        }
        public string email
        {
            get { return this.Email; }
            set { this.Email = value; }
        }
        public string nickname
        {
            get { return this.NickName; }
            set { this.NickName = value; }
        }
        public string password
        {
            get { return this.Password; }
            set { this.Password = value; }
        }
        // Finalizers
        ~Enterprise_Infor() { }
        //Methods
        public Enterprise_Infor(string ID, string Title, string Email, string NickName, string Password)
        {
            this.id = ID;
            this.title = Title;
            this.email = Email;
            this.nickname = NickName;
            this.password = Password;
        }
    }
}
