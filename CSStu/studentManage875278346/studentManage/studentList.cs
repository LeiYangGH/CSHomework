using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Collections.ObjectModel;

namespace studentManage
{
   public  class studentList:Collection<student>

    {
        public void Add(student s)
       {

           base.Add(s);

          
       }
      
       public void RemoveAt(int index)
       {
            base.RemoveAt(index);
        }
        public void  Update(student id, int index)
        {
            base.SetItem(index, id);
        }
       public void Clear()
       {
            base.Clear();
        }

        public student Find(string studentNumber)
        {
            int pos = -1;
            pos = base.IndexOf(new student(studentNumber));
            if (pos > -1)
            {
                return Items[pos];

            }
            return null;
        }
        public bool Modify(string studentNumber, string interest)
        {
            student stu = Find(studentNumber);
            if (stu != null)
            {
                stu.Interest = interest;
                return true;
            }
            return false;

        }
    }
}
