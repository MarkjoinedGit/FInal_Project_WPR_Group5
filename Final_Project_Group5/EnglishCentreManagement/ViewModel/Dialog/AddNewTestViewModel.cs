using EnglishCentreManagement.Database;
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
    public class AddNewTestViewModel : BaseViewModel
    {
        private string _testID = "";
        private string _classID = "";
        private Test _currentTest;

        private ITestDAO testDAO = new TestDAO();

        public ICommand AddNewTestCommand { get; }

        public string TestID 
        { 
            get => _testID; 
            set
            {
                _testID = value;
                CurrentTest.IDTest = _testID;
                OnPropertyChanged(nameof(CurrentTest));
            }
        }
        public string ClassID 
        { 
            get => _classID; 
            set
            {
                _classID = value;
                CurrentTest.IDClassRoom = _classID;
                TestID = AutogenerateID();
                OnPropertyChanged(nameof(ClassID));
            }
        }
        public Test CurrentTest 
        { 
            get => _currentTest; 
            set
            {
                _currentTest = value;
                OnPropertyChanged(nameof(CurrentTest));
            }
        }


        public AddNewTestViewModel()
        {
            _currentTest = new Test();
            AddNewTestCommand = new RelayCommand<Window>(CanExecuteAddNewTestCommand, ExecuteAddNewTestCommand);
        }

        private void ExecuteAddNewTestCommand(Window obj)
        {
            testDAO.Add(CurrentTest);
            obj.Close();
        }

        private bool CanExecuteAddNewTestCommand(Window obj)
        {
            if(CurrentTest.isHaveNullValue())
                return false;
            return true;
        }

        private string AutogenerateID()
        {
            string idTest = "";
            int number = testDAO.getListByIDClass(CurrentTest.IDClassRoom).Count;
            number++;
            idTest = $"TEST{number:000}_{CurrentTest.IDClassRoom}";
            return idTest;
        }
    }
}
