﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishCentreManagement.ViewModel
{
    public class TeacherViewModel
    {
        public TeacherViewModel() 
        { 
            TeacherWindow teacherWindow = new TeacherWindow();
            teacherWindow.ShowDialog();
        }
    }
}
