using System;

namespace EnglishCentreManagement.Model
{
    public class Classroom
    {
        private Teacher classTeacher;
        private string idClassroom;
        private string roomNum;
        private int numStudent;
        private Course classCourse;
        private DateTime startingDate;
        private DateTime endingDate;
        private string studyDate;
        private Shift classShift;

        public Teacher ClassTeacher { get => classTeacher; set => classTeacher=value; }
        public string IDClassroom { get => idClassroom; set => idClassroom = value; }
        public string RoomNum { get => roomNum; set => roomNum = value; }
        public int NumStudent { get => numStudent; set => numStudent = value; }
        public Course ClassCourse { get => classCourse; set => classCourse=value; }
        public DateTime StartingDate { get => startingDate; set => startingDate = value; }
        public DateTime EndingDate { get => endingDate; set => endingDate = value; }
        public string StudyDate { get => studyDate; set => studyDate=value; }
        public Shift ClassShift { get => classShift; set => classShift=value; }

        public Classroom(Teacher ClassTeacher, string IDClassroom, string RoomNum, int NumStudent,
        Course ClassCourse, DateTime StartingDate, DateTime EndingDate, string StudyDate, Shift ClassShift)
        {
            this.ClassTeacher = ClassTeacher;
            this.IDClassroom = IDClassroom;
            this.ClassCourse = ClassCourse;
            this.RoomNum = RoomNum;
            this.EndingDate = EndingDate;
            this.StudyDate = StudyDate;
            this.StartingDate = StartingDate;
            this.NumStudent = NumStudent;
            this.ClassShift = ClassShift;
        }
    }
}
