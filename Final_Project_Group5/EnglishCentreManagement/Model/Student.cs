using System;

namespace EnglishCentreManagement.Model
{
    class Student : Person
    {
        private string status;
        private string classID;
        private string rankLevel;
        public string Status
        {
            get { return this.status; }
            set { this.status = value; }
        }
        public string ClassID
        {
            get { return this.classID; }
            set { this.classID = value; }
        }
        private string RankLevel
        {
            get { return this.rankLevel; }
            set { this.rankLevel = value; }
        }
        ~Student() { }
        public Student(Enterprise_Infor Enter_Infor, Name NamePerson, string PhoneNum, string Gender,
            string IdentityCard, string Address, DateTime DateBorn, string Status, string RankLevel, string ClassID) : base(Enter_Infor, NamePerson, PhoneNum, Gender,
            IdentityCard, Address, DateBorn)
        {
            this.Status = status;
            this.RankLevel = RankLevel;
            this.ClassID = ClassID;
        }
    }
}
