using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf_FinalProject_1._1.CSFile
{
    class Classroom
    {
        private string IdTeacher;
        private string IdClassroom;
        private string RoomNum;
        private int NumStudent;
        private string IdCourse;
        private DateTime StartingDate;
        private DateTime EndingDate;
        private string Meet;

        public string idTeacher
        {
            get { return IdTeacher; }
            set { IdTeacher = value; }
        }

        public string idClassroom
        {
            get { return IdClassroom; }
            set { IdClassroom = value; }
        }

        public string roomNum
        {
            get { return RoomNum; }
            set { RoomNum = value; }
        }

        public string idCourse
        {
            get { return IdCourse; }
            set { IdCourse = value; }
        }

        public DateTime startingDate
        {
            get { return StartingDate; }
            set { StartingDate = value; }
        }

        public DateTime endingDate
        {
            get { return EndingDate; }
            set { EndingDate = value; }
        }

        public string meet
        {
            get { return Meet; }
            set { Meet = value; }
        }

        ~Classroom() { }
        public Classroom(string IdTeacher, string IdClassroom, string RoomNum, int sNumStudent,
        string IdCourse, DateTime StartingDate, DateTime EndingDate, string Meet)
        {
            idTeacher = IdTeacher;
            idClassroom = IdClassroom;
            roomNum = RoomNum;
            idCourse = IdCourse;
            startingDate = StartingDate;
            endingDate = EndingDate;
            meet = Meet;
        }       
    }
}
