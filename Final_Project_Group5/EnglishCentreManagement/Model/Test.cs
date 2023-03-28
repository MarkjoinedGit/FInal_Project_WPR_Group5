using System;
using System.Collections.Generic;

namespace EnglishCentreManagement.Model
{
    public class Test
    {
        private string idTest;
        private DateTime timeTesting;
        private string idTeacher;
        private Dictionary<string, double> point;

        public string IDTest { get => idTest; set => idTest = value; }
        public DateTime TimeTesting { get => timeTesting; set => timeTesting = value; }
        public string IDTeacher { get => idTeacher; set => idTeacher = value; }
        public Dictionary<string, double> Point { get => point; set => point=value; }

        ~Test() { }
        public Test(string IDTest, DateTime TimeTesting, string IDTeacher, Dictionary<string, double> Point)
        {
            this.IDTest = IDTest;
            this.TimeTesting = TimeTesting;
            this.IDTeacher = IDTeacher;
            this.Point = Point;
        }
    }
}
