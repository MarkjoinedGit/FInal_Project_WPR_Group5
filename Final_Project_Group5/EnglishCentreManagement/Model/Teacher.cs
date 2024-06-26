﻿using System;

namespace EnglishCentreManagement.Model
{
    class Teacher : Person
    {
        private long salary;
        private string bankAdd;
        private double level;
        public long Salary
        {
            get { return this.salary; }
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException($"{nameof(value)} must be greater than 0");
                this.salary = value;
            }
        }

        public string BankAdd
        {
            get { return this.bankAdd; }
            set { this.bankAdd = value; }
        }

        public double Level
        {
            get { return this.Level; }
            set
            {
                if (value < 7.5)
                    throw new ArgumentOutOfRangeException($"{nameof(value)} must be greater than 7.5.");
                this.Level = value;
            }
        }

        public Teacher(Enterprise_Infor Enterprise_Infor, Name NamePerson, string PhoneNum, string Gender, string IdentityCard, string Address, DateTime DateBorn, double Level, long Salary, string Bank)
            : base(Enterprise_Infor, NamePerson, PhoneNum, Gender, IdentityCard, Address, DateBorn)
        {
            this.Salary = Salary;
            this.BankAdd = Bank;
            this.Level = Level;
        }

    }
}
