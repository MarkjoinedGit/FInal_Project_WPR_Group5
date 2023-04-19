using System;
using System.Collections.Generic;
using System.Windows;

namespace EnglishCentreManagement.Model
{
    public class Classroom
    {
        private Teacher classTeacher;
        private string idClassroom;
        private string roomNum;
        private int maxNumStudent;
        private Course classCourse;
        private DateOnly startingDate;
        private DateOnly endingDate;
        private string studyDate;
        private Shift classShift;

        public Teacher ClassTeacher { get => classTeacher; set => classTeacher=value; }
        public string IDClassroom { get => idClassroom; set => idClassroom = value; }
        public string RoomNum { get => roomNum; set => roomNum = value; }
        public int MaxNumStudent { get => maxNumStudent; set => maxNumStudent = value; }
        public Course ClassCourse { get => classCourse; set => classCourse=value; }
        public DateOnly StartingDate { get => startingDate; set => startingDate = value; }
        public DateOnly EndingDate { get => endingDate; set => endingDate = value; }
        public string StudyDate { get => studyDate; set => studyDate=value; }
        public Shift ClassShift { get => classShift; set => classShift=value; }

        public Classroom(Teacher ClassTeacher, string IDClassroom, string RoomNum, int NumStudent,
        Course ClassCourse, DateOnly StartingDate, DateOnly EndingDate, string StudyDate, Shift ClassShift)
        {
            this.ClassTeacher = ClassTeacher;
            this.IDClassroom = IDClassroom;
            this.ClassCourse = ClassCourse;
            this.RoomNum = RoomNum;
            this.EndingDate = EndingDate;
            this.StudyDate = StudyDate;
            this.StartingDate = StartingDate;
            this.MaxNumStudent = NumStudent;
            this.ClassShift = ClassShift;
        }

        public Classroom()
        {

        }
    }
}
