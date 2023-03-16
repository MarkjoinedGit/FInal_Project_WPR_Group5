namespace EnglishCentreManagement.Model
{
    class Course
    {
        private string IdCourse;
        private double LowestLevel;
        private double HighestLevel;
        private int NumOfWeek;
        private double RequestLevelOfTeacher;
        public string idcourse
        {
            get { return this.IdCourse; }
            set { this.IdCourse = value; }
        }
        public double lowestlevel
        {
            get { return this.LowestLevel; }
            set { this.LowestLevel = value; }
        }
        public double highestlevel
        {
            get { return this.HighestLevel; }
            set { this.HighestLevel = value; }
        }
        public double requestlevelofteacher
        {
            get { return this.RequestLevelOfTeacher; }
            set { this.RequestLevelOfTeacher = value; }
        }
        public int numofweek
        {
            get { return this.NumOfWeek; }
            set { this.NumOfWeek = value; }
        }
        ~Course() { }
        public Course(string IdCourse, int NumOfWeek, double LowestLevel
            , double HighestLevel, double requestlevelofteacher)
        {
            this.idcourse = IdCourse;
            this.numofweek = NumOfWeek;
            this.lowestlevel = LowestLevel;
            this.HighestLevel = HighestLevel;
            this.requestlevelofteacher = requestlevelofteacher;
        }
    }
}
