using System;

namespace EnglishCentreManagement.Model
{
    public class Manager : Person
    {
        public Manager(Enterprise_Infor enterprise_Infor, Name namePerson, string phoneNum, string gender, string identityCard, string address, DateTime dateBorn)
            : base(enterprise_Infor, namePerson, phoneNum, gender, identityCard, address, dateBorn)
        { }
    }
}
