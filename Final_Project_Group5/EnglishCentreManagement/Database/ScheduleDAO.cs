using EnglishCentreManagement.Interfaces;
using EnglishCentreManagement.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EnglishCentreManagement.Database
{
    public class ScheduleDAO
    {
        static SqlConnection conn = new SqlConnection(Properties.Settings.Default.connStr);
        static IEnterprise_infoDAO enterprise_InfoDAO = new Enterprise_infoDAO();
        static ClassRoomDao classDAO = new ClassRoomDao();
        static ShiftDAO _shiftDAO = new ShiftDAO();
        static TeacherDAO TeacherDAO = new TeacherDAO();
        
        // Each Classroom has a Idshift,
        public static List<Shift> FindShiftForClassByClass(List<Classroom> ListClassroom)
        {
            List<Shift> ListShift = new List<Shift>();
            foreach (Classroom classroom in ListClassroom)
            {
                Shift Shift = _shiftDAO.findShiftByID(classroom.IDShift);
                ListShift.Add(Shift);
            }
            return ListShift;
        }
        // Find Teacher Name by classroomID
        public static Teacher? FindTeacherByIdClass(string ClassroomId)
        {
            string strSQL = String.Format("SELECT * FROM LOPHOC,GIAOVIEN WHERE MaLop = '{0}'", ClassroomId);
            try
            {
                DataTable dtUser = DBConnection.getData(conn, strSQL);
                return new Teacher
                {
                    Enter_Infor = enterprise_InfoDAO.getById(dtUser.Rows[0]["MaGiaoVien"].ToString()),
                    NamePerson = dtUser.Rows[0]["TenGiaoVien"].ToString(),
                    DateBorn = new DateTime(Convert.ToDateTime(dtUser.Rows[0]["NgaySinh"]).Year, Convert.ToDateTime(dtUser.Rows[0]["NgaySinh"]).Month, Convert.ToDateTime(dtUser.Rows[0]["NgaySinh"]).Day),
                    Gender = dtUser.Rows[0]["GioiTinh"].ToString(),
                    Address = dtUser.Rows[0]["DiaChi"].ToString(),
                    PhoneNum = dtUser.Rows[0]["SoDienThoai"].ToString(),
                    IdentityCard = dtUser.Rows[0]["ChungMinhNhanDan"].ToString(),
                    BankNumber = dtUser.Rows[0]["SoTaiKhoan"].ToString(),
                    RankLevel = Convert.ToDouble(dtUser.Rows[0]["RankLevel"])
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cannot find the information of the teacher or " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return null;
        }
    }
}
