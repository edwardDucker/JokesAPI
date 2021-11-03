using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Newtonsoft.Json;
using JokeAPI.Models;

namespace JokeAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class JokeController : ControllerBase
    {
        // GET: JokeController
        [HttpGet]
        public string Index()
        {
            var joke = DataManager.GetRandomJoke();

            return joke;
        }

        // GET: JokeController/Longform
        [HttpGet]
        [Route("LongForm")]
        public string LongForm()
        {
            var joke = DataManager.getRandomLongForm();

            var converted = JsonConvert.SerializeObject(joke);

            return converted;
        }

        // GET: JokeController/QuestionAnswer
        [HttpGet]
        [Route("QuestionAnswer")]
        public string QuestionAnswer()
        {
            var joke = DataManager.getRandomQuestionAnswer();

            var converted = JsonConvert.SerializeObject(joke);

            return converted;
        }

        // POST: JokeController/QuestionAnswer
        [HttpPost]
        [Route("QuestionAnswer")]
        public string QuestionAnswer(QuestionAnswer questionAnswer)
        {
            DataManager.AddNewQuestionAnswer(questionAnswer);

            return "done";
        }

        // POST: JokeController/LongForm
        [HttpPost]
        [Route("LongForm")]
        public string LongForm(LongForm longForm)
        {
            DataManager.AddNewLongForm(longForm);

            return "done";
        }


        // POST: JokeController/Question
        [HttpPost]
        [Route("Question")]
        public string Question(string question)
        {
            // reads the QA jokes to see if it can find the q
            var jokes = DataManager.GetQuestionAnswers();

            var foundAnswer = jokes.Where(j => j.Question == question || j.Question.Contains(question)).Select(j => j.Answer).FirstOrDefault();

            if (foundAnswer != null)
            {
                return foundAnswer;
            }
            else
            {
                return "Joke not found :(";
            }

        }
    }
}
