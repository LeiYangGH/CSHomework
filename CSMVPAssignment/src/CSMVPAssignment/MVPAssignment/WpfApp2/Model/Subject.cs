using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2.Model
{
    public class Subject
    {

        public Presenter.MainViewPresenter Presenter { get; set; }
        public Presenter.CreateViewPresenter CntPresenter { get; set; }
        public Presenter.SearchViewPresenter svPresenter { get; set; }

        public int _SubjectID; //Address, Reference, Pointer
        public String _SubjectName;
        

        // Default Contrustor
        public Subject()
        {

        }

        public Subject(int subjectID, String subjectName)
        {
            _SubjectID = subjectID;
            _SubjectName = subjectName;
        }

        

    }
}