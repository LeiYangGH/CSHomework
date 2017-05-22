using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Collections.ObjectModel;

namespace studentManage
{
   public  class studentList:Collection<Student>

    {
        public void Add(Student s)
       {

           base.Add(s);

          
       }
      
       public void RemoveAt(int index)
       {
            base.RemoveAt(index);
        }
        public void  Update(Student id, int index)
        {
            base.SetItem(index, id);
        }
       public void Clear()
       {
            base.Clear();
        }

        public Student Find(string studentNumber)
        {
            int pos = -1;
            pos = base.IndexOf(new Student(studentNumber));
            if (pos > -1)
            {
                return Items[pos];

            }
            return null;
        }
        public bool Modify(string studentNumber, string interest)
        {
            Student stu = Find(studentNumber);
            if (stu != null)
            {
                stu.Interest = interest;
                return true;
            }
            return false;

        }
    }
}
