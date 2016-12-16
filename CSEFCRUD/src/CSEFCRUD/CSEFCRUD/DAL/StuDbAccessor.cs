using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public static class StuDbAccessor
    {
        public static void Add(Student stu)
        {
            using (Model1 en = new Model1())
            {
                en.Students.Add(stu);
                en.SaveChanges();
            }
        }

        public static void Delete(Student stu)
        {
            using (Model1 en = new Model1())
            {
                en.Students.Remove(stu);
                en.SaveChanges();
            }
        }

        public static void Delete(int id)
        {
            using (Model1 en = new Model1())
            {
                Student stu = en.Students.First(x => x.ID == id);
                en.Students.Remove(stu);
                en.SaveChanges();
            }
        }

        public static void Update(int id, Student newStu)
        {
            using (Model1 en = new Model1())
            {
                Student stu = en.Students.First(x => x.ID == id);
                stu.Name = newStu.Name;
                stu.Sex = newStu.Sex;
                stu.Pwd = newStu.Pwd;
                stu.Discipline = newStu.Discipline;
                stu.Name = newStu.Name;
                en.SaveChanges();
            }
        }

        public static IList<Student> SelectAll()
        {
            using (Model1 en = new Model1())
            {
                return en.Students.ToList();
            }
        }

        public static Student SelectById(int id)
        {
            using (Model1 en = new Model1())
            {
                Student stu = en.Students.First(x => x.ID == id);
                return stu;
            }
        }
    }
}
