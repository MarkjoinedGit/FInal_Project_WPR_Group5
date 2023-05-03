﻿using EnglishCentreManagement.Database;
using EnglishCentreManagement.Dialog;
using EnglishCentreManagement.Interfaces;
using EnglishCentreManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace EnglishCentreManagement.ViewModel
{
    public class ManageTeacherClassRoomViewModel : BaseViewModel
    {
        private Classroom _currentClassroom = new Classroom();
        private List<Classroom> yourClassRoom = new List<Classroom>();

        private IClassRoomDao clsDao = new ClassRoomDao();

        public ICommand ShowManageClassRoomDialog { get; }

        public List<Classroom> YourClassRoom 
        {
            get => yourClassRoom; 
            set
            {
                yourClassRoom = value;
                OnPropertyChanged(nameof(YourClassRoom));
            }
        }

        public Classroom CurrentClassroom 
        { 
            get => _currentClassroom;
            set
            {
                _currentClassroom = value;
                OnPropertyChanged(nameof(CurrentClassroom));
            }
        }

        public ManageTeacherClassRoomViewModel()
        {
            yourClassRoom = clsDao.GetListTeacherClassroom(CurrentUser.Instance.CurrentTeacher);
            ShowManageClassRoomDialog = new RelayCommand<object>(ExcuteShowManageClassRoomDialog);
        }

        private void ExcuteShowManageClassRoomDialog(object obj)
        {
            Window dialog = new ManageClassroomsDialog(CurrentClassroom);
            dialog.ShowDialog();
        }
    }
}
