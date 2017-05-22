using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 模拟考试
{
    public class Questions
    {
        public Questions()
        {
            this.TrueFalseQuestions = new TrueFalseQuestion[]
              {
                new TrueFalseQuestion() { Title= "1+1=2" ,IsCorrect=true,score=10},
                new TrueFalseQuestion() { Title= "2+2=5", IsCorrect=false,score=10},
                new TrueFalseQuestion() { Title= "今天是暑假", IsCorrect=false,score=10}
              };

            this.SingleChoiceQuestions = new SingleChoiceQuestion[]
              {
                new SingleChoiceQuestion() { Title= "5+5=" ,Choices=new string[] { "10","2,","8","1"},CorrectChoiceId=0 ,score=10},
                new SingleChoiceQuestion() { Title= "哪个是C语言关键字" ,Choices=new string[] { "private","class,","pointer","typedef"},CorrectChoiceId=3,score=10 }
              };

            this.MultipleChoiceQuestion = new MultipleChoiceQuestion()
            {
                Title = "哪些城市是中国的",
                Choices = new string[] { "杭州", "四川,", "苏州", "洛杉矶" },
                CorrectChoiceIds = new int[] { 0, 1, 2 },
                score = 20
            };

            this.ArticleQuestion = new ArticleQuestion()
            {
                Title = "杭州有哪些景点？",
                MinLength = 15,
                score = 30
            };
        }
        public TrueFalseQuestion[] TrueFalseQuestions { get; set; }
        public SingleChoiceQuestion[] SingleChoiceQuestions { get; set; }
        public MultipleChoiceQuestion MultipleChoiceQuestion { get; set; }
        public ArticleQuestion ArticleQuestion { get; set; }
    }

    public struct TrueFalseQuestion
    {
        public string Title;
        public bool IsCorrect;
        public int score;
    }

    public struct SingleChoiceQuestion
    {
        public string Title;
        public string[] Choices;
        public int CorrectChoiceId;
        public int score;

    }

    public struct MultipleChoiceQuestion
    {
        public string Title;
        public string[] Choices;
        public int[] CorrectChoiceIds;
        public int score;

    }

    public struct ArticleQuestion
    {
        public string Title;
        public int MinLength;
        public int score;

    }
}
