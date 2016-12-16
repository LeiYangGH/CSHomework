using GalaSoft.MvvmLight;
using CSMVPAssignment.Model;
namespace CSMVPAssignment.ViewModel
{
    public class TeacherViewModel : ViewModelBase
    {
        public readonly Teacher teacher;
        public TeacherViewModel(Teacher teacher)
        {
            this.teacher = teacher;
        }

        public int TeacherID
        {
            get
            {
                return this.teacher.TeacherID;
            }
            set
            {
                if (this.teacher.TeacherID != value)
                {
                    this.teacher.TeacherID = value;
                    this.RaisePropertyChanged(() => this.TeacherID);
                }
            }
        }


        public string FirstName
        {
            get
            {
                return this.teacher.FirstName;
            }
            set
            {
                if (this.teacher.FirstName != value)
                {
                    this.teacher.FirstName = value;
                    this.RaisePropertyChanged(() => this.FirstName);
                }
            }
        }

        public string LastName
        {
            get
            {
                return this.teacher.LastName;
            }
            set
            {
                if (this.teacher.LastName != value)
                {
                    this.teacher.LastName = value;
                    this.RaisePropertyChanged(() => this.LastName);
                }
            }
        }

        public string FullName
        {
            get
            {
                return this.teacher.FullName;
            }
        }
    }
}
