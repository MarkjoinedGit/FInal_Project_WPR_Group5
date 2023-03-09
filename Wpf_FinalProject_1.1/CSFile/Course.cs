using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf_FinalProject_1._1.CSFile
{
    class Course
    {
        private string sIdCourse;
        private Dictionary<double, double> dicLevel;
        private int intNumOfWeek;
        private double intRequestLevelOfTeacher;

        public string IdCourse
        {
            get { return sIdCourse; }
            set { sIdCourse = value; }
        }

        public Dictionary<double, double> Level
        {
            get { return dicLevel; }
            set { dicLevel = value; }
        }

        public double RequestLevelOfTeacher
        {
            get { return RequestLevelOfTeacher; }
            set { RequestLevelOfTeacher = value; }
        }

        public int NumOfWeek
        {
            get { return intNumOfWeek; }
            set { NumOfWeek = value; }
        }

        ~Course() { }

        public Course(string IdCourse, Dictionary<double, double> Level, int NumOfWeek)
        {
            this.IdCourse = IdCourse;
            this.Level = Level;
            this.NumOfWeek = NumOfWeek;
        }

        public Course(string IdCourse, Dictionary<double, double> Level, int NumOfWeek, double levelIeltsOfteacher)
        {
            this.IdCourse = IdCourse;
            this.Level = Level;
            this.NumOfWeek = NumOfWeek;
            RequestLevelOfTeacher = levelIeltsOfteacher;
        }
    }
}
