namespace EnglishCentreManagement.Model
{
    public class Enterprise_Infor
    {
        // Fields - Information that's used in organization
        private string id;
        private string title;
        private string email;
        private string userName;
        private string password;
        // Properties 
        public string ID
        {
            get { return this.id; }
            set { this.id = value; }
        }
        public string Title
        {
            get { return this.title; }
            set { this.title = value; }
        }
        public string Email
        {
            get { return this.email; }
            set { this.email = value; }
        }
        public string UserName
        {
            get { return this.userName; }
            set { this.userName = value; }
        }
        public string Password
        {
            get { return this.password; }
            set { this.password = value; }
        }
        // Finalizers
        ~Enterprise_Infor() { }
        //Methods
        public Enterprise_Infor(string ID, string Title, string Email, string UserName, string Password)
        {
            this.ID = ID;
            this.Title = Title;
            this.Email = Email;
            this.UserName = UserName;
            this.Password = Password;
        }
    }
}
