namespace EnglishCentreManagement.Model
{
    public class Course     
    {
        private string idCourse;
        private string nameCourse;
        private double inputLevel;
        private double ouputLevel;
        private int numOfWeek;
        private double requestLevelOfTeacher;

        public string IDCourse { get => idCourse; set => idCourse = value; }
        public string NameCourse { get => nameCourse; set => nameCourse = value; }
        public double InputLevel { get => inputLevel; set => inputLevel = value; }
        public double OuputLevel { get => ouputLevel; set => ouputLevel = value; }
        public int NumOfWeek { get => numOfWeek; set => numOfWeek = value; }
        public double RequestLevelOfTeacher { get => requestLevelOfTeacher; set => requestLevelOfTeacher=value; }

        public Course(string IDCourse, string NameCourse, int NumOfWeek, double InputLevel
            , double OuputLevel, double RequestLevelOfTeacher)
        {
            this.idCourse = IDCourse;
            this.nameCourse = NameCourse;
            this.numOfWeek = NumOfWeek;
            this.inputLevel = InputLevel;
            this.ouputLevel = OuputLevel;
            this.requestLevelOfTeacher = RequestLevelOfTeacher;
        }

        public Course() 
        {
            idCourse = "";
            nameCourse = "";
        }

    }
}
