using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CSMVPAssignment.Model
{
    public static class Repository
    {
        public static bool SaveTutorial(Tutorial tutorial)
        {
            string line = string.Format("{0},{1},{2},{3}\r\n",
                tutorial.Teacher.TeacherID,
                tutorial.Subject.SubjectID,
                tutorial.Year,
                tutorial.Semester);
            string fullName = Path.Combine(Environment.CurrentDirectory, "Tutorial.csv");
            try
            {
                File.AppendAllText(fullName, line);
                return true;
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
                return false;
            }
        }

        public static IList<string[]> ReadCsvToArray2(string fileName)
        {
            try
            {
                string fullName = Path.Combine(Environment.CurrentDirectory, fileName);
                return File.ReadLines(fullName).Skip(1)
                     .Select(line => line.Split(new char[] { ',' },
                     StringSplitOptions.RemoveEmptyEntries))
                     .Select(w => w.Select(item => item.Trim()).ToArray())
                     .ToList();
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
                return null;
            }
        }

        private static IList<Teacher> allTeachers;
        public static IList<Teacher> AllTeachers
        {
            get
            {
                if (allTeachers == null)
                    ReadAllTeachers();
                return allTeachers;
            }
        }

        private static IList<Subject> allSubjects;
        public static IList<Subject> AllSubjects
        {
            get
            {
                if (allSubjects == null)
                    ReadAllSubjects();
                return allSubjects;
            }
        }

        private static IList<Tutorial> allTutorials;
        public static IList<Tutorial> AllTutorials
        {
            get
            {
                if (allTutorials == null)
                    ReadAllTutorials();
                return allTutorials;
            }
        }

        private static void ReadAllTeachers()
        {
            allTeachers = ReadCsvToArray2("Teacher.csv")
                  .Select(line => ConvertArrayToTeachers(line))
                  .ToList();
        }

        private static void ReadAllSubjects()
        {
            allSubjects = ReadCsvToArray2("Subject.csv")
                 .Select(line => ConvertArrayToSubjects(line))
                 .ToList();
        }

        private static void ReadAllTutorials()
        {
            allTutorials = ReadCsvToArray2("Tutorial.csv")
                 .Select(line => ConvertArrayToTutorials(line))
                 .ToList();
        }

        public static void ReadAllDataFromCsv()
        {
            ReadAllTeachers();
            ReadAllSubjects();
            ReadAllTutorials();
        }

        public static Teacher GetTeacherById(int id)
        {
            return AllTeachers.First(x => x.TeacherID == id);
        }

        public static Subject GetSubjectById(int id)
        {
            return AllSubjects.First(x => x.SubjectID == id);
        }

        public static Teacher ConvertArrayToTeachers(string[] line)
        {
            return new Teacher(Convert.ToInt32(line[0]), line[1], line[2]);
        }

        public static Subject ConvertArrayToSubjects(string[] line)
        {
            return new Subject(Convert.ToInt32(line[0]), line[1]);
        }

        public static Tutorial ConvertArrayToTutorials(string[] line)
        {
            var teacher = Repository.GetTeacherById(Convert.ToInt32(line[0]));
            var subject = Repository.GetSubjectById(Convert.ToInt32(line[1]));
            return new Tutorial(teacher,
                subject,
                Convert.ToInt32(line[2]),
                Convert.ToInt32(line[3]));
        }
    }
}
