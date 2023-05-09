using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishCentreManagement.Model
{
    public class Calendar
    {
        private string txtInforTea { get; set; }
        private string number;
        private string courseID { get; set; }
        private string idClass { get; set; }
        private string txtStart { get; set; }
        private string txtEnd { get; set; }
        private string shiftCode { get; set; }
        private string txtDetailTimeStart { get; set; }
        private string txtDetailTimeEnd { get; set; }
        private string roomNumMonday { get; set; }
        private string roomNumTuesday { get; set; }
        private string roomNumWednesday { get; set; }
        private string roomNumThusday { get; set; }
        private string roomNumFriday { get; set; }
        private string roomNumSaturday { get; set; }
        private string roomNumSunday { get; set; }
        public string TxtInforTea { get => txtInforTea; set => number = txtInforTea; }

        public string Number { get => number; set => number = value; }
        public string IdClass { get => idClass; set => idClass = value; }
        public string CourseID { get => courseID; set => courseID = value; }
        public string TxtStart { get => txtStart; set => txtStart = value; }
        public string TxtEnd { get => txtEnd; set => txtEnd = value; }
        public string ShiftCode { get => shiftCode; set => shiftCode = value; }
        public string TxtDetailTimeStart { get => txtDetailTimeStart; set => txtDetailTimeStart = value; }
        public string TxtDetailTimeEnd { get => txtDetailTimeEnd; set => txtDetailTimeEnd = value; }
        public string RoomNumMonday { get => roomNumMonday; set => roomNumMonday = value; }
        public string RoomNumTuesday { get => roomNumTuesday; set => roomNumTuesday = value; }
        public string RoomNumWednesday { get => roomNumWednesday; set => roomNumWednesday = value; }
        public string RoomNumThusday { get => roomNumThusday; set => roomNumThusday = value; }
        public string RoomNumFriday { get => roomNumFriday; set => roomNumFriday = value; }
        public string RoomNumSaturday { get => roomNumSaturday; set => roomNumSaturday = value; }
        public string RoomNumSunday { get => roomNumSunday; set => roomNumSunday = value; }

        public Calendar() { }
    }
}