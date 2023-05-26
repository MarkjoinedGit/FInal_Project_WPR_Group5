using EnglishCentreManagement.Database;
using EnglishCentreManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EnglishCentreManagement.ViewModel.UserControl
{
    public class YourClassViewModel : BaseViewModel
    {
        private List<Classroom> _listRegisteredClassroom = new List<Classroom>();

        private ClassRoomDao clsDao = new ClassRoomDao();

        public ICommand DeleteRegisteredClassroomCommand { get; set; }

        public List<Classroom> ListRegisteredClassroom
        {
            get => _listRegisteredClassroom;
            set
            {
                _listRegisteredClassroom = value;
                OnPropertyChanged(nameof(ListRegisteredClassroom));
            }
        }

        public YourClassViewModel()
        {
            LoadRegisterdClassroom();
            DeleteRegisteredClassroomCommand = new RelayCommand<string>(ExecuteDeleteRegisteredClassroom);
        }


        private void ExecuteDeleteRegisteredClassroom(string clsid)
        {
            clsDao.DeleteRegisteredClassroom(CurrentUser.Instance.CurrentStudent.Enter_Infor.ID, clsid);
            Classroom? classroom = ListRegisteredClassroom.FirstOrDefault(obj => obj.IDClassroom.Equals(clsid));
            LoadRegisterdClassroom();
        }

        private void LoadRegisterdClassroom()
        {
            ListRegisteredClassroom = clsDao.GetListRegisteredClassroom(CurrentUser.Instance.CurrentStudent);
        }
    }
}
