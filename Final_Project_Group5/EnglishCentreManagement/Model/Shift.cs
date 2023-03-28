using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishCentreManagement.Model
{
    public class Shift
    {
        private string idShift;
        private TimeSpan startingTime;
        private TimeSpan endingtime;

        public Shift(string IDShift, TimeSpan StartingTime, TimeSpan Endingtime)
        {
            this.IDShift = IDShift;
            this.StartingTime = StartingTime;
            this.Endingtime = Endingtime;
        }

        public string IDShift { get => idShift; set => idShift = value; }
        public TimeSpan StartingTime { get => startingTime; set => startingTime = value; }
        public TimeSpan Endingtime { get => endingtime; set => endingtime=value; }
    }
}
