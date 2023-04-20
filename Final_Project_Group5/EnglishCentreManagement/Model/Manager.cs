using System;

namespace EnglishCentreManagement.Model
{
    public class Manager : Person
    {
        public Manager() { }

        public Manager(Enterprise_Infor Enter_Infor, string NamePerson, DateOnly DateBorn, string Gender, string Address, string PhoneNum, string IdentityCard, string BankNumber)
            : base(Enter_Infor, NamePerson, DateBorn, Gender, Address, PhoneNum, IdentityCard, BankNumber)
        { }

        public Manager(string Enter_Infor_ID, string NamePerson, DateOnly DateBorn, string Gender, string Address, string PhoneNum, string IdentityCard, string BankNumber)
           : base(Enter_Infor_ID, NamePerson, DateBorn, Gender, Address, PhoneNum, IdentityCard, BankNumber)
        { }
    }
}
