using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace EnglishCentreManagement.Model
{
    public class Schedule
    {

        public Shift ShiftTime { get; set; }
        public int IndexWeek { get; set; }
        // 
        public string txtInforStu { get; set; }
        // 
        public int NumWeek { get; set; }
        //
        public string txtTimeStudStart { get; set; }
        public string txtTimeStudEnd { get; set; }
        //
        public string txtAbsent { get; set; }
        public string ShiftCode { get; set; }
        public string txtDetailTimeStart { get; set; }
        public string txtDetailTimeEnd { get; set; }
        // Monday
        public string IdClassMonday { get; set; }
        public string NameTeacherMonday { get; set; }
        public string RoomNumMonday { get; set; }

        // Tuesday
        public string IdClassTuesday { get; set; }
        public string NameTeacherTuesday { get; set; }
        public string RoomNumTuesday { get; set; }

        // Wednesday
        public string IdClassWednesday { get; set; }
        public string NameTeacherWednesday { get; set; }
        public string RoomNumWednesday { get; set; }

        // Friday
        public string IdClassFriday { get; set; }
        public string NameTeacherFriday { get; set; }
        public string RoomNumFriday { get; set; }

        // Thusday
        public string IdClassThusday { get; set; }
        public string NameTeacherThusday { get; set; }
        public string RoomNumThusday { get; set; }

        // Saturday
        public string IdClassSaturday { get; set; }
        public string NameTeacherSaturday { get; set; }
        public string RoomNumSaturday { get; set; }

        // Sunday
        public string IdClassSunday { get; set; }
        public string NameTeacherSunday { get; set; }
        public string RoomNumSunday { get; set; }
        public Schedule() { }
    }
}
