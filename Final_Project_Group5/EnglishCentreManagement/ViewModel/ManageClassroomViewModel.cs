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
using System.Xml.Linq;

namespace EnglishCentreManagement.ViewModel
{
    public class ManageClassroomViewModel : BaseViewModel
    {
        private ObservableCollection<Classroom> _listClassrooms;
        public ObservableCollection<string> ListShift { get; set; }
        public ObservableCollection<string> ListStudyDate { get; set; }
        private IClassRoomDao classRoomDao = new ClassRoomDao();
        private Classroom _currentClassroom = new Classroom();
        private string _idTeacher;
        private string _idCourse;
        private string _idShift;

        public ICommand DeleteClassRoomCommand { get; set; }
        public ICommand ShowInputClassroomDialog {  get; set; }

        public ManageClassroomViewModel()
        {
            LoadClassroom();
            ListShift = new ObservableCollection<string>(ShiftDAO.getAllShiftID());
            ListStudyDate = new ObservableCollection<string>(classRoomDao.GetListStudyDate());
            DeleteClassRoomCommand = new RelayCommand<string>(/*CanExecuteDeleteClassRoomCommand,*/ ExecuteDeleteClassRoomCommand);
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

        public string IdTeacher
        {
            get => _idTeacher;
            set
            {
                _idTeacher = value;
                ITeacherDao teacherDao = new TeacherDAO();
                CurrentClassroom.ClassTeacher = teacherDao.getByID(IdTeacher);
                OnPropertyChanged(nameof(IdTeacher));
            }
        }

        public string IdCourse 
        { 
            get => _idCourse;
            set
            {
                _idCourse = value;
                CurrentClassroom.ClassCourse = CourseDAO.findCourseByID(IdCourse);
                OnPropertyChanged(nameof(IdCourse));
            }
        }

        public string IdShift 
        { 
            get => _idShift;
            set
            {
                _idShift = value;
                CurrentClassroom.ClassShift = ShiftDAO.findShiftByID(IdShift);
                OnPropertyChanged(nameof(IdShift));
            }
        }


        public ObservableCollection<Classroom> ListClassrooms 
        { 
            get => _listClassrooms; 
            set 
            { 
                _listClassrooms = value; 
                OnPropertyChanged(nameof(ListClassrooms)); 
            } 
        }

        private void ExecuteAddClassroomCommand(object obj)
        {
            classRoomDao.Add(CurrentClassroom);
            LoadClassroom();
            //ListClassrooms.Add(ListClassrooms.Last());
        }

        private bool CanExecuteAddClassroomCommand(object obj)
        {
            bool validValue = false;

            if (CurrentClassroom != null)
            {
                if (CurrentClassroom.ClassTeacher == null || CurrentClassroom.IDClassroom == null || CurrentClassroom.RoomNum == null || CurrentClassroom.MaxNumStudent.ToString() == null || CurrentClassroom.ClassCourse == null || CurrentClassroom.StartingDate.ToString() == null || CurrentClassroom.EndingDate.ToString() == null|| CurrentClassroom.StudyDate == null || CurrentClassroom.ClassShift == null)
                    validValue = false;
                else
                    validValue = true;
            }

            return validValue;
        }

        private void ExecuteDeleteClassRoomCommand(string id)
        {
            CurrentClassroom.IDClassroom = id;
            classRoomDao.Delete(CurrentClassroom);
            Classroom? classroom = ListClassrooms.FirstOrDefault(obj => obj.IDClassroom.Equals(id));
            LoadClassroom();
        }

        private bool CanExecuteDeleteClassRoomCommand(object obj)
        {
            return CurrentUser.Instance.isManager() ? true:false;
        }

        private void ExecuteShowInputClassroomDialog(object obj)
        {
            Window dialog = new InputClassroomDialog();
            dialog.ShowDialog();
        }

        private void LoadClassroom()
        {
            DataTable dtClassroom = classRoomDao.getClassRoomDAO();
            ListClassrooms = new ObservableCollection<Classroom>(classRoomDao.fillDataToListClassRoom(dtClassroom));
        }
    }
}
