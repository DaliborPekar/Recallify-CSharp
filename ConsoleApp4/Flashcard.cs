namespace Recallify
{
    internal class Flashcard
    {

        public string Question { get; set; }

        public string Answer { get; set; }

        public Rating Rating { get; set; }

        public Flashcard(string question, string answer)
        {
            
            this.Question = question;
            this.Answer = answer;
            Rating = Rating.Medium;

        }

        public Flashcard(string question, string answer, Rating rating)
        {

            this.Question = question;
            this.Answer = answer;
            this.Rating = rating;

        }
    }
}
