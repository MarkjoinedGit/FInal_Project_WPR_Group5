using EnglishCentreManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishCentreManagement.Interfaces
{
    public interface ITeacherDao
    {
        void Add(Teacher Tea);
        void Delete(Teacher Tea);
        void Update(Teacher Tea);
        bool canGetByID(string id);
        Teacher? getByID(string id);
    }
}
