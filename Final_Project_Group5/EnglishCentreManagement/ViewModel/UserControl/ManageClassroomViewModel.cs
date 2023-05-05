using EnglishCentreManagement.Database;
using EnglishCentreManagement.Dialog;
using EnglishCentreManagement.Interfaces;
using EnglishCentreManagement.Model;
using EnglishCentreManagement.ViewModel.Dialog;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace EnglishCentreManagement.ViewModel.UserControl
{
    public class ManageClassroomViewModel : BaseViewModel
    {
        private Classroom _currentClassroom = new Classroom();
        private List<Classroom> _listClassrooms = new List<Classroom>();

        private IClassRoomDao classRoomDao = new ClassRoomDao();

        public ICommand DeleteClassRoomCommand { get; set; }
        public ICommand ShowInputClassroomDialog { get; set; }


        public ManageClassroomViewModel()
        {
            LoadClassroom();

            DeleteClassRoomCommand = new RelayCommand<string>(CanExecuteDeleteClassRoomCommand, ExecuteDeleteClassRoomCommand);
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

        public List<Classroom> ListClassrooms
        {
            get => _listClassrooms;
            set
            {
                _listClassrooms = value;
                OnPropertyChanged(nameof(ListClassrooms));
            }
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
            //return CanExecuteAddClassroomCommand(obj);
            return true;
        }


        private void ExecuteShowInputClassroomDialog(object obj)
        {
            Window dialog = new InputClassroomInformation();
            dialog.ShowDialog();
            CurrentClassroom = ((InputClassromInformationViewModel)dialog.DataContext).CurrentClassroom;
            classRoomDao.Add(CurrentClassroom);
            LoadClassroom();
        }

        private void LoadClassroom()
        {
            DataTable dtClassroom = classRoomDao.getClassRoomDAO();
            ListClassrooms = new List<Classroom>(classRoomDao.fillDataToListClassRoom(dtClassroom));
        }
    }
}
