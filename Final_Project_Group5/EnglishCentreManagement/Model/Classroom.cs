using System;
using System.Collections.Generic;
using System.Windows;

namespace EnglishCentreManagement.Model
{
    public class Classroom
    {
        private string idTeacher;
        private string idClassroom;
        private string roomNum;
        private int maxNumStudent;
        private string idCourse;
        private DateOnly startingDate;
        private DateOnly endingDate;
        private string studyDate;
        private string idShift;

        public string IDTeacher { get => idTeacher; set => idTeacher=value; }
        public string IDClassroom { get => idClassroom; set => idClassroom = value; }
        public string RoomNum { get => roomNum; set => roomNum = value; }
        public int MaxNumStudent { get => maxNumStudent; set => maxNumStudent = value; }
        public string IDCourse { get => idCourse; set => idCourse=value; }
        public DateOnly StartingDate { get => startingDate; set => startingDate = value; }
        public DateOnly EndingDate { get => endingDate; set => endingDate = value; }
        public string StudyDate { get => studyDate; set => studyDate=value; }
        public string IDShift { get => idShift; set => idShift=value; }

        public Classroom(string IDTeacher, string IDClassroom, string RoomNum, int NumStudent,
        string IDCourse, DateOnly StartingDate, DateOnly EndingDate, string StudyDate, string IDShift)
        {
            this.IDTeacher = IDTeacher; 
            this.IDClassroom = IDClassroom;
            this.IDCourse = IDCourse;
            this.RoomNum = RoomNum;
            this.EndingDate = EndingDate;
            this.StudyDate = StudyDate;
            this.StartingDate = StartingDate;
            this.MaxNumStudent = NumStudent;
            this.IDShift = IDShift;
        }

        public Classroom()
        {

        }
    }
}
