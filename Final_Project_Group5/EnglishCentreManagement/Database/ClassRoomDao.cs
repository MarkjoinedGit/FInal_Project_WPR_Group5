using EnglishCentreManagement.Interfaces;
using EnglishCentreManagement.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishCentreManagement.Database
{
    public class ClassRoomDao : IClassRoomDao
    {
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.connStr);
        ITeacherDao teacherDao = new TeacherDAO();

        public void Add(Classroom cls)
        {
            string str = string.Format("INSERT INTO LOPHOC VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}')", cls.ClassTeacher.Enter_Infor.ID, cls.IDClassroom, cls.RoomNum, cls.MaxNumStudent, cls.ClassCourse.IdCourse, cls.StartingDate, cls.EndingDate, cls.StudyDate, cls.ClassShift.IDShift);
            DBConnection.Execute(conn, str);
        }

        public void Delete(Classroom cls)
        {
            string str = string.Format("DELETE FROM LOPHOC WHERE MaLop = '{0}')", cls.IDClassroom);
            DBConnection.Execute(conn, str);
        }

        public void Update(Classroom cls)
        {
            string str = string.Format("UPDATE LOPHOC SET MaGiaoVien = '{0}', SoPhong = '{1}', SoHocSinh = '{2}', MaKhoaHoc = '{3}', NgayBatDau ='{4}', NgayKetThuc = '{5}', NgayHocTrongTuan ='{6}', MaCa = '{7}' WHERE  MaLop = '{8}'", cls.ClassTeacher.Enter_Infor.ID, cls.RoomNum, cls.MaxNumStudent, cls.ClassCourse.IdCourse, cls.StartingDate, cls.EndingDate, cls.StudyDate,  cls.ClassShift.IDShift, cls.IDClassroom);
            DBConnection.Execute(conn, str);
        }

        public DataTable getClassRoomDAO()
        {
            string sqlStr = string.Format("SELECT* FROM LOPHOC");
            return DBConnection.getData(conn, sqlStr);
        }

        public DataTable getStudentList(Classroom cls)
        {
            string sqlStr = string.Format("EXEC fn_LayDanhSachHocVienTrongLop '{0}'", cls.IDClassroom);
            return DBConnection.getData(conn, sqlStr);
        }

        public List<Classroom> fillDataToListClassRoom(DataTable datatable)
        {
            List<Classroom> ListClassrooms = new List<Classroom>();

            foreach (DataRow dr in datatable.Rows)
            {
                Classroom classroom = new Classroom
                {
                    ClassTeacher = teacherDao.getByID(dr["MaGiaoVien"].ToString()),
                    IDClassroom = dr["MaLop"].ToString(),
                    RoomNum = dr["SoPhong"].ToString(),
                    MaxNumStudent = Convert.ToInt32(dr["SoHocSinh"]),
                    ClassCourse = CourseDAO.findCourseByID(dr["MaKhoaHoc"].ToString()),
                    StartingDate = new DateOnly(Convert.ToDateTime(dr["NgayBatDau"]).Year, Convert.ToDateTime(dr["NgayBatDau"]).Month, Convert.ToDateTime(dr["NgayBatDau"]).Day),
                    EndingDate = new DateOnly(Convert.ToDateTime(dr["NgayKetThuc"]).Year, Convert.ToDateTime(dr["NgayKetThuc"]).Month, Convert.ToDateTime(dr["NgayKetThuc"]).Day),
                    StudyDate = dr["NgayHocTrongTuan"].ToString(),
                    ClassShift = ShiftDAO.findShiftByID(dr["MaCa"].ToString())
                };
                ListClassrooms.Add(classroom);
            }

            return ListClassrooms;
        }

        public bool ValidateValue(Classroom cls)
        {
            bool validValue = false;

            if(cls != null)
            {
                if (cls.ClassTeacher == null || cls.IDClassroom == null || cls.RoomNum == null || cls.MaxNumStudent.ToString() == null || cls.ClassCourse == null || cls.StartingDate.ToString() == null || cls.EndingDate.ToString() == null|| cls.StudyDate == null || cls.ClassShift == null)
                    validValue = false;
                else
                    validValue = true;
            }

            return validValue;

        }

        public void AddStudent(Classroom cls, Student st)
        {
            string sqlStr = string.Format("INSERT INTO HocVienTrongLop VALUES('{0}', '{1}')", cls.IDClassroom, st.Enter_Infor.ID);
            DBConnection.Execute(conn, sqlStr);
        }
    }
}
