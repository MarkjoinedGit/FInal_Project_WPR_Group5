using EnglishCentreManagement.Database;
using EnglishCentreManagement.Dialog.DisplayList;
using EnglishCentreManagement.Interfaces;
using EnglishCentreManagement.Model;
using EnglishCentreManagement.ViewModel.Dialog.DisplayList;
using EnglishCentreManagement.ViewModel.UserControl;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace EnglishCentreManagement.ViewModel.Dialog
{
    public class InputClassromInformationViewModel : BaseViewModel
    {
        private bool _canReadonlyId = false;
        private string tidCourse = "";
        private string tidClassroom = "";
        private int tnumbStudent;
        private DateTime tStartingDay = DateTime.Now;
        private DateTime tEndingDay = DateTime.Now;
        private string tStudyDate = "";
        private string tidShift = "";
        private string troomNum = "";
        private Classroom _currentClassroom = new Classroom();

        private IClassRoomDao classRoomDao = new ClassRoomDao();
        private IShiftDAO shiftDAO = new ShiftDAO();

        public List<string> ListShift { get; set; }
        public List<string> ListStudyDate { get; set; }

        public ICommand AddOrUpdateClassroomCommand { get; }
        public ICommand ShowAllCourseDialogCommand { get; }
        public ICommand ShowAvailableRoomCommand { get; }
        public ICommand ExitCommand { get; }

        public bool CanReadonlId { get => _canReadonlyId; set => _canReadonlyId=value; }

        public Classroom CurrentClassroom
        {
            get => _currentClassroom;
            set
            {
                _currentClassroom = value;
                OnPropertyChanged(nameof(CurrentClassroom));
            }
        }

        public string TidCourse 
        { 
            get => tidCourse; 
            set
            {
                tidCourse = value;
                CurrentClassroom.IDCourse = tidCourse;
                OnPropertyChanged(nameof(TidCourse));
            }
        }
        public string TidClassroom 
        { 
            get => tidClassroom; 
            set
            {
                tidClassroom = value;
                CurrentClassroom.IDClassroom = tidClassroom;
                OnPropertyChanged(nameof(TidClassroom));
            }
        }
        public int TnumbStudent 
        {
            get => tnumbStudent; 
            set
            {
                tnumbStudent = value;
                CurrentClassroom.MaxNumStudent = tnumbStudent;
                OnPropertyChanged(nameof(TnumbStudent));
            }
        }
        public DateTime TStartingDay 
        {
            get => tStartingDay; 
            set
            {
                tStartingDay = value;
                CurrentClassroom.StartingDate = tStartingDay;
                TroomNum = "";
                OnPropertyChanged(nameof(TStartingDay));
            }
        }
        public DateTime TEndingDay 
        { 
            get => tEndingDay; 
            set
            {
                tEndingDay = value;
                CurrentClassroom.EndingDate = tEndingDay;
                TroomNum = "";
                OnPropertyChanged(nameof(TEndingDay));
            }
        }
        public string TStudyDate 
        { 
            get => tStudyDate; 
            set
            { 
                tStudyDate = value;
                CurrentClassroom.StudyDate = tStudyDate;
                OnPropertyChanged(nameof(TStudyDate));
            }
        }
        public string TidShift 
        {
            get => tidShift; 
            set
            {
                tidShift = value;
                CurrentClassroom.IDShift = tidShift;
                OnPropertyChanged(nameof(TidShift));
            }
        }
        public string TroomNum 
        {
            get => troomNum; 
            set
            {
                troomNum = value;
                CurrentClassroom.RoomNum = troomNum;
                OnPropertyChanged(nameof(TroomNum));
            }
        }

        public InputClassromInformationViewModel()
        {
            ListStudyDate = new List<string>(classRoomDao.GetListStudyDate());
            ListShift = new List<string>(shiftDAO.getAllShiftID());
            AddOrUpdateClassroomCommand = new RelayCommand<Window>(CanExecuteAddOrUpdateClassroomCommand, ExecuteAddOrUpdateClassroomCommand);
            ShowAllCourseDialogCommand = new RelayCommand<object>(ExecuteShowAllCourseDialogCommand);
            ShowAvailableRoomCommand = new RelayCommand<object>(ExecuteShowAvailableRoomCommand);
            ExitCommand = new RelayCommand<Window>(ExcuteExitCommand);
        }

        private void ExecuteAddOrUpdateClassroomCommand(Window obj)
        {
            obj.Close();
        }

        private bool CanExecuteAddOrUpdateClassroomCommand(Window obj)
        {
            bool validValue = false;

            if (CurrentClassroom.IsHaveNullValue())
                validValue = false;
            else
                validValue = true;

            return validValue;
        }

        private void ExecuteShowAllCourseDialogCommand(object obj)
        {
            Window dialog = new DisplayAllCourseDialog();
            dialog.ShowDialog();
            TidCourse = ((DisplayAllCourseViewModel)dialog.DataContext).SelectedCourse.IDCourse;
        }

        private void ExecuteShowAvailableRoomCommand(object obj)
        {
            Window dialog = new DisplayRoomAvailableDialog();
            ((DisplayRoomAvailableViewModel)dialog.DataContext).SelectedClassroom = CurrentClassroom;
            dialog.ShowDialog();
            TroomNum = ((DisplayRoomAvailableViewModel)dialog.DataContext).SelectedRoom.Name;
        }

        private void ExcuteExitCommand(Window obj)
        {
            CurrentClassroom = new Classroom();
            obj.Close();
        }

    }
}
