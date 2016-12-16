using System.Collections.Generic;
using System.IO;
using WpfApp2.Presenter;
namespace WpfApp2.Model
{
    public class Collection
    {
        public MainViewPresenter Presenter { get; set; }
        public CreateViewPresenter CntPresenter { get; set; }
        public SearchViewPresenter svPresenter { get; set; }

        //creating a collection for 3 classes
        public static List<Teacher> Teachers;
        public static List<Subject> Subjects;
        public static List<Tutorial> Tutorials;

        public static void FillCollections()
        {
            //read file 
            var reader = new StreamReader(File.OpenRead(@"Teacher.csv"));
            //create object
            Teachers = new List<Teacher>();
            bool ignoreLine = true;

            string[] word;
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                word = line.Split(',');
                if (ignoreLine)
                {
                    ignoreLine = false;
                    continue;
                }
                //pass parameters into object
                Model.Teacher Teacher1 = new Model.Teacher(int.Parse(word[0]), word[1], word[2]);
                Teachers.Add(Teacher1);   //add collection into object


            }


            {   //reade subject file 
                var S1 = new StreamReader(File.OpenRead(@"Subject.csv"));
                Subjects = new List<Subject>();
                bool L2 = true;

                string[] subword;
                while (!S1.EndOfStream)
                {
                    var line = S1.ReadLine();
                    subword = line.Split(',');
                    if (L2)
                    {
                        L2 = false;
                        continue;
                    }
                    Model.Subject Subject1 = new Model.Subject(int.Parse(subword[0]), subword[1]);
                    Subjects.Add(Subject1);
                }


                {   //reade tutorial file 
                    var T1 = new StreamReader(File.OpenRead(@"Tutorial.csv"));
                    Tutorials = new List<Tutorial>();
                    bool L3 = true;

                    string[] TWord;
                    while (!T1.EndOfStream)
                    {
                        var line = T1.ReadLine();
                        TWord = line.Split(',');
                        if (L3)
                        {
                            L3 = false;
                            continue;
                        }

                        if (TWord.Length == 4)
                        {
                            System.Console.WriteLine(line);
                            Model.Tutorial Tutorial1 = new Model.Tutorial(int.Parse(TWord[0]), int.Parse(TWord[1]), int.Parse(TWord[2]), int.Parse(TWord[3]));
                            Tutorials.Add(Tutorial1);

                        }
                    }

                }
            }
        }
    }
}
