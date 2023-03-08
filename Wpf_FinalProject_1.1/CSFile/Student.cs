using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf_FinalProject_1._1.CSFile
{
    class Student : Person
    {
        private string sStatus;
        private string sClassID;
        public string Status
        { get { return this.sStatus; } set { this.sStatus = value; } }
        public string ClassID
        { get { return this.sClassID; } set { this.sClassID = value; } }
        public Student(Name namePerson, string phoneNum, string gender, string identityCard, string address, DateTime dateBorn, string Status, string ClassID)
            : base(namePerson, phoneNum, gender, identityCard, address, dateBorn)
        {
            this.Status = Status;
            this.ClassID = ClassID;
        }
        public Student(Enterprise_Infor enterprise_Infor, string Status, string ClassID) : base(enterprise_Infor)
        {
            this.Status = Status;
            this.ClassID = ClassID;
        }
    }
}
