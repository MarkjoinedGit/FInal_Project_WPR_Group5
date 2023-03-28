using EnglishCentreManagement.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishCentreManagement.Database
{
    public class ClassRoomDao
    {
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.connStr);

        public void Them(Classroom cls)
        {
            string str = string.Format("INSERT INTO LOPHOC VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', ,'{7}', '{8}')", cls.ClassTeacher.Enter_Infor.ID, cls.IDClassroom, cls.RoomNum, cls.NumStudent, cls.ClassCourse.IdCourse, cls.StartingDate, cls.EndingDate, cls.StudyDate, cls.ClassShift.IDShift);
            DBConnection.ThucThi(conn, str);
        }


        public void Xoa(Classroom cls)
        {
            string str = string.Format("DELETE FROM LOPHOC WHERE MaLop = '{0}')", cls.IDClassroom);
            DBConnection.ThucThi(conn, str);
        }

        public void Sua(Classroom cls)
        {
            string str = string.Format("UPDATE LOPHOC SET MaGiaoVien = '{0}', SoPhong = '{1}', SoHocSinh = '{2}', MaKhoaHoc = '{3}', NgayBatDau ='{4}', NgayKetThuc = '{5}', NgayHocTrongTuan ='{6}', MaCa = '{7}' WHERE  MaLop = '{8}'", cls.ClassTeacher.Enter_Infor.ID, cls.RoomNum, cls.NumStudent, cls.ClassCourse.IdCourse, cls.StartingDate, cls.EndingDate, cls.StudyDate,  cls.ClassShift.IDShift, cls.IDClassroom);
            DBConnection.ThucThi(conn, str);
        }

        public DataTable getStudentList(Classroom cls)
        {
            string sqlStr = string.Format("EXEC fn_LayDanhSachHocVienTrongLop '{0}'", cls.IDClassroom);
            return DBConnection.getData(conn, sqlStr);
        }
    }
}
