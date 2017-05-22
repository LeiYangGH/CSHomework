using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace studentManage
{
    public static  class studentStorage
    {

        public static void WriteStudents(string filename, studentList list)
        {
            if (filename == null)
                throw new ArgumentNullException("path is not exsit");
            StreamWriter sw = new StreamWriter(filename, false);
            
                foreach (student p in list)
                {
                    sw.WriteLine(p.Id);
                    sw.WriteLine(string.IsNullOrEmpty(p.Grade) ? "" : p.Grade);
                    sw.WriteLine(p.Birth.ToString());
                    sw.WriteLine(p.Intake.ToString());
                    sw.WriteLine(string.IsNullOrEmpty(p.Name) ? "" : p.Name);
                    sw.WriteLine(string.IsNullOrEmpty(p.Major) ? "" : p.Major);
                    sw.WriteLine(string.IsNullOrEmpty(p.Interest) ? "" : p.Interest);
                    sw.WriteLine(p.Sex.ToString());
                    sw.WriteLine(string.IsNullOrEmpty(p.Hostel) ? "" : p.Hostel);
                    sw.WriteLine(string.IsNullOrEmpty(p.Picture) ? "" : p.Picture);

                }
            }
           
        
        public static studentList ReadStudents(string filename)
        {
            
                StreamReader sr = new StreamReader(filename);
                studentList stu1 = new studentList();
                student p = null;
                do
                {

                    string id = sr.ReadLine();

                    if (string.IsNullOrEmpty(id))
                        break;
                    p = new student(id);
                   
                    string sex = sr.ReadLine();
                try
                {
                    bool ss = bool.Parse(sex);
                }
                catch { }
                if(sex=="男")
                p.Sex = true;
                else if (sex == "女")
                    p.Sex = false;
                  
                try
                {
                    string birth = sr.ReadLine();
                    if (!string.IsNullOrEmpty(birth))
                    {
                        p.Birth = DateTime.Parse(birth);
                    }
                }
                catch
                { }
                try
                {
                    string intake = sr.ReadLine();
                    if (!string.IsNullOrEmpty(intake))
                    {
                        p.Intake = DateTime.Parse(intake);
                    }
                }
                catch { }
                    p.Name = sr.ReadLine();
                    p.Major = sr.ReadLine();
                    p.Interest = sr.ReadLine();
                    p.Hostel = sr.ReadLine();
                  
                   

                    stu1.Add(p);
                }
                while (p != null);
                return stu1;


            }
            
        }
    }
    

