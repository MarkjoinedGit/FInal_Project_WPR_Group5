﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishCentreManagement.ViewModel
{
    public class StudentViewModel : BaseViewModel
    {
        public StudentViewModel() 
        {
            StudentWindow studentWindow = new StudentWindow();
            studentWindow.ShowDialog();
        }
        
    }
}
