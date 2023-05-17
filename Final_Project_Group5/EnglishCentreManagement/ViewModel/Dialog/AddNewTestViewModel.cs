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
        private Test _currentTest;

        private ITestDAO testDAO = new TestDAO();

        public ICommand AddNewTestCommand { get; }
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
    }
}
