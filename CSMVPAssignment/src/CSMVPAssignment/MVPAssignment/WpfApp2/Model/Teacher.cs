using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2.Model
{
   public class Teacher
    {
        public Presenter.MainViewPresenter Presenter { get; set; }
        public Presenter.CreateViewPresenter CntPresenter { get; set; }
        public Presenter.SearchViewPresenter svPresenter { get; set; }

        public int _TeacherID;

        //Address, Reference, Pointer

        public String _FirstName;
        public String _LastName;


        //Teacher Teacher1 = new Teacher();

        //Constructor
        public Teacher(int teacherID, string firstName, string lastName)
        {
            _TeacherID = teacherID;
            _FirstName = firstName;
            _LastName = lastName;
        }

        //default constructor
        public Teacher()
        {

        }
        
        public string FullName
        {
            get
            {
                return this._FirstName + " " + this._LastName;
            }

            //get
            //{ return FullName; }
            //set { FullName = this._FirstName + " " + this._LastName; }


        }

    }

}

