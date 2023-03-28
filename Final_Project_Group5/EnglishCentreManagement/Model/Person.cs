using System;

namespace EnglishCentreManagement.Model
{
    public class Person
    {
        private Enterprise_Infor enter_Infor;
        // ... personal information
        private Name namePerson;
        private string phoneNum;
        private string gender;
        private string identityCard;
        private string permanentResidence;
        private string address;
        private DateTime dateBorn;

        public Enterprise_Infor Enter_Infor { get => enter_Infor; set => enter_Infor = value; }
        public Name NamePerson { get => namePerson; set => namePerson = value; }
        public string PhoneNum { get => phoneNum; set => phoneNum = value; }
        public string Gender { get => gender; set => gender = value; }
        public string IdentityCard { get => identityCard; set => identityCard = value; }
        public string PermanentResidence { get => permanentResidence; set => permanentResidence = value; }
        public string Address { get => address; set => address = value; }
        public DateTime DateBorn { get => dateBorn; set => dateBorn=value; }

        // Properties


        public Person(Enterprise_Infor Enter_Infor, Name NamePerson, string PhoneNum, string Gender,
            string IdentityCard, string Address, DateTime DateBorn)
        {
            this.Enter_Infor = Enter_Infor;
            this.NamePerson = NamePerson;
            this.PhoneNum = PhoneNum;
            this.Gender = Gender;
            this.IdentityCard = IdentityCard;
            this.Address = Address;
            this.DateBorn = DateBorn;

        }
    }
}
