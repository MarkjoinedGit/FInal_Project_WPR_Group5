using EnglishCentreManagement.Database;
using EnglishCentreManagement.Interfaces;
using EnglishCentreManagement.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace EnglishCentreManagement.ViewModel
{
    public class InputClassromInformationViewModel : BaseViewModel
    {
        private Classroom _currentClassroom = new Classroom(); 
        private IClassRoomDao classRoomDao = new ClassRoomDao();

        public ObservableCollection<string> ListShift { get; set; }
        public ObservableCollection<string> ListStudyDate { get; set; }

        public ICommand AddClassroomCommand { get; set; }

        public InputClassromInformationViewModel()
        {
            ListStudyDate = new ObservableCollection<string>(classRoomDao.GetListStudyDate());
            ListShift = new ObservableCollection<string>(ShiftDAO.getAllShiftID());
            AddClassroomCommand = new RelayCommand<Window>(CanExecuteAddClassroomCommand, ExecuteAddClassroomCommand);
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

        private void ExecuteAddClassroomCommand(Window obj)
        {
            obj.Close();
        }

        private bool CanExecuteAddClassroomCommand(Window obj)
        {
            //bool validValue = false;

            //if (CurrentClassroom != null)
            //{
            //    if (CurrentClassroom.IDTeacher == null || CurrentClassroom.IDClassroom == null || CurrentClassroom.RoomNum == null || CurrentClassroom.MaxNumStudent.ToString() == null || CurrentClassroom.IDCourse == null || CurrentClassroom.StartingDate.ToString() == null || CurrentClassroom.EndingDate.ToString() == null|| CurrentClassroom.StudyDate == null || CurrentClassroom.IDShift == null)
            //        validValue = false;
            //    else
            //        validValue = true;
            //}

            //return validValue;
            return true;
        }

    }
}
