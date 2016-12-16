using System;

namespace CSMVPAssignment.Model
{
    public class Teacher
    {
        public Teacher(int teacherID,
            String firstName,
            String lastName)
        {
            this.TeacherID = teacherID;
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public int TeacherID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string FullName
        {
            get
            {
                return this.FirstName + " " + this.LastName;
            }
        }

    }
}
