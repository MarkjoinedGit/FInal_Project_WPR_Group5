using System;
using System.Windows;

namespace EnglishCentreManagement.Model
{
    public class Teacher : Person
    {
        private double? salary;

        public double? Salary { get => salary; set => salary=value; }

        public Teacher() { }
    }
}
