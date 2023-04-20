﻿using EnglishCentreManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishCentreManagement.Interfaces
{
    public interface IStudentDao
    {
        void Add(Student Std);
        void Delete(Student Std);
        void Update(Student Std);
        Student getById(string id);
    }
}