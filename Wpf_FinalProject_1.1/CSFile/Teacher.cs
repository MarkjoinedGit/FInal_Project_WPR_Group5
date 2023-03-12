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
        {
            get { return this.lSalary; }
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException($"{nameof(value)} must be greater than 0");
                this.lSalary = value;
            }
        }

        public string BankAdd
        {
            get { return this.sBankAdd; }
            set { this.sBankAdd = value; }
        }

        public double LevelIelts
        {
            get { return this.dLevelIelts; }
            set
            {
                if (value < 7.5)
                    throw new ArgumentOutOfRangeException($"{nameof(value)} must be greater than 7.5.");
                this.dLevelIelts = value;
            }
        }

        public Teacher(Enterprise_Infor enterprise_Infor, Name namePerson, string phoneNum, string gender, string identityCard, string address, DateTime dateBorn, double LevelIelts, long Salary, string Bank)
            : base(enterprise_Infor, namePerson, phoneNum, gender, identityCard, address, dateBorn)
        {
            this.Salary = Salary;
            this.BankAdd = Bank;
            this.LevelIelts = LevelIelts;
        }
    }
}
