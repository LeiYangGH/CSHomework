using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace studentManage
{
    public class student
    {

        public student(string id)

        {
            this.id = id;
        }
        public override string ToString()
        {
            return id;
        }
        private string id;
        public string Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
            
        }

        private string  grade;//年级
        public string   Grade
        {
            get
            {
                return grade;
            }

            set
            {
                if (grade != value)
                    grade = value;
            }
        }

        private string major;
        public string Major
        {
            get
            {
                return major;
            }

            set
            {
                if (major != value)
                    major = value;
            }
        }

        private string name;
        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                if (name != value)
                    name = value;
            }
        }

        private bool sex;
        public bool Sex
        {
            get
            {
                return sex;
            }

            set
            {
                if (sex != value)
                    sex = value;
            }
        }



        private DateTime birth;
        public DateTime Birth
        {
            get
            {
                return birth;
            }

            set
            {
                if (value > DateTime.Now)
                    birth = DateTime.Now;
                else
                    birth = value;
            }
        }

        private DateTime intake;//入学时间
        public DateTime Intake
        {
            get
            {
                return intake;
            }

            set
            {
                if (value > DateTime.Now)
                    intake = DateTime.Now;
                intake = value;
            }
        }

        private string interest;
        public string Interest
        {
            get
            {
                return interest;
            }

            set
            {
                if (interest != value)
                    interest = value;
            }
        }

       

        private string  picture;
        public string  Picture
        {

            get
            {
               return picture;
            }
            set 
            {

                picture = value;
                    

            }


        }

        private string hostel;//宿舍号
        public string Hostel
        {
            get
            {
                return hostel;
            }

            set
            {
                if (hostel != value)
                    hostel = value;
            }
        }
        public override bool Equals(object obj)
        {
            bool same = false;
            if (obj is student)
            {
                student s = obj as student;
                if (s.id == this.id)
                    same = true;
            }
            return same;
        }

    }
}
