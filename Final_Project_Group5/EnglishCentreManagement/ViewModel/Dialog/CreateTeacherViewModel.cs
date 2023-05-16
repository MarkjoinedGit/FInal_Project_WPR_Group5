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
    public class CreateTeacherViewModel:BaseViewModel
    {
        private bool _canReadonlId = false;
        private bool _canReadonlyPassword = false;
        private bool _canReadonlyUserName = false;
        public Person _person = new Person();

        private Teacher _currentTeacher=new Teacher();  
        public Teacher CurrentTeacher
        {
            get => _currentTeacher;
            set
            {
                _currentTeacher = value;
                OnPropertyChanged(nameof(CurrentTeacher));
            }
        }

        public ObservableCollection<string> ListGender { get; set; }
        public ObservableCollection<double> Levels { get; set; }
        public bool CanReadonlId { get => _canReadonlId; set => _canReadonlId = value; }
        public bool CanReadonlyPassword { get => _canReadonlyPassword; set => _canReadonlyPassword = value; }
        public bool CanReadonlyUserName { get => _canReadonlyUserName; set => _canReadonlyUserName = value; }

        public ICommand AddOrSaveCommand { get; }
        public ICommand CancelCommand { get; }
        public CreateTeacherViewModel()
        {
            LoadStudent();
            AddOrSaveCommand = new RelayCommand<Window>(CanExecuteAddOrSaveCommand,ExecuteAddOrSaveCommand);
            CancelCommand = new RelayCommand<Window>(ExecuteCancelCommand);
        }

        private void ExecuteAddOrSaveCommand(Window obj)
        {
            obj.Close();
        }

        private bool CanExecuteAddOrSaveCommand(Window obj)
        {
            bool vaidData = false;
            if (CurrentTeacher.IsHaveNullValue())
                vaidData = false;
            else
                vaidData = true;
            return vaidData;
        }

        private void ExecuteCancelCommand(Window obj)
        {
            CurrentTeacher = new Teacher();
            obj.Close();
        }
        public void LoadStudent()
        {
            ListGender = _person.ListGender();
            Levels=_person.ListRankLevel();
        }

    }
}
