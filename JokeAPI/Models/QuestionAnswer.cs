using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JokeAPI.Models
{
    public class QuestionAnswer
    {
        public QuestionAnswer()
        {
        }


        public QuestionAnswer(string question, string answer)
        {
            this.Question = question;
            this.Answer = answer;
        }

        public string Question { get; set; }
        public string Answer { get; set; }
    }
}
