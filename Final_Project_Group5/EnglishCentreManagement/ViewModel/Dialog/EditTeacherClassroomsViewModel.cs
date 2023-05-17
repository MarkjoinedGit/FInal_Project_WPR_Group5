using EnglishCentreManagement.Database;
using EnglishCentreManagement.Dialog;
using EnglishCentreManagement.Interfaces;
using EnglishCentreManagement.Model;
using EnglishCentreManagement.ViewModel.UserControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace EnglishCentreManagement.ViewModel.Dialog
{
    public class EditTeacherClassroomsViewModel : BaseViewModel
    {
        private static Classroom _currentClassroom = new Classroom();
        private Test _currentTest = new Test();
        private List<Test> listTest = new List<Test>();

        private List<Student> listStudent = new List<Student>();

        private IStudentDao stdDao = new StudentDAO();
        private ITestDAO testDAO = new TestDAO();

        public ICommand ShowAddNewTestCommand { get; }
        public ICommand DeleteTestCommand { get; }
        public ICommand ShowCreatScoreBoardCommand { get; }


        public static Classroom CurrentClassroom { get => _currentClassroom; set => _currentClassroom = value; }
        public Test CurrentTest
        {
            get => _currentTest;
            set
            {
                _currentTest = value;
                OnPropertyChanged(nameof(CurrentTest));
            }
        }
        public List<Test> ListTest
        {
            get => listTest;
            set
            {
                listTest = value;
                OnPropertyChanged(nameof(listTest));
            }
        }
        public List<Student> ListStudent
        {
            get => listStudent;
            set
            {
                listStudent = value;
                OnPropertyChanged(nameof(ListStudent));
            }
        }

        public EditTeacherClassroomsViewModel(Classroom CurrentClassroom)
        {
            _currentClassroom = CurrentClassroom;
            LoadStudent();
            Loadtest();
            ShowAddNewTestCommand = new RelayCommand<object>(ExcuteShowAddNewTestCommand);
            DeleteTestCommand = new RelayCommand<string>(ExcuteDeleteTestCommand);
            ShowCreatScoreBoardCommand = new RelayCommand<string>(ExcuteShowCreatScoreBoardCommand);
        }

        private void LoadStudent()
        {
            ListStudent = stdDao.GetListStudent(CurrentClassroom);
        }

        private void Loadtest()
        {
            ListTest = testDAO.getListByIDClass(CurrentClassroom.IDClassroom);
        }

        private void ExcuteShowAddNewTestCommand(object obj)
        {
            Window dialog = new AddNewTestDialog();
            ((AddNewTestViewModel)dialog.DataContext).ClassID = CurrentClassroom.IDClassroom;
            dialog.ShowDialog();
            Loadtest();
        }

        private void ExcuteShowCreatScoreBoardCommand(string idtest)
        {
            Window dialog = new CreateScoreBoardDialog(idtest);
            dialog.ShowDialog();
        }

        private void ExcuteDeleteTestCommand(string idtest)
        {
            testDAO.DeleteTestByID(idtest);
            Loadtest();
        }
    }
}
