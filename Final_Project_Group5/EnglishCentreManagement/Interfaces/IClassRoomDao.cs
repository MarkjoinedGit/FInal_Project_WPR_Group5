using EnglishCentreManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishCentreManagement.Interfaces
{
    public interface IClassRoomDao
    {
        bool ValidateValue(Classroom cls);
        void Add(Classroom cls);
        void Delete(Classroom cls);
        void Update(Classroom cls);
        void AddStudent(Classroom cls, Student st);
    }
}
