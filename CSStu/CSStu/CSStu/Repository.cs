using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSStu
{
    public class Repository
    {
        private string coursesFileName = "Courses.txt";
        private string scoresFileName = "Scores.txt";
        public static Repository Default;
        public Repository()
        {
            Repository.Default = this;
            this.ListStudents = new List<Student>
                {
                    new Student("20160001","Miller"),
                    new Student("20160002","Jim"),
                    new Student("20160003","Mike"),
                    new Student("20160004","Lucy")
                };
            this.ReadAllCourses();
            this.ReadAllScores();
        }
        public List<Student> ListStudents { get; set; }
        public List<Course> ListCourses { get; set; }
        public List<Score> ListScores { get; set; }


        /// <summary>
        /// 保存用户文件
        /// </summary>
        public void SaveCoursesToFile()
        {
            try
            {
                File.WriteAllLines(this.coursesFileName, this.ListCourses.Select(x => x.ToString()), Encoding.UTF8);
                MessageBox.Show("成功保存！");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        /// <summary>
        /// 保存用户文件
        /// </summary>
        public void SaveScoresToFile()
        {
            try
            {
                File.WriteAllLines(this.scoresFileName, this.ListScores.Select(x => x.ToString()), Encoding.UTF8);
                MessageBox.Show("成功保存！");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        /// <summary>
        /// 从txt的一行解析出各个字段
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        public static Course CreateCourseFromLine(string line)
        {
            string[] ss = line.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            return new Course(
               Convert.ToInt32(ss[0].Trim()),
                ss[1],
                Convert.ToDateTime(ss[2].Trim()),
             Convert.ToInt32(ss[3].Trim())
            );
        }

        public static Score CreateScoreFromLine(string line)
        {
            string[] ss = line.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            return new Score(
                ss[0],
                ss[1],
                ss[2],
               Convert.ToInt32(ss[3].Trim()),
             Convert.ToInt32(ss[4].Trim())
            );
        }

        public void ReadAllCourses()
        {
            this.ListCourses = new List<Course>();
            if (File.Exists(coursesFileName))
            {
                this.ListCourses = File.ReadLines(this.coursesFileName, Encoding.UTF8)
                    .Select(x => CreateCourseFromLine(x))
                    .ToList();
            }
        }

        public void ReadAllScores()
        {
            this.ListScores = new List<Score>();
            if (File.Exists(scoresFileName))
            {
                this.ListScores = File.ReadLines(this.scoresFileName, Encoding.UTF8)
                    .Select(x => CreateScoreFromLine(x))
                    .ToList();
            }
        }
    }
}
