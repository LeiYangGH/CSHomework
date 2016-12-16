using CSMVPAssignment.Model;
using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;
using System.Linq;
namespace CSMVPAssignment.ViewModel
{
    public class TutorialViewModel : ViewModelBase
    {
        public readonly Tutorial tutorial;

        public TutorialViewModel(Tutorial tutorial)
        {
            this.tutorial = tutorial;
            this.TeacherVM = MainViewModel.Instance.ObsTeacherVMs.First(x => x.TeacherID == tutorial.Teacher.TeacherID);
            this.SubjectVM = MainViewModel.Instance.ObsSubjectVMs.First(x => x.SubjectID == tutorial.Subject.SubjectID);
            this.Years = new ObservableCollection<int>() { 2015, 2016, 2017 };
            this.Semesters = new ObservableCollection<int>() { 1, 2 };
            this.Year = tutorial.Year;
            this.Semester = tutorial.Semester;
        }

        private TeacherViewModel teacherVM;
        public TeacherViewModel TeacherVM
        {
            get
            {
                return this.teacherVM;
            }
            set
            {
                if (this.teacherVM != value)
                {
                    this.teacherVM = value;
                    this.tutorial.Teacher = value.teacher;
                    this.RaisePropertyChanged(() => this.TeacherVM);
                }
            }
        }

        private SubjectViewModel subjectVM;
        public SubjectViewModel SubjectVM
        {
            get
            {
                return this.subjectVM;
            }
            set
            {
                if (this.subjectVM != value)
                {
                    this.subjectVM = value;
                    this.tutorial.Subject = value.subject;
                    this.RaisePropertyChanged(() => this.SubjectVM);
                }
            }
        }

        public int Year
        {
            get
            {
                return this.tutorial.Year;
            }
            set
            {
                if (this.tutorial.Year != value)
                {
                    this.tutorial.Year = value;
                    this.RaisePropertyChanged(() => this.Year);
                }
            }
        }

        public int Semester
        {
            get
            {
                return this.tutorial.Semester;
            }
            set
            {
                if (this.tutorial.Semester != value)
                {
                    this.tutorial.Semester = value;
                    this.RaisePropertyChanged(() => this.Semester);
                }
            }
        }

        public ObservableCollection<int> years;
        public ObservableCollection<int> Years
        {
            get
            {
                return this.years;
            }
            set
            {
                if (this.years != value)
                {
                    this.years = value;
                    this.RaisePropertyChanged(() => this.Years);
                }
            }
        }

        public ObservableCollection<int> semesters;
        public ObservableCollection<int> Semesters
        {
            get
            {
                return this.semesters;
            }
            set
            {
                if (this.semesters != value)
                {
                    this.semesters = value;
                    this.RaisePropertyChanged(() => this.Semesters);
                }
            }
        }

    }
}
