namespace Code_Final_Object.CSFile
{
    public class Name
    {
        // Fields
        private string FirstName;
        private string LastName;
        // Properties
        public string firstname
        {
            get { return this.FirstName; }
            set { this.FirstName = value; }
        }
        public string lastname
        {
            get { return this.LastName; }
            set { this.LastName = value; }
        }
        // Methods
        public Name(string FirstName, string LastName)
        {
            this.firstname = FirstName;
            this.lastname = LastName;
        }
    }
}
