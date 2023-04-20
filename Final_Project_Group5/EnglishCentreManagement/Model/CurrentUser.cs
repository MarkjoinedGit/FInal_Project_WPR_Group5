﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishCentreManagement.Model
{
    public class CurrentUser
    {
        private static CurrentUser? instance;
        private Student? std;
        private Teacher? tea;
        private Manager? mng;
        private Enterprise_Infor? enterprise_Infor;

        public static CurrentUser Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CurrentUser();
                }
                return instance;
            }
        }

        public Student CurrentStudent { get => std; set => std = value; }
        public Teacher CurrentTeacher { get => tea; set => tea = value; }
        public Manager CurrentManager { get => mng; set => mng = value; }
        public Enterprise_Infor Enterprise_Infor { get => enterprise_Infor; set => enterprise_Infor=value; }

        public bool isStudent()
        {
            return string.Equals(enterprise_Infor?.Title, "HV");
        }

        public bool isTeacher()
        {
            return string.Equals(enterprise_Infor?.Title, "GV");
        }

        public bool isManager()
        {
            return string.Equals(enterprise_Infor?.Title, "QL");
        }
    }
}
