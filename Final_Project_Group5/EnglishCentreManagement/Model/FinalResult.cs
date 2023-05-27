using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishCentreManagement.Model
{
    public class FinalResult
    {
        private string idClassroom;
        private string idStudent;
        private double diemQuaTrinh;
        private double diemCuoiKi;
        private double diemTongKet;
        private Boolean lenLop;

        public string IdClassroom { get => idClassroom; set => idClassroom = value; }
        public string IdStudent { get => idStudent; set => idStudent = value; }
        public double DiemQuaTrinh { get => diemQuaTrinh; set => diemQuaTrinh = value; }
        public double DiemCuoiKi { get => diemCuoiKi; set => diemCuoiKi = value; }
        public double DiemTongKet { get => diemTongKet; set => diemTongKet = (diemQuaTrinh + DiemCuoiKi) / 2; }
        public bool LenLop { get => lenLop; set => lenLop = value; }
        public FinalResult() 
        {
            idClassroom = "";
            idStudent = "";
            DiemCuoiKi= 0.0;
            DiemQuaTrinh= 0.0;
            LenLop = true;
        }
        public FinalResult(string idClassroom, string idStudent, double diemQuaTrinh, double diemCuoiKi, double diemTongKet, bool lenLop)
        {
            IdClassroom = idClassroom;
            IdStudent = idStudent;
            DiemQuaTrinh = diemQuaTrinh;
            DiemCuoiKi = diemCuoiKi;
            DiemTongKet = diemTongKet;
            LenLop = lenLop;
        }
    }
}
