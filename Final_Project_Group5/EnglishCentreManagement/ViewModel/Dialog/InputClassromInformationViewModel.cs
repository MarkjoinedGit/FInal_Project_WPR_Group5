using EnglishCentreManagement.Database;
using EnglishCentreManagement.Interfaces;
using EnglishCentreManagement.Model;
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
        private Classroom _currentClassroom = new Classroom();

        private IClassRoomDao classRoomDao = new ClassRoomDao();
        private IShiftDAO shiftDAO = new ShiftDAO();

        public ObservableCollection<string> ListShift { get; set; }
        public ObservableCollection<string> ListStudyDate { get; set; }

        public ICommand AddOrUpdateClassroomCommand { get; }
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

        public InputClassromInformationViewModel()
        {
            ListStudyDate = new ObservableCollection<string>(classRoomDao.GetListStudyDate());
            ListShift = new ObservableCollection<string>(shiftDAO.getAllShiftID());
            AddOrUpdateClassroomCommand = new RelayCommand<Window>(CanExecuteAddOrUpdateClassroomCommand, ExecuteAddOrUpdateClassroomCommand);
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

        private void ExcuteExitCommand(Window obj)
        {
            CurrentClassroom = new Classroom();
            obj.Close();
        }

    }
}
