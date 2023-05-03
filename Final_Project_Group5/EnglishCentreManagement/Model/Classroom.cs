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
        private DateTime startingDate;
        private DateTime endingDate;
        private string studyDate;
        private string idShift;

        public string IDTeacher { get => idTeacher; set => idTeacher=value; }
        public string IDClassroom { get => idClassroom; set => idClassroom = value; }
        public string RoomNum { get => roomNum; set => roomNum = value; }
        public int MaxNumStudent { get => maxNumStudent; set => maxNumStudent = value; }
        public string IDCourse { get => idCourse; set => idCourse=value; }
        public DateTime StartingDate { get => startingDate; set => startingDate = value; }
        public DateTime EndingDate { get => endingDate; set => endingDate = value; }
        public string StudyDate { get => studyDate; set => studyDate=value; }
        public string IDShift { get => idShift; set => idShift=value; }

        public Classroom(string IDTeacher, string IDClassroom, string RoomNum, int NumStudent,
        string IDCourse, DateTime StartingDate, DateTime EndingDate, string StudyDate, string IDShift)
        {
            this.idTeacher = IDTeacher; 
            this.idClassroom = IDClassroom;
            this.idCourse = IDCourse;
            this.roomNum = RoomNum;
            this.endingDate = EndingDate;
            this.studyDate = StudyDate;
            this.startingDate = StartingDate;
            this.endingDate= EndingDate;
            this.maxNumStudent = NumStudent;
            this.idShift = IDShift;
        }

        public Classroom()
        {
            this.idTeacher = "";
            this.idClassroom = "";
            this.roomNum = "";
            this.idCourse = "";
            this.studyDate = "";
            this.startingDate = DateTime.Now;
            this.endingDate = DateTime.Now;
            this.idShift = "";
        }

        public bool IsHaveNullValue()
        {
            if(idTeacher == "" || idClassroom == "" || roomNum == "" || idCourse == "" || studyDate == "" || idShift == "")
                return true;
            return false;
        }
    }
}
