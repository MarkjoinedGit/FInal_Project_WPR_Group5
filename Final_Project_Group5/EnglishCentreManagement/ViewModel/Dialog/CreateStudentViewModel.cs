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
    public class CreateStudentViewModel:BaseViewModel
    {
        private bool _canReadonlId = false;
        private bool _canReadonlyPassword=false;
        private bool _canReadonlyUserName=false;
        public Person _person=new Person();

        private Student _currentStudent=new Student();
        public ObservableCollection<string> ListGender { get; set; }
        public ObservableCollection<double> Levels { get; set; }
        public Student CurrentStudent 
        { 
            get => _currentStudent; 
            set
            {
                _currentStudent = value;
                OnPropertyChanged(nameof(CurrentStudent));
            }
        }
        public bool CanReadonlId { get => _canReadonlId; set => _canReadonlId = value; }
        public bool CanReadonlyPassword { get => _canReadonlyPassword; set => _canReadonlyPassword = value; }
        public bool CanReadonlyUserName { get => _canReadonlyUserName; set => _canReadonlyUserName = value; }
        
        public ICommand AddCommand { get; }
        public ICommand CancelCommand { get; }
        public ICommand SaveCommand { get; }
        public CreateStudentViewModel()
        {
            LoadStudent();
            AddCommand = new RelayCommand<Window>(CanExecuteAddCommand, ExecuteAddCommand);
            CancelCommand = new RelayCommand<Window>(ExecuteCancelCommand);
            SaveCommand = new RelayCommand<Window>(CanExecuteSaveCommand,ExecuteSaveCommand);
        }

        private void ExecuteSaveCommand(Window obj)
        {
            obj.Close();
        }

        private bool CanExecuteSaveCommand(Window obj)
        {
            bool vaidData = false;
            if (CurrentStudent.IsHaveNullValue())
                vaidData = false;
            else
                vaidData = true;
            return vaidData;
        }

        private void ExecuteCancelCommand(Window obj)
        {
            CurrentStudent=new Student();
            obj.Close();
        }

        private void ExecuteAddCommand(Window obj)
        {
            obj.Close();
        }

        private bool CanExecuteAddCommand(object obj)
        {
            bool vaidData=false;
            if(CurrentStudent.IsHaveNullValue())
                vaidData=false;
            else 
                vaidData=true;
            return vaidData;
        }
        public void LoadStudent()
        {
            ListGender = _person.ListGender();
            Levels=_person.ListRankLevel();
        }


    }
}
