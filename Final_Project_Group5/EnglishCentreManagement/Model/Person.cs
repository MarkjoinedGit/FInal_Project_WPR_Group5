namespace Code_Final_Object.CSFile
{
    public class Person
    {
        // Fields
        protected Enterprise_Infor Enter_Infor;
        // ... personal information
        protected Name NamePerson;
        protected string PhoneNum;
        protected string Gender;
        protected string IdentityCard;
        protected string PermanentResidence;
        protected string Address;
        protected DateTime DateBorn;
        // Properties
        public Enterprise_Infor enterprise_infor
        {
            get { return this.Enter_Infor; }
            set { this.Enter_Infor = value; }
        }
        public Name nameperson
        {
            get { return this.NamePerson; }
            set { this.NamePerson = value; }
        }
        public string phonenum
        {
            get { return this.PhoneNum; }
            set { this.PhoneNum = value; }
        }
        public string gender
        {
            get { return this.Gender; }
            set { this.Gender = value; }
        }
        public string identitycard
        {
            get { return this.IdentityCard; }
            set { this.IdentityCard = value; }
        }
        public string address
        {
            get { return this.Address; }
            set { this.Address = value; }
        }
        public DateTime dateborn
        {
            get { return this.DateBorn; }
            set { this.DateBorn = value; }
        }
        public Person(Enterprise_Infor enter_Infor, Name namePerson, string phoneNum, string gender,
            string identityCard, string address, DateTime dateBorn)
        {
            this.NamePerson = namePerson;
            this.gender = gender;
            this.IdentityCard = identityCard;
            this.Address = address;
            this.dateborn = dateBorn;
            this.phonenum = phoneNum;
        }
    }
}
