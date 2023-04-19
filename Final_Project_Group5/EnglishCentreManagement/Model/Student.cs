using System;

namespace EnglishCentreManagement.Model
{
    public class Student : Person
    {
        private double rankLevel;

        public double RankLevel { get => rankLevel; set => rankLevel=value; }

        public Student(Enterprise_Infor Enter_Infor, string NamePerson, DateTime DateBorn, string Gender, string Address, string PhoneNum, string IdentityCard, string BankNumber, double RankLevel) : base(Enter_Infor, NamePerson, DateBorn, Gender, Address, PhoneNum, IdentityCard, BankNumber)
        {
            this.RankLevel = RankLevel;
        }

        public Student(string Enter_Infor_ID, string NamePerson, DateTime DateBorn, string Gender, string Address, string PhoneNum, string IdentityCard, string BankNumber, double RankLevel) : base(Enter_Infor_ID, NamePerson, DateBorn, Gender, Address, PhoneNum, IdentityCard, BankNumber)
        {
            this.RankLevel = RankLevel;
        }
    }
}
