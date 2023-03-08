using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf_FinalProject_1._1.CSFile
{
    class Teacher : Person
    {
        private long lSalary;
        private string sBankAdd;
        private double dLevelIelts;
        public long Salary
        { get { return this.lSalary; } set { this.lSalary = value; } }
        public string BankAdd
        { get { return this.sBankAdd; } set { this.sBankAdd = value; } }
        public double LevelIelts
        { get { return this.dLevelIelts; } set { this.dLevelIelts = value; } }
        public Teacher(Name namePerson, string phoneNum, string gender, string identityCard, string address, DateTime dateBorn
            , double LevelIelts)
            : base(namePerson, phoneNum, gender, identityCard, address, dateBorn)
        {
            this.LevelIelts = LevelIelts;
        }
        public Teacher(Enterprise_Infor enterprise_Infor, long Salary, string Bank, double Level) : base(enterprise_Infor)
        {
            this.Salary = Salary;
            this.BankAdd = Bank;
            this.LevelIelts = Level;
        }
    }
}
