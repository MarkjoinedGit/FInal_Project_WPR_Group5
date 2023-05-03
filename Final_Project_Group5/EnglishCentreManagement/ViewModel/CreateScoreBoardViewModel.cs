using EnglishCentreManagement.Database;
using EnglishCentreManagement.Interfaces;
using EnglishCentreManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EnglishCentreManagement.ViewModel
{
    public class CreateScoreBoardViewModel : BaseViewModel
    {
        private string _idtest;
        private List<TestResult> _results = new List<TestResult>();

        private IResultDAO resultDAO = new ResultDAO();

        public ICommand UpdateScoreBoardCommand { get; }

        public string IDTest { get => _idtest; set => _idtest=value; }
        public List<TestResult> Results 
        {
            get => _results; 
            set
            {
                _results = value;
                OnPropertyChanged(nameof(Results)); 
            }
        }

        public CreateScoreBoardViewModel(string idTest)
        {
            _idtest = idTest;
            LoadTestResult();
            UpdateScoreBoardCommand = new RelayCommand<object>(ExcuteUpdateScoreBoardCommand);
        }

        private void LoadTestResult()
        {
            Results = resultDAO.getResultByIdTest(IDTest);
        }

        private void ExcuteUpdateScoreBoardCommand(object obj)
        {
            resultDAO.UpdateTestResultByList(Results);
            LoadTestResult();
        }
    }
}
