using EnglishCentreManagement.Database;
using EnglishCentreManagement.Interfaces;
using EnglishCentreManagement.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EnglishCentreManagement.ViewModel
{
    public class RegisterViewModel : BaseViewModel
    {
        public ObservableCollection<Classroom> ListClassrooms { get; set; }
        public ClassRoomDao classroomDao = new ClassRoomDao();
        private Student _currentStudent = CurrentUser.Instance.CurrentStudent;
        private Classroom _currentClassroom;
        private IRegisterDao registerDao = new RegisterDao();

        public ICommand RegisterClassroom { get; set; }

        public RegisterViewModel() 
        {
            DataTable dtClassroom = classroomDao.getClassRoomDAO();
            ListClassrooms = new ObservableCollection<Classroom>(classroomDao.fillDataToListClassRoom(dtClassroom));
            RegisterClassroom = new RelayCommand<object>(CanExecuteRegisterClassroom, ExecuteRegisterClassroom);
        }

        public Student CurrentStudent {  get => _currentStudent; }
        public Classroom CurrentClassroom { get => _currentClassroom; set => _currentClassroom=value; }

        private void ExecuteRegisterClassroom(object obj)
        {
            registerDao.Add(CurrentStudent, CurrentClassroom);
        }

        private bool CanExecuteRegisterClassroom(object obj)
        {
            if(_currentClassroom == null) 
                return false;
            else if (_currentStudent.RankLevel < _currentClassroom.ClassCourse.InputLevel)
                return false;
           
            return true;
        }
    }
}
