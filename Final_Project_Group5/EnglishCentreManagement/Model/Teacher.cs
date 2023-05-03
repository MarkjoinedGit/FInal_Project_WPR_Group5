using System;
using System.Windows;

namespace EnglishCentreManagement.Model
{
    public class Teacher : Person
    {
        private long? salary;

        public long? Salary { get => salary; set => salary=value; }

        public Teacher() { }
    }
}
