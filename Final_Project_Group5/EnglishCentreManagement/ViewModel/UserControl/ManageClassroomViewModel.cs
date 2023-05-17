using EnglishCentreManagement.Database;
using EnglishCentreManagement.Dialog;
using EnglishCentreManagement.Dialog.DisplayList;
using EnglishCentreManagement.Interfaces;
using EnglishCentreManagement.Model;
using EnglishCentreManagement.ViewModel.Dialog;
using EnglishCentreManagement.ViewModel.Dialog.DisplayList;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace EnglishCentreManagement.ViewModel.UserControl
{
    public class ManageClassroomViewModel : BaseViewModel
    {
        private Classroom _currentClassroom = new Classroom();
        private List<Classroom> _listClassrooms = new List<Classroom>();

        private IClassRoomDao classRoomDao = new ClassRoomDao();

        public ICommand DeleteClassRoomCommand { get; }
        public ICommand UpdateClassRoomCommand { get; }
        public ICommand ShowInputClassroomDialog { get; }
        public ICommand ShowValidTeacherDialog { get; }

        public ManageClassroomViewModel()
        {
            LoadClassroom();
            DeleteClassRoomCommand = new RelayCommand<string>(CanExecuteDeleteClassRoomCommand, ExecuteDeleteClassRoomCommand);
            UpdateClassRoomCommand = new RelayCommand<string>(ExcuteUpdateClassRoomCommand);
            ShowInputClassroomDialog = new RelayCommand<object>(ExecuteShowInputClassroomDialog);
            ShowValidTeacherDialog = new RelayCommand<object>(CanExecuteShowValidTeacherDialog, ExecuteShowValidTeacherDialog);
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

        private void ExecuteDeleteClassRoomCommand(string id)
        {
            Classroom dltClassroom = new Classroom { IDClassroom = id };
            classRoomDao.Delete(dltClassroom);
            LoadClassroom();
        }

        private bool CanExecuteDeleteClassRoomCommand(object obj)
        {
            //return CanExecuteAddClassroomCommand(obj);
            return true;
        }

        private void ExcuteUpdateClassRoomCommand(string id)
        {
            Window dialog = new InputClassroomInformation();
            ((InputClassromInformationViewModel)dialog.DataContext).CanReadonlId = true;
            ((InputClassromInformationViewModel)dialog.DataContext).CurrentClassroom = classRoomDao.getById(id);
            dialog.ShowDialog();
            CurrentClassroom = ((InputClassromInformationViewModel)dialog.DataContext).CurrentClassroom; 
            if (!CurrentClassroom.IsHaveNullValue())
            {
                classRoomDao.Update(CurrentClassroom);
            }
            LoadClassroom() ;
        }

        private void ExecuteShowInputClassroomDialog(object obj)
        {
            Window dialog = new InputClassroomInformation();
            dialog.ShowDialog();
            CurrentClassroom = ((InputClassromInformationViewModel)dialog.DataContext).CurrentClassroom;
            if(!CurrentClassroom.IsHaveNullValue())
            {
                classRoomDao.Add(CurrentClassroom);
            }
            LoadClassroom();
        }

        private void ExecuteShowValidTeacherDialog(object obj)
        {
            Window dialog = new DisplayValidTeacherDialog();
            ((DisplayValidTeacherViewModel)dialog.DataContext).SelectedClassroom = CurrentClassroom;
            dialog.ShowDialog();
            CurrentClassroom.IDTeacher = ((DisplayValidTeacherViewModel)dialog.DataContext).SelectedTeacher.Enter_Infor.ID ;
            if (!string.IsNullOrEmpty(CurrentClassroom.IDTeacher.Trim()))
            {
                classRoomDao.Update(CurrentClassroom);
            }
            LoadClassroom();
        }

        private bool CanExecuteShowValidTeacherDialog(object obj)
        {
            if(CurrentClassroom == null || CurrentClassroom.IsHaveNullValue())
            {
                return false;
            }
            return true;
        }

        private void LoadClassroom()
        {
            DataTable dtClassroom = classRoomDao.getClassRoomDAO();
            ListClassrooms = new List<Classroom>(classRoomDao.fillDataToListClassRoom(dtClassroom));
        }
    }
}
