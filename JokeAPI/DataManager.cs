using JokeAPI.Models;
using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace JokeAPI
{
    /// <summary>
    /// Class to manage all of the reads and writes from the flat files.
    /// Static class to persist the randomizer
    /// </summary>
    public static class DataManager
    {
        static Random rnd = new Random();
        static readonly string QuestionAnswerLocation = "./data/questionanswerjokes.txt";
        static readonly string LongFormLocation = "./data/longformjokes.txt";

        /// <summary>
        /// Gets one random joke from either of the lists
        /// </summary>
        /// <returns>Single joke in Json format</returns>
        public static string GetRandomJoke()
        {
            int randomNumber = rnd.Next(2);

            string joke;

            if (randomNumber == 0)
            {
                joke = JsonConvert.SerializeObject(getRandomLongForm());
            }
            else
            {
                joke = JsonConvert.SerializeObject(getRandomQuestionAnswer());
            }

            return joke;
        }

        /// <summary>
        /// Gets all Q+A jokes
        /// </summary>
        /// <returns>List of Q+A jokes</returns>
        public static List<QuestionAnswer> GetQuestionAnswers()
        {
            var jokeText = File.ReadAllText(QuestionAnswerLocation);

            var jokes = JsonConvert.DeserializeObject<List<QuestionAnswer>>(jokeText);

            return jokes;
        }

        /// <summary>
        /// Gets all long form jokes
        /// </summary>
        /// <returns>List of LongForm jokes</returns>
        public static List<LongForm> GetLongForms()
        {
            var jokeText = File.ReadAllText(LongFormLocation);

            var jokes = JsonConvert.DeserializeObject<List<LongForm>>(jokeText);

            return jokes;
        }

        /// <summary>
        /// Reads from Q+A jokes list and returns random joke
        /// </summary>
        /// <returns>Q+A Joke</returns>
        public static QuestionAnswer getRandomQuestionAnswer()
        {
            var jokes = GetQuestionAnswers();

            int r = rnd.Next(jokes.Count);

            var joke = jokes[r];

            return joke;
        }

        /// <summary>
        /// Reads from Longform jokes list and returns random joke
        /// </summary>
        /// <returns>LongForm joke</returns>
        public static LongForm getRandomLongForm()
        {
            var jokes = GetLongForms();

            int r = rnd.Next(jokes.Count);

            var joke = jokes[r];

            return joke;
        }

        /// <summary>
        /// Inserts Q+A Joke into the flat file
        /// </summary>
        /// <param name="questionAnswer">Q+A joke type to be entered</param>
        public static void AddNewQuestionAnswer(QuestionAnswer questionAnswer)
        {
            var jokes = GetQuestionAnswers();

            jokes.Add(questionAnswer);

            var convertedJokes = JsonConvert.SerializeObject(jokes);

            File.WriteAllText(QuestionAnswerLocation, convertedJokes);


        }
        /// <summary>
        /// Inserts long form joke into the flat file.
        /// </summary>
        /// <param name="longForm">Longform joke type to be entered</param>
        public static void AddNewLongForm(LongForm longForm)
        {
            var jokes = GetLongForms();

            jokes.Add(longForm);

            var convertedJokes = JsonConvert.SerializeObject(jokes);

            File.WriteAllText(LongFormLocation, convertedJokes);

        }
    }
}
