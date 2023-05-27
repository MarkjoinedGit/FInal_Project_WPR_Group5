using EnglishCentreManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishCentreManagement.Interfaces
{
    interface ISalaryDAO
    {
        List<TeacherSalary> getListAllSalary();
        List<TeacherSalary> getListByName(string name);
        TeacherSalary getTeacherSalaryByTeacher(string Name);
    }
}
