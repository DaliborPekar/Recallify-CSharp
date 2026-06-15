using System;
using System.Collections.Generic;
using System.Text;

namespace Recallify
{
    internal class Flashcard
    {
        public string question;
        public string answer;
        public Rating rating;

        public Flashcard(string question, string answer)
        {
            
            this.question = question;
            this.answer = answer;
            rating = Rating.Medium;


        }
    }
}
