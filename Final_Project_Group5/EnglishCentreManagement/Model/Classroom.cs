using System;

namespace EnglishCentreManagement.Model
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
        public string idteacher
        {
            get { return this.IdTeacher; }
            set { this.IdTeacher = value; }
        }
        public string idclassroom
        {
            get { return this.IdClassroom; }
            set { this.IdClassroom = value; }
        }
        public int numstudent
        {
            get { return this.NumStudent; }
            set { this.NumStudent = value; }
        }
        public string roomnum
        {
            get { return this.RoomNum; }
            set { this.RoomNum = value; }
        }
        public string idcourse
        {
            get { return this.IdCourse; }
            set { this.IdCourse = value; }
        }
        public DateTime startingdate
        {
            get { return this.StartingDate; }
            set { this.StartingDate = value; }
        }
        public DateTime endingdate
        {
            get { return this.EndingDate; }
            set { this.EndingDate = value; }
        }
        public string meet
        {
            get { return this.Meet; }
            set { this.Meet = value; }
        }
        ~Classroom() { }
        //... Properties using to show for Manager
        public Classroom(string sIdTeacher, string sIdClassroom, string sRoomNum, int sNumStudent,
        string sIdCourse, DateTime dtStartingDate, DateTime dtEndingDate, string sMeet)
        {
            this.idteacher = sIdTeacher;
            this.idcourse = sIdCourse;
            this.roomnum = sRoomNum;
            this.endingdate = dtEndingDate;
            this.meet = sMeet;
            this.startingdate = dtStartingDate;
            this.numstudent = sNumStudent;
        }
    }
}
