using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JokeAPI.Models
{
    public class LongForm
    {
        public LongForm(string wholeJoke)
        {
            WholeJoke = wholeJoke;
        }

        public string WholeJoke { get; set; }
    }
}
