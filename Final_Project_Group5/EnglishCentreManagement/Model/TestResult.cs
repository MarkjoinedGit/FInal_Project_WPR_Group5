using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishCentreManagement.Model
{
    public class TestResult
    {
        private string idStudent;
        private string idTest;
        private double point;

        public string IdStudent { get => idStudent; set => idStudent = value; }
        public string IdTest { get => idTest; set => idTest = value; }
        public double Point { get => point; set => point=value; }

        public TestResult()
        {
            idStudent = "";
            idTest = "";
        }
    }
}
