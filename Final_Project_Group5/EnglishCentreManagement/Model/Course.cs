namespace EnglishCentreManagement.Model
{
    class Course
    {
        private string idCourse;
        private double lowestLevel;
        private double highestLevel;
        private int numOfWeek;
        private double requestLevelOfTeacher;
        public string IdCourse
        {
            get { return this.idCourse; }
            set { this.idCourse = value; }
        }
        public double LowestLevel
        {
            get { return this.lowestLevel; }
            set { this.lowestLevel = value; }
        }
        public double HighestLevel
        {
            get { return this.highestLevel; }
            set { this.highestLevel = value; }
        }
        public double RequestLevelOfTeacher
        {
            get { return this.requestLevelOfTeacher; }
            set { this.requestLevelOfTeacher = value; }
        }
        public int NumOfWeek
        {
            get { return this.numOfWeek; }
            set { this.numOfWeek = value; }
        }
        ~Course() { }
        public Course(string IdCourse, int NumOfWeek, double LowestLevel
            , double HighestLevel, double RequestLevelOfTeacher)
        {
            this.IdCourse = IdCourse;
            this.NumOfWeek = NumOfWeek;
            this.LowestLevel = LowestLevel;
            this.HighestLevel = HighestLevel;
            this.RequestLevelOfTeacher = RequestLevelOfTeacher;
        }
    }
}
