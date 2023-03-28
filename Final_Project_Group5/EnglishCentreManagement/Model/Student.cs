using System;

namespace EnglishCentreManagement.Model
{
    public class Student : Person
    {
        private string status;
        private string classID;
        private string rankLevel;

        public string Status { get => status; set => status = value; }
        public string ClassID { get => classID; set => classID = value; }
        public string RankLevel { get => rankLevel; set => rankLevel=value; }

        public Student(Enterprise_Infor Enter_Infor, Name NamePerson, string PhoneNum, string Gender,
            string IdentityCard, string Address, DateTime DateBorn, string Status, string RankLevel, string ClassID) : base(Enter_Infor, NamePerson, PhoneNum, Gender,
            IdentityCard, Address, DateBorn)
        {
            this.Status = Status;
            this.RankLevel = RankLevel;
            this.ClassID = ClassID;
        }
    }
}
