﻿using EnglishCentreManagement.Model;
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
    public class CourseDAO
    {
        static SqlConnection conn = new SqlConnection(Properties.Settings.Default.connStr);

        public static Course? findCourseByID(string id)
        {
            string strSQL = string.Format("SELECT * FROM KHOAHOC WHERE MaKhoaHoc = '{0}'", id);
            try
            {
                DataTable dtCourse = DBConnection.getData(conn, strSQL);
                if (dtCourse.Rows.Count > 0)
                {
                    DataRow dt = dtCourse.Rows[0];

                    Course course = new Course
                    {
                        IdCourse = dt["MaKhoaHoc"].ToString(),
                        NameCourse = dt["TenKhoaHoc"].ToString(),
                        InputLevel = Convert.ToDouble(dt["LevelDauVao"]),
                        OuputLevel = Convert.ToDouble(dt["LevelDauRa"]),
                        NumOfWeek = Convert.ToInt32(dt["SoTuanHoc"]),
                        RequestLevelOfTeacher = Convert.ToDouble(dt["LevelCuaGiaoVien"])
                    };
                    return course;
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Cannot find the information of the teacher or " + ex.Message);
            }

            return null;

        }
    }
}
