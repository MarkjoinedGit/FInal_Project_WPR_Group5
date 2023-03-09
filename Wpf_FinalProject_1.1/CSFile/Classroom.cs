using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf_FinalProject_1._1.CSFile
{
    class Classroom
    {
        private string sIdTeacher;
        private string sIdClassroom;
        private string sRoomNum;
        private int sNumStudent;
        private string sIdCourse;
        private DateTime dtStartingDate;
        private DateTime dtEndingDate;
        private string sMeet;

        public string IdTeacher
        {
            get { return sIdTeacher; }
            set { sIdTeacher = value; }
        }

        public string IdClassroom
        {
            get { return sIdClassroom; }
            set { sIdClassroom = value; }
        }

        public string RoomNum
        {
            get { return sRoomNum; }
            set { sRoomNum = value; }
        }

        public string IdCourse
        {
            get { return sIdCourse; }
            set { sIdCourse = value; }
        }

        public DateTime StartingDate
        {
            get { return dtStartingDate; }
            set { dtStartingDate = value; }
        }

        public DateTime EndingDate
        {
            get { return dtEndingDate; }
            set { EndingDate = value; }
        }

        public string Meet
        {
            get { return sMeet; }
            set { sMeet = value; }
        }

        ~Classroom() { }
        //... Properties using to show for Manager
        public Classroom(string sIdTeacher, string sIdClassroom, string sRoomNum, int sNumStudent,
        string sIdCourse, DateTime dtStartingDate, DateTime dtEndingDate, string sMeet)
        {
            IdTeacher = sIdTeacher;
            IdClassroom = sIdClassroom;
            RoomNum = sRoomNum;
            IdCourse = sIdCourse;
            StartingDate = dtStartingDate;
            EndingDate = dtEndingDate;
            Meet = sMeet;
        }

        //... Properties using to show for students
        public Classroom(string sIdClassroom, string sIdTeacher, string sIdCourse, string sMeet, string sRoomNum)
        {
            IdClassroom = sIdClassroom;
            IdTeacher = sIdTeacher;
            IdCourse = sIdCourse;
            Meet = sMeet;
            this.sRoomNum = sRoomNum;
        }
    }
}
