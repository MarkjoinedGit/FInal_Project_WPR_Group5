using System;
using System.Windows;

namespace EnglishCentreManagement.Model
{
    public class Teacher : Person
    {
        private long? salary;

        public long? Salary { get => salary; set => salary=value; }

        public Teacher() { }

        public Teacher(Enterprise_Infor Enter_Infor, string NamePerson, DateOnly DateBorn, string Gender, string Address, string PhoneNum, string IdentityCard, string BankNumber, double RankLevel)
            : base(Enter_Infor, NamePerson, DateBorn, Gender, Address, PhoneNum, IdentityCard, BankNumber, RankLevel) { }

        public Teacher(string Enter_Infor_ID, string NamePerson, DateOnly DateBorn, string Gender, string Address, string PhoneNum, string IdentityCard, string BankNumber, double RankLevel)
           : base(Enter_Infor_ID, NamePerson, DateBorn, Gender, Address, PhoneNum, IdentityCard, BankNumber, RankLevel) { }

    }
}
