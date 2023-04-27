using EnglishCentreManagement.Database;
using EnglishCentreManagement.Dialog;
using EnglishCentreManagement.Interfaces;
using EnglishCentreManagement.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace EnglishCentreManagement.ViewModel
{
    public class ManageClassroomViewModel : BaseViewModel
    {
        private List<Classroom> _listClassrooms;
    
        private IClassRoomDao classRoomDao = new ClassRoomDao();
        private Classroom _currentClassroom = new Classroom();

        //public ICommand AddClassRoomCommand { get;set; }
        public ICommand DeleteClassRoomCommand { get; set; }
        public ICommand ShowInputClassroomDialog { get; set; }


        public ManageClassroomViewModel()
        {
            LoadClassroom();
          
            //AddClassRoomCommand = new RelayCommand<object>(CanExecuteAddClassroomCommand, ExecuteAddClassroomCommand);
            DeleteClassRoomCommand = new RelayCommand<string>(CanExecuteDeleteClassRoomCommand, ExecuteDeleteClassRoomCommand);
            ShowInputClassroomDialog = new RelayCommand<object>(ExecuteShowInputClassroomDialog);
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

        public List<Classroom> ListClassrooms 
        { 
            get => _listClassrooms; 
            set
            {
                _listClassrooms = value;
                OnPropertyChanged(nameof(ListClassrooms));  
            }
        }

        //private void ExecuteAddClassroomCommand(object obj)
        //{
        //    classRoomDao.Add(CurrentClassroom);
        //    LoadClassroom();
        //}

        //private bool CanExecuteAddClassroomCommand(object obj)
        //{
        //    bool validValue = false;

        //    if (CurrentClassroom != null)
        //    {
        //        if (CurrentClassroom.IDTeacher == null || CurrentClassroom.IDClassroom == null || CurrentClassroom.RoomNum == null || CurrentClassroom.MaxNumStudent.ToString() == null || CurrentClassroom.IDCourse == null || CurrentClassroom.StartingDate.ToString() == null || CurrentClassroom.EndingDate.ToString() == null|| CurrentClassroom.StudyDate == null || CurrentClassroom.IDShift == null)
        //            validValue = false;
        //        else
        //            validValue = true;
        //    }

        //    return validValue;
        //}

        private void ExecuteDeleteClassRoomCommand(string id)
        {
            CurrentClassroom.IDClassroom = id;
            classRoomDao.Delete(CurrentClassroom);
            Classroom? classroom = ListClassrooms.FirstOrDefault(obj => obj.IDClassroom.Equals(id));
            LoadClassroom();
        }

        private bool CanExecuteDeleteClassRoomCommand(object obj)
        {
            //return CanExecuteAddClassroomCommand(obj);
            return true;
        }


        private void ExecuteShowInputClassroomDialog(object obj)
        {
            Window dialog = new InputClassroomInformation();
            dialog.ShowDialog();
            CurrentClassroom = ((InputClassromInformationViewModel)dialog.DataContext).CurrentClassroom;
            classRoomDao.Add(CurrentClassroom);
            LoadClassroom();
        }

        private void LoadClassroom()
        {
            DataTable dtClassroom = classRoomDao.getClassRoomDAO();
            ListClassrooms = new List<Classroom>(classRoomDao.fillDataToListClassRoom(dtClassroom));
        }
    }
}
