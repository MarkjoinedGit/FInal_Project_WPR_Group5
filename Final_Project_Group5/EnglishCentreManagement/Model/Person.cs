using System;

namespace EnglishCentreManagement.Model
{
    public class Person
    {
        // Fields
        protected Enterprise_Infor enter_Infor;
        // ... personal information
        protected Name namePerson;
        protected string phoneNum;
        protected string gender;
        protected string identityCard;
        protected string permanentResidence;
        protected string address;
        protected DateTime dateBorn;
        // Properties
        public Enterprise_Infor Enterprise_infor
        {
            get { return this.enter_Infor; }
            set { this.enter_Infor = value; }
        }
        public Name NamePerson
        {
            get { return this.namePerson; }
            set { this.namePerson = value; }
        }
        public string PhoneNum
        {
            get { return this.phoneNum; }
            set { this.phoneNum = value; }
        }
        public string Gender
        {
            get { return this.gender; }
            set { this.gender = value; }
        }
        public string IdentityCard
        {
            get { return this.identityCard; }
            set { this.identityCard = value; }
        }
        public string Address
        {
            get { return this.address; }
            set { this.address = value; }
        }
        public DateTime DateBorn
        {
            get { return this.dateBorn; }
            set { this.dateBorn = value; }
        }
        public Person(Enterprise_Infor Enter_Infor, Name NamePerson, string PhoneNum, string Gender,
            string IdentityCard, string Address, DateTime DateBorn)
        {
            this.Enterprise_infor = Enter_Infor;
            this.NamePerson = NamePerson;
            this.PhoneNum = PhoneNum;
            this.Gender = Gender;
            this.IdentityCard = IdentityCard;
            this.Address = Address;
            this.DateBorn = DateBorn;

        }
    }
}
