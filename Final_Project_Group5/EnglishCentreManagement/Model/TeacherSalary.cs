using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishCentreManagement.Model
{
    public class TeacherSalary
    {
        private Teacher teacher;
        private Statistics statistics;
        public Teacher Teacher { get => teacher; set => teacher = value; }
        public Statistics Statistics { get => statistics; set => statistics = value; }

        public TeacherSalary()
        {
            Teacher = new Teacher();
            statistics = new Statistics();
        }
        public TeacherSalary(Teacher teacher, Statistics statistics)
        {
            Teacher = teacher;
            Statistics = statistics;
        }
        public bool IsHaveNullValue()
        {
            if (teacher == null) return true; return false;
        }
    }
}
