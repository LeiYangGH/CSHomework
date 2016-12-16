using GalaSoft.MvvmLight;
using CSMVPAssignment.Model;
namespace CSMVPAssignment.ViewModel
{
    public class SubjectViewModel : ViewModelBase
    {
        public readonly Subject subject;
        public SubjectViewModel(Subject subject)
        {
            this.subject = subject;
        }

        public int SubjectID
        {
            get
            {
                return this.subject.SubjectID;
            }
            set
            {
                if (this.subject.SubjectID != value)
                {
                    this.subject.SubjectID = value;
                    this.RaisePropertyChanged(() => this.SubjectID);
                }
            }
        }

        public string SubjectName
        {
            get
            {
                return this.subject.SubjectName;
            }
            set
            {
                if (this.subject.SubjectName != value)
                {
                    this.subject.SubjectName = value;
                    this.RaisePropertyChanged(() => this.SubjectName);
                }
            }
        }

    }
}
