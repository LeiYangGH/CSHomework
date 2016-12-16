using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2.Model
{
   public class Tutorial
    {
        public Presenter.MainViewPresenter Presenter { get; set; }
        public Presenter.CreateViewPresenter CntPresenter { get; set; }
        public Presenter.SearchViewPresenter svPresenter { get; set; }

        public int _TeacherID; //Address, Reference, Pointer
        public int _SubjectID; //Address, Reference, Pointer
        public int _Year;
        public int _Semester;

        //create construstor 
        public Tutorial(int teacherID, int subjectID, int year, int semester)
        {
            _TeacherID = teacherID;
            _SubjectID = subjectID;
            _Year = year;
            _Semester = semester;

        }

    }
}
