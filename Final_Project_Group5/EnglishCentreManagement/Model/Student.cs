using System;

namespace EnglishCentreManagement.Model
{
    class Student : Person
    {
        private string Status;
        private string ClassID;
        private string RankLevel;
        public string status
        {
            get { return this.Status; }
            set { this.Status = value; }
        }
        public string classid
        {
            get { return this.ClassID; }
            set { this.ClassID = value; }
        }
        private string ranklevel
        {
            get { return this.RankLevel; }
            set { this.RankLevel = value; }
        }
        ~Student() { }
        public Student(Enterprise_Infor enter_Infor, Name namePerson, string phoneNum, string gender,
            string identityCard, string address, DateTime dateBorn, string status, string rank, string classid) : base(enter_Infor, namePerson, phoneNum, gender,
            identityCard, address, dateBorn)
        {
            this.ranklevel = rank;
            this.status = status;
            this.classid = classid;
        }
    }
}
