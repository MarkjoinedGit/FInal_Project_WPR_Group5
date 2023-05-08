using EnglishCentreManagement.Database;
using EnglishCentreManagement.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace EnglishCentreManagement.ViewModel
{
    public class ControlScheduleViewModel : BaseViewModel
    {
        private Student _crtStudent;
        private BaseViewModel _currentChildView;
        private List<Shift> _listShifts = new List<Shift>();
        private List<Classroom> _listClassrooms = new List<Classroom>();
        private List<Schedule> _listSchedules = new List<Schedule>();

        //... Properties
       
       
        // DAO
        private ScheduleDAO _scheduleDAO = new ScheduleDAO();
        private ShiftDAO _shiftDAO = new ShiftDAO();
        private ClassRoomDao _classroomDAO=new ClassRoomDao();
        // Data Table for Schedule
        //... Binding
        public string txtInforStu { get; set; }
        public string txtTimeStudStart { get; set; }
        public string txtTimeStudEnd { get;set; }
        public string txtAbsent { get; set; }
        private List<string> _lstringComboBox =new List<string>();
        private List<Schedule> _schedules = new List<Schedule>();
        public ICommand ShowYourScheduleOnWeek { get; set; }


        public string IndexWeek { get; set; }
        public List<string> LstringComboBox{ get => _lstringComboBox; set => _lstringComboBox = value; }
        public List<Schedule> Schedules { get => _schedules; set => _schedules = value; }

        public ControlScheduleViewModel()
        { 
            LoadSchedule();
            ShowYourScheduleOnWeek = new RelayCommand<Action>(ExecuteShowYourScheduleOnWeek);
        }
        public void LoadSchedule()
        {
            //User
            LoadUserCurrentData();
            //Set Data
            _listClassrooms = _classroomDAO.GetListRegisteredClassroom(_crtStudent);
            _listShifts = ScheduleDAO.FindShiftForClassByClass(_listClassrooms);

            txtInforStu = _crtStudent.NamePerson + " - " + _crtStudent.Enter_Infor.ID;
            txtTimeStudStart = _listClassrooms[0].StartingDate.ToString("dd.MM.yyyy") ;
            txtTimeStudEnd = _listClassrooms[0].EndingDate.ToString("dd.MM.yyyy");
            txtAbsent = "0";

            DataForComboBoxWeek(_listClassrooms[0]);
            LoadDataGrid();
        }

        private void ExecuteShowYourScheduleOnWeek(Action obj)
        {
            int numWeek=int.Parse(IndexWeek);
            int maxWeek = FindIndexWeek(_listClassrooms[0].StartingDate, _listClassrooms[0].EndingDate);
            if (numWeek < 0) IndexWeek = "1";
            else if (int.Parse(IndexWeek) > maxWeek) IndexWeek = maxWeek.ToString();
            else
            {
                txtTimeStudStart = (_listClassrooms[0].StartingDate.AddDays(7*numWeek)).ToString("dd.MM.yyyy") ;
                txtTimeStudEnd = (_listClassrooms[0].StartingDate.AddDays(7 * numWeek + 7)).ToString("dd.MM.yyyy");
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
                            txtDetailTimeStart = _shiftDAO.findShiftByID(classroom.IDShift).StartingTime.ToString(),
                            txtDetailTimeEnd = _shiftDAO.findShiftByID(classroom.IDShift).Endingtime.ToString(),

                            IdClassMonday = classroom.IDClassroom,
                            NameTeacherMonday = ScheduleDAO.FindTeacherByIdClass(classroom.IDClassroom).NamePerson,
                            RoomNumMonday = classroom.RoomNum,

                            IdClassWednesday = classroom.IDClassroom,
                            NameTeacherWednesday = ScheduleDAO.FindTeacherByIdClass(classroom.IDClassroom).NamePerson,
                            RoomNumWednesday = classroom.RoomNum,

                            IdClassFriday = classroom.IDClassroom,
                            NameTeacherFriday = ScheduleDAO.FindTeacherByIdClass(classroom.IDClassroom).NamePerson,
                            RoomNumFriday = classroom.RoomNum
                        });
                    if (classroom.StudyDate == "T3-T5-T7")
                        Schedules.Add(new Schedule()
                        {
                            ShiftCode = classroom.IDShift,
                            txtDetailTimeStart = _shiftDAO.findShiftByID(classroom.IDShift).StartingTime.ToString(),
                            txtDetailTimeEnd = _shiftDAO.findShiftByID(classroom.IDShift).Endingtime.ToString(),

                            IdClassTuesday = classroom.IDClassroom,
                            NameTeacherTuesday = ScheduleDAO.FindTeacherByIdClass(classroom.IDClassroom).NamePerson,
                            RoomNumTuesday = classroom.RoomNum,

                            IdClassThusday = classroom.IDClassroom,
                            NameTeacherThusday =ScheduleDAO.FindTeacherByIdClass(classroom.IDClassroom).NamePerson,
                            RoomNumThusday = classroom.RoomNum,

                            IdClassSaturday = classroom.IDClassroom,
                            NameTeacherSaturday = ScheduleDAO.FindTeacherByIdClass(classroom.IDClassroom).NamePerson,
                            RoomNumSaturday = classroom.RoomNum
                        });
                
                }
            }
        }
    }

}
