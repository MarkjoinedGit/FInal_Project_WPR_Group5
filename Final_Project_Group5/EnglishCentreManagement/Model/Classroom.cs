using System;

namespace EnglishCentreManagement.Model
{
    class Classroom
    {
        private string idTeacher;
        private string idClassroom;
        private string roomNum;
        private int numStudent;
        private string idCourse;
        private DateTime startingDate;
        private DateTime endingDate;
        private string meet;
        public string IdTeacher
        {
            get { return this.idTeacher; }
            set { this.idTeacher = value; }
        }
        public string IdClassroom
        {
            get { return this.idClassroom; }
            set { this.idClassroom = value; }
        }
        public int NumStudent
        {
            get { return this.numStudent; }
            set { this.numStudent = value; }
        }
        public string RoomNum
        {
            get { return this.roomNum; }
            set { this.roomNum = value; }
        }
        public string IdCourse
        {
            get { return this.idCourse; }
            set { this.idCourse = value; }
        }
        public DateTime StartingDate
        {
            get { return this.startingDate; }
            set { this.startingDate = value; }
        }
        public DateTime EndingDate
        {
            get { return this.endingDate; }
            set { this.endingDate = value; }
        }
        public string Meet
        {
            get { return this.meet; }
            set { this.meet = value; }
        }
        ~Classroom() { }
        //... Properties using to show for Manager
        public Classroom(string IdTeacher, string IdClassroom, string RoomNum, int NumStudent,
        string IdCourse, DateTime StartingDate, DateTime EndingDate, string Meet)
        {
            this.IdTeacher = IdTeacher;
            this.IdClassroom = IdClassroom;
            this.IdCourse = IdCourse;
            this.RoomNum = RoomNum;
            this.EndingDate = EndingDate;
            this.Meet = Meet;
            this.StartingDate = StartingDate;
            this.NumStudent = NumStudent;
        }
    }
}
