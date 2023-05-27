﻿using EnglishCentreManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishCentreManagement.Interfaces
{
    public interface IStatisticsDao
    {
        Statistics CreateStatistics(string idTeacher);
        public void Add(TeacherSalary teac);
        void ClearDatabaseStatistics();

    }
}
