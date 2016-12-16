using System;

namespace CSMVPAssignment.Model
{
    public class Subject
    {
        public Subject(int subjectID,
            String subjectName)
        {
            this.SubjectID = subjectID;
            this.SubjectName = subjectName;
        }

        public int SubjectID { get; set; }
        public string SubjectName { get; set; }

    }
}
