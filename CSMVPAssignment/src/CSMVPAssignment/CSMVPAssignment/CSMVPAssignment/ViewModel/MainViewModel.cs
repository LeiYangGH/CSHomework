using System.Linq;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight.Command;
using CSMVPAssignment.Model;
using CSMVPAssignment.View;

namespace CSMVPAssignment.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private MainViewModel()
        {
            Task.Run(() =>
            {
                Repository.ReadAllDataFromCsv();
                this.ObsTeacherVMs = new ObservableCollection<TeacherViewModel>(
                    Repository.AllTeachers.Select(x => new TeacherViewModel(x)));
                this.ObsSubjectVMs = new ObservableCollection<SubjectViewModel>(
                     Repository.AllSubjects.Select(x => new SubjectViewModel(x)));
                this.ObsTutorials = new ObservableCollection<TutorialViewModel>(
                    Repository.AllTutorials.Select(x => new TutorialViewModel(x)));
            });
        }

        public static MainViewModel Instance { get { return Nested.instance; } }

        private class Nested
        {
            static Nested() { }
            internal static readonly MainViewModel instance = new MainViewModel();
        }

        private ObservableCollection<TeacherViewModel> obsTeacherVMs;
        public ObservableCollection<TeacherViewModel> ObsTeacherVMs
        {
            get
            {
                return this.obsTeacherVMs;
            }
            set
            {
                if (this.obsTeacherVMs != value)
                {
                    this.obsTeacherVMs = value;
                    this.RaisePropertyChanged(() => this.ObsTeacherVMs);
                }
            }
        }

        public ObservableCollection<SubjectViewModel> obsSubjectVMs;
        public ObservableCollection<SubjectViewModel> ObsSubjectVMs
        {
            get
            {
                return this.obsSubjectVMs;
            }
            set
            {
                if (this.obsSubjectVMs != value)
                {
                    this.obsSubjectVMs = value;
                    this.RaisePropertyChanged(() => this.ObsSubjectVMs);
                }
            }
        }


        private ObservableCollection<TutorialViewModel> obsTutorials;
        public ObservableCollection<TutorialViewModel> ObsTutorials
        {
            get
            {
                return this.obsTutorials;
            }
            set
            {
                if (this.obsTutorials != value)
                {
                    this.obsTutorials = value;
                    this.RaisePropertyChanged(() => this.ObsTutorials);
                }
            }
        }

        public void GetTutorialsCount(ref int count)
        {
            count = this.ObsTutorials.Count;
        }

        private RelayCommand createCommand;
        public RelayCommand CreateCommand
        {
            get
            {
                return createCommand
                  ?? (createCommand = new RelayCommand(
                   () => Create(),
                   () => true));
            }
        }

        private void Create()
        {
            CreateNewTutorial createWin = new CreateNewTutorial();
            if (createWin.ShowDialog() ?? false)
            {
                TutorialViewModel tutorialVM = createWin.TutorialVM;
                if (Repository.SaveTutorial(tutorialVM.tutorial))
                    this.ObsTutorials.Add(tutorialVM);
            }
        }
    }
}
