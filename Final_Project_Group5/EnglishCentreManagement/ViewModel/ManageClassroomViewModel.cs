﻿using EnglishCentreManagement.Database;
using EnglishCentreManagement.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EnglishCentreManagement.ViewModel
{
    public class ManageClassroomViewModel : BaseViewModel
    {
        public ObservableCollection<Classroom> ListClassrooms { get; set; }
        public ObservableCollection<string> ListShift { get; set; }
        public ObservableCollection<string> ListStudyDate { get; set; }
        private ClassRoomDao classRoomDao = new ClassRoomDao();
        private Classroom _currentClassroom = new Classroom();
        private string _idTeacher;
        private string _idCourse;
        private string _idShift;

        public ICommand AddClassRoomCommand { get;set; }
        public ICommand DeleteClassRoomCommand { get; set; }


        public ManageClassroomViewModel()
        {
            DataTable dtClassroom = classRoomDao.getClassRoomDAO();
            ListClassrooms = new ObservableCollection<Classroom>(classRoomDao.fillDataToListClassRoom(dtClassroom));
            ListShift = new ObservableCollection<string>(ShiftDAO.getAllShiftID());
            AddClassRoomCommand = new RelayCommand<object>(CanExecuteAddClassroomCommand, ExecuteAddClassroomCommand);
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

        public string IdTeacher
        {
            get => _idTeacher;
            set
            {
                _idTeacher = value;
                CurrentClassroom.ClassTeacher = TeacherDAO.findTeacherByID(IdTeacher);
                OnPropertyChanged(nameof(IdTeacher));
            }
        }

        public string IdCourse 
        { 
            get => _idCourse;
            set
            {
                _idCourse = value;
                CurrentClassroom.ClassCourse = CourseDAO.findCourseByID(IdCourse);
                OnPropertyChanged(nameof(IdCourse));
            }
        }

        public string IdShift 
        { 
            get => _idShift;
            set
            {
                _idShift = value;
                CurrentClassroom.ClassShift = ShiftDAO.findShiftByID(IdShift);
                OnPropertyChanged(nameof(IdShift));
            }
        }

        private void ExecuteAddClassroomCommand(object obj)
        {
            classRoomDao.Add(CurrentClassroom);
            ListClassrooms.Add(ListClassrooms.Last());
        }

        private bool CanExecuteAddClassroomCommand(object obj)
        {
            bool validValue = false;

            if (CurrentClassroom != null)
            {
                if (CurrentClassroom.ClassTeacher == null || CurrentClassroom.IDClassroom == null || CurrentClassroom.RoomNum == null || CurrentClassroom.MaxNumStudent.ToString() == null || CurrentClassroom.ClassCourse == null || CurrentClassroom.StartingDate.ToString() == null || CurrentClassroom.EndingDate.ToString() == null|| CurrentClassroom.StudyDate == null || CurrentClassroom.ClassShift == null)
                    validValue = false;
                else
                    validValue = true;
            }

            return validValue;
        }

    }
}