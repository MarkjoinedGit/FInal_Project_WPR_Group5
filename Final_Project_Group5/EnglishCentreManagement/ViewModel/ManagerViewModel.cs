﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishCentreManagement.ViewModel
{
    public class ManagerViewModel
    {
        public ManagerViewModel()
        { 
            ManagerWindow managerWindow = new ManagerWindow();
            managerWindow.ShowDialog();
        }   
    }
}
