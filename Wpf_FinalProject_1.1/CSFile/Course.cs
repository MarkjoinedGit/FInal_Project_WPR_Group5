using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf_FinalProject_1._1.CSFile
{
    class Course
    {
        private string IdCourse;
        private double Level;
        private int NumOfWeek;
        private double RequestLevelOfTeacher;

        public string IdCourse
        {
            get { return sIdCourse; }
            set { sIdCourse = value; }
        }

        public double Level
        {
            get { return dLevel; }
            set { dLevel = value; }
        }

        public double RequestLevelOfTeacher
        {
            get { return iRequestLevelOfTeacher; }
            set { iRequestLevelOfTeacher = value; }
        }

        public int NumOfWeek
        {
            get { return iNumOfWeek; }
            set { iNumOfWeek = value; }
        }

        ~Course() { }
        public Course(string IdCourse, double Level, int NumOfWeek, double levelIeltsOfteacher)
        {
            this.IdCourse = IdCourse;
            this.Level = Level;
            this.NumOfWeek = NumOfWeek;
            RequestLevelOfTeacher = levelIeltsOfteacher;
        }
    }
}
