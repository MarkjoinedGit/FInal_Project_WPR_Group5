using System;

namespace EnglishCentreManagement.Model
{
    class Teacher : Person
    {
        private long Salary;
        private string BankAdd;
        private double LevelIelts;
        public long salary
        {
            get { return this.Salary; }
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException($"{nameof(value)} must be greater than 0");
                this.Salary = value;
            }
        }

        public string bankadd
        {
            get { return this.BankAdd; }
            set { this.BankAdd = value; }
        }

        public double levelielts
        {
            get { return this.LevelIelts; }
            set
            {
                if (value < 7.5)
                    throw new ArgumentOutOfRangeException($"{nameof(value)} must be greater than 7.5.");
                this.LevelIelts = value;
            }
        }

        public Teacher(Enterprise_Infor enterprise_Infor, Name namePerson, string phoneNum, string gender, string identityCard, string address, DateTime dateBorn, double LevelIelts, long Salary, string Bank)
            : base(enterprise_Infor, namePerson, phoneNum, gender, identityCard, address, dateBorn)
        {
            this.salary = Salary;
            this.bankadd = Bank;
            this.levelielts = LevelIelts;
        }

    }
}
