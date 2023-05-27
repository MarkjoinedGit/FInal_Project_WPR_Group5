using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishCentreManagement.Model
{
    public class AveragePointStudent
    {
        private string idClassRoom;
        private string idStudent;
        private double averagePoint;
        private double branchPoints;
        private TestResult result;
        public string IdClassRoom { get => idClassRoom; set => idClassRoom = value; }
        public string IdStudent { get => idStudent; set => idStudent = value; }
        public double AveragePoint { get => averagePoint; set => averagePoint = value; }
        public double BranchPoints { get => branchPoints; set => branchPoints = value; }
        public AveragePointStudent() 
        { 
            idClassRoom = "";
            idStudent = "";
            averagePoint = 0.0;
            branchPoints = 0.0;
            result=new TestResult();
        }
        public AveragePointStudent(string idClassRoom,string idStudent, double averagePoint,double branchPoints)
        {
            this.IdClassRoom = idClassRoom;
            this.IdStudent = idStudent;
            this.AveragePoint = averagePoint;
            this.BranchPoints = branchPoints;
        }
    }
}
