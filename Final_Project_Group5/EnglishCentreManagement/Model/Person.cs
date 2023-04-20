using System;

namespace EnglishCentreManagement.Model
{
    public class Person
    {
        private Enterprise_Infor enter_Infor = new Enterprise_Infor();
        private string namePerson;
        private DateOnly dateBorn; 
        private string gender;
        private string address;
        private string? phoneNum;
        private string identityCard;
        private string? bankNumber;

        public Enterprise_Infor Enter_Infor { get => enter_Infor; set => enter_Infor = value; }
        public string NamePerson { get => namePerson; set => namePerson = value; }
        public DateOnly DateBorn { get => dateBorn; set => dateBorn = value; }
        public string Gender { get => gender; set => gender = value; }
        public string Address { get => address; set => address = value; }
        public string PhoneNum { get => phoneNum; set => phoneNum = value; }
        public string IdentityCard { get => identityCard; set => identityCard = value; }
        public string? BankNumber { get => bankNumber; set => bankNumber=value; }

        public Person() { }

        public Person(Enterprise_Infor Enter_Infor, string NamePerson, DateOnly DateBorn, string Gender, string Address, string PhoneNum, string IdentityCard, string BankNumber)
        {
            this.Enter_Infor = Enter_Infor;
            this.NamePerson = NamePerson;
            this.DateBorn = DateBorn;
            this.Gender = Gender;
            this.Address = Address;
            this.PhoneNum = PhoneNum;
            this.IdentityCard = IdentityCard;
            this.BankNumber = BankNumber;
        }

        public Person(string Enter_Infor_ID, string NamePerson, DateOnly DateBorn, string Gender, string Address, string PhoneNum, string IdentityCard, string BankNumber)
        {
            this.Enter_Infor.ID = Enter_Infor_ID;
            this.NamePerson = NamePerson;
            this.DateBorn = DateBorn;
            this.Gender = Gender;
            this.Address = Address;
            this.PhoneNum = PhoneNum;
            this.IdentityCard = IdentityCard;
            this.BankNumber = BankNumber;
        }

    }
}
