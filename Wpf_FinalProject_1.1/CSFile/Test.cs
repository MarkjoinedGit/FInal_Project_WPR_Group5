using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf_FinalProject_1._1.CSFile
{
    class Test
    {
        private string sIdTest;
        private DateTime dtTimeTesting;
        private string sIdTeacher;
        private Dictionary<string, double> dicPoint;

        public string IdTest
        {
            get { return sIdTest; }
            set { sIdTest = value; }
        }

        public DateTime TimeTesting
        {
            get { return dtTimeTesting; }
            set { dtTimeTesting = value; }
        }

        public string IdTeacher
        {
            get { return sIdTeacher; }
            set { sIdTeacher = value; }
        }

        public Dictionary<string, double> Point
        {
            get { return dicPoint; }
            set { dicPoint = value; }
        }

        ~Test() { }
        public Test(string sIdTest, DateTime dtTimeTesting, string sIdTeacher, Dictionary<string, double> dicPoint)
        {
            IdTest = sIdTest;
            TimeTesting = dtTimeTesting;
            IdTeacher = sIdTeacher;
            Point = dicPoint;
        }

        public Test(string IDTest, string IdTeacher, Dictionary<string, double> Point)
        {
            IdTest = IDTest;
            this.IdTeacher = IdTeacher;
            this.Point = Point;
        }
    }
}
