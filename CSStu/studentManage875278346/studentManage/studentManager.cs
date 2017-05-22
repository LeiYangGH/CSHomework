using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace studentManage
{
   public  class studentManager
    {
        private studentList list;
        

        private string filename="listDate.txt";
     

        public studentManager(string path )
           
         {
            list = studentStorage.ReadStudents(path);
            list = new studentList();
            filename = string.Empty;
          }

        public studentManager()
        {
            list = new studentList();
            filename = string.Empty;
        }

        public void   MoveFirst()
        {
            position = 1;
           
        }
        public void   MoveLast()
        {
            position = list.Count-1;
           
        }
        public void   MoveNext()
        {
            position++;
            if (position > list.Count-1)
                position = list.Count-1;
           }
        public void   MovePrev()
        {
            position--;
            if (position <= 0)
                position = 0;
        
        }
        public Student CurrentStudent
        {
            get
            {
                if (position < 0 || position > list.Count-1)
                    return null;
                return list[position ];
            }
        }
        private int  position;//集合的下标

        public int  Position
        {
            get
            {
                if (position >list.Count)
                {
                    position = list.Count-1;
                }
                return position;
            }
            set
            {
                if (value <0 || value > list.Count-1)
                    throw new IndexOutOfRangeException("给定位置超出范围！！！");
                position = value;

            }
        }
        public void Save(string path)
        {
            filename = path;
            studentStorage.WriteStudents(path , list);

        }
        public void Save()
        {
            studentStorage.WriteStudents(filename,list);
        }


    }
}
