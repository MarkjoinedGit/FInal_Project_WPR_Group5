using System;
using System.Collections.Generic;

namespace EnglishCentreManagement.Model
{
    class Test
    {
        private string IdTest;
        private DateTime TimeTesting;
        private string IdTeacher;
        private Dictionary<string, double> Point;
        public string idtest
        {
            get { return this.IdTest; }
            set { this.IdTest = value; }
        }
        public DateTime timetesting
        {
            get { return this.TimeTesting; }
            set { this.TimeTesting = value; }
        }
        public string idteacher
        {
            get { return this.IdTeacher; }
            set { this.IdTeacher = value; }
        }
        public Dictionary<string, double> point
        {
            get { return this.Point; }
            set { this.Point = value; }
        }
        ~Test() { }
        public Test(string sIdTest, DateTime dtTimeTesting, string sIdTeacher, Dictionary<string, double> dicPoint)
        {
            this.idtest = sIdTest;
            this.timetesting = dtTimeTesting;
            this.idteacher = sIdTeacher;
            this.point = dicPoint;
        }
    }
}
