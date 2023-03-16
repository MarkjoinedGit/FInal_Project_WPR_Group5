using System;
using System.Collections.Generic;

namespace EnglishCentreManagement.Model
{
    class Test
    {
        private string idTest;
        private DateTime timeTesting;
        private string idTeacher;
        private Dictionary<string, double> point;
        public string IDTest
        {
            get { return this.idTest; }
            set { this.idTest = value; }
        }
        public DateTime TimeTesting
        {
            get { return this.timeTesting; }
            set { this.timeTesting = value; }
        }
        public string IDTeacher
        {
            get { return this.idTeacher; }
            set { this.idTeacher = value; }
        }
        public Dictionary<string, double> Point
        {
            get { return this.point; }
            set { this.point = value; }
        }
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
