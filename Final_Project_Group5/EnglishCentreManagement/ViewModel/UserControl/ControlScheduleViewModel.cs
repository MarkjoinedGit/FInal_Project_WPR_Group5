using EnglishCentreManagement.Database;
using EnglishCentreManagement.Model;
using EnglishCentreManagement.ViewModel.UserControl;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace EnglishCentreManagement.ViewModel.UserControl
{
    public class ControlScheduleViewModel : BaseViewModel
    {
        private string _txtInforStu;
        private DateTime _timeStudStart;
        private DateTime _timeStudEnd;
        private Student _crtStudent = new Student();
        private List<Shift> _listShifts = new List<Shift>();
        private List<Classroom> _listClassrooms = new List<Classroom>();
        private List<Schedule> _listSchedules = new List<Schedule>(); 
        private List<string> _lstringComboBox = new List<string>(); 
        private List<Schedule> _schedules = new List<Schedule>();

        private ScheduleDAO _scheduleDAO = new ScheduleDAO();
        private ShiftDAO _shiftDAO = new ShiftDAO();
        private ClassRoomDao _classroomDAO = new ClassRoomDao();

        public string TxtInforStu 
        { 
            get => _txtInforStu; 
            set
            {
                _txtInforStu = value;
                OnPropertyChanged(nameof(TxtInforStu));
            }
        }
        public DateTime TimeStudStart 
        { 
            get => _timeStudStart; 
            set
            {
                _timeStudStart = value;
                OnPropertyChanged(nameof(TimeStudStart));
            }
        }
        public DateTime TimeStudEnd 
        { 
            get => _timeStudEnd;
            set
            {
                _timeStudEnd = value;
                OnPropertyChanged(nameof(TimeStudEnd));
            }
        }
        public string TxtAbsent { get; set; }
        public ICommand ShowYourScheduleOnWeek { get; set; }
        public string IndexWeek { get; set; }
        public List<string> LstringComboBox { get => _lstringComboBox; set => _lstringComboBox = value; }
        public List<Schedule> Schedules { get => _schedules; set => _schedules = value; }
       

        public ControlScheduleViewModel()
        {
            _txtInforStu = "";
            TxtAbsent = "";
            IndexWeek = "";
            LoadUserCurrentData();
            LoadSchedule();
            ShowYourScheduleOnWeek = new RelayCommand<Action>(ExecuteShowYourScheduleOnWeek);
        }
        public void LoadSchedule()
        {
            _listClassrooms = _classroomDAO.GetListRegisteredClassroom(_crtStudent);
            _listShifts = _scheduleDAO.FindShiftForClassByClass(_listClassrooms);

            _txtInforStu = _crtStudent.NamePerson + " - " + _crtStudent.Enter_Infor.ID;
            if(_listClassrooms.Count > 0)
            {
                _timeStudStart =  _listClassrooms[0].StartingDate;
                _timeStudStart = _listClassrooms[0].EndingDate;
                TxtAbsent = "0";

                DataForComboBoxWeek(_listClassrooms[0]);
                LoadDataGrid();
            }
        }

        private void ExecuteShowYourScheduleOnWeek(Action obj)
        {
            int numWeek = int.Parse(IndexWeek);
            int maxWeek = FindIndexWeek(_listClassrooms[0].StartingDate, _listClassrooms[0].EndingDate);
            if (numWeek < 0) IndexWeek = "1";
            else if (int.Parse(IndexWeek) > maxWeek) IndexWeek = maxWeek.ToString();
            else
            {
                TimeStudStart = _listClassrooms[0].StartingDate.AddDays(7*numWeek);
                TimeStudEnd = _listClassrooms[0].StartingDate.AddDays(7 * numWeek + 7);
            }
        }
        private void LoadUserCurrentData()
        {
            _crtStudent = CurrentUser.Instance.CurrentStudent;
        }
        public int FindIndexWeek(DateTime Start, DateTime Date)
        {
            TimeSpan tspan = Date - Start;
            return ((int)(tspan.Days) / 7);
        }
        public void DataForComboBoxWeek(Classroom classroom)
        {
            int maxWeek = FindIndexWeek(classroom.StartingDate, classroom.EndingDate);
            for (int i = 1; i <= maxWeek; i++)
            {
                LstringComboBox.Add(i.ToString());
            }
        }
        public void LoadDataGrid()
        {
            int indexWeek = FindIndexWeek(_listClassrooms[0].StartingDate, DateTime.Now);
            int maxWeek = FindIndexWeek(_listClassrooms[0].StartingDate, _listClassrooms[0].EndingDate);
            foreach (Classroom classroom in _listClassrooms)
            {

                if (DateTime.Now > DateTime.Parse(classroom.EndingDate.ToString())) IndexWeek = "15";
                else
                {
                    if (DateTime.Now <= classroom.StartingDate) IndexWeek = "1";
                    else if (indexWeek < maxWeek)
                        IndexWeek = indexWeek.ToString();
                    if (classroom.StudyDate == "T2-T4-T6")
                        Schedules.Add(new Schedule()
                        {
                            ShiftCode = classroom.IDShift,
                            TxtDetailTimeStart = _shiftDAO.findShiftByID(classroom.IDShift).StartingTime.ToString(),
                            TxtDetailTimeEnd = _shiftDAO.findShiftByID(classroom.IDShift).Endingtime.ToString(),

                            IdClassMonday = classroom.IDClassroom,
                            NameTeacherMonday = _scheduleDAO.FindTeacherByIdClass(classroom.IDClassroom).NamePerson,
                            RoomNumMonday = classroom.RoomNum,

                            IdClassWednesday = classroom.IDClassroom,
                            NameTeacherWednesday = _scheduleDAO.FindTeacherByIdClass(classroom.IDClassroom).NamePerson,
                            RoomNumWednesday = classroom.RoomNum,

                            IdClassFriday = classroom.IDClassroom,
                            NameTeacherFriday = _scheduleDAO.FindTeacherByIdClass(classroom.IDClassroom).NamePerson,
                            RoomNumFriday = classroom.RoomNum
                        });
                    if (classroom.StudyDate == "T3-T5-T7")
                        Schedules.Add(new Schedule()
                        {
                            ShiftCode = classroom.IDShift,
                            TxtDetailTimeStart = _shiftDAO.findShiftByID(classroom.IDShift).StartingTime.ToString(),
                            TxtDetailTimeEnd = _shiftDAO.findShiftByID(classroom.IDShift).Endingtime.ToString(),

                            IdClassTuesday = classroom.IDClassroom,
                            NameTeacherTuesday = _scheduleDAO.FindTeacherByIdClass(classroom.IDClassroom).NamePerson,
                            RoomNumTuesday = classroom.RoomNum,

                            IdClassThursday = classroom.IDClassroom,
                            NameTeacherThursday =_scheduleDAO.FindTeacherByIdClass(classroom.IDClassroom).NamePerson,
                            RoomNumThursday = classroom.RoomNum,

                            IdClassSaturday = classroom.IDClassroom,
                            NameTeacherSaturday = _scheduleDAO.FindTeacherByIdClass(classroom.IDClassroom).NamePerson,
                            RoomNumSaturday = classroom.RoomNum
                        });

                }
            }
        }
    }

}