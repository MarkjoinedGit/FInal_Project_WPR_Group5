using EnglishCentreManagement.Database;
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
        private Student _currentStudent;
        private Classroom _currentClassroom;

        public ICommand RegisterClassroom { get; set; }

        public RegisterViewModel(Student currentStudent) 
        {
            this._currentStudent = currentStudent;

            DataTable dtClassroom = classroomDao.getClassRoomDAO();
            ListClassrooms = new ObservableCollection<Classroom>(classroomDao.fillDataToListClassRoom(dtClassroom));
            RegisterClassroom = new RelayCommand<object>(CanExecuteRegisterClassroom, ExecuteRegisterClassroom);
        }

        public Student CurrentStudent {  get => _currentStudent; set => _currentStudent = value; }
        public Classroom CurrentClassroom { get => _currentClassroom; set => _currentClassroom=value; }

        private void ExecuteRegisterClassroom(object obj)
        {
            throw new NotImplementedException();
        }

        private bool CanExecuteRegisterClassroom(object obj)
        {
            if(_currentStudent.RankLevel < _currentClassroom.ClassCourse.InputLevel || _currentClassroom == null)
                return false;
            return true;
        }
    }
}
