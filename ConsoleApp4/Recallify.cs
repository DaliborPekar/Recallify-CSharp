using System.Collections.Concurrent;
using System.Globalization;

namespace Recallify
{
    public enum Rating { Easy, Medium, Hard }
    internal class Recallify
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            int modeSelect = 0;
            bool restart = true;

            int numQuestions = 0;

            int indexWeightedQuestion;

            bool modeMenu = true;

            bool validInput = false;

            List<Flashcard> flashcard = new List<Flashcard>();

            validInput = false;
            bool corectMode = true;

            while (corectMode)
            {

                while (modeMenu)
                {
                    while (!validInput)
                    {
                        try
                        {
                            Console.WriteLine("Select mode: ");
                            modeSelect = Convert.ToInt32(Console.ReadLine());
                            validInput = true;
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Enter a number!");

                        }
                    }

                    switch (modeSelect)
                    {
                        case (1):
                            corectMode = false;
                            StudyMode(flashcard);
                            
                            break;

                        case (2):
                            corectMode = false;
                            RecallMode(flashcard);
                            
                            break;

                        case (3):
                            corectMode = false;
                            AddQuestions();
                           
                            break;
                        default:
                            corectMode = true;
                            validInput = false;
                            Console.WriteLine("That mode doesnt exist!");
                            break;

                    }
                    Console.WriteLine("Do you want to change mode? (y for yes or n for no):");
                    string modeContinue = Console.ReadLine().ToLower();

                    if (modeContinue == "y")
                    {
                        modeMenu = true;
                        validInput = false;
                        corectMode = true;
                        
                    }
                        

                    else
                        modeMenu = false;
                }

                

            }


            void AddQuestions()
            {
                string wantContinue;

                do
                {
                    

                    Console.WriteLine($"Enter {numQuestions + 1} question: ");

                    string question = Console.ReadLine();

                    Console.WriteLine($"Enter {numQuestions + 1} answer: ");
                    string answer = Console.ReadLine();


                    Flashcard card = new Flashcard(question, answer);
  

                    flashcard.Add(card);

                    numQuestions++;
                    Console.WriteLine("Do you want to continue?");
                    wantContinue = Console.ReadLine().ToLower();

                }
                while (wantContinue != "n");
            }

            void StudyMode(List<Flashcard> flashcards)
            {
                
                while (restart)
                {
                    foreach (Flashcard card in flashcards)
                    {

                        Console.WriteLine($"{card.question}\n");
                        Console.ReadKey();
                        Console.WriteLine($"{card.answer}\n");

                        Rate(card);

                    }
                    DoRestart();

                }
            }

            void RecallMode(List<Flashcard> flashcards)
            {
                restart = true;
                while (restart)
                {
                    List<Flashcard> weighted = new List<Flashcard>();

                    int lastQuestion = -1;

                    foreach (Flashcard card in flashcards)
                    {

                        if (card.rating == Rating.Hard)
                        {
                            weighted.Add(card);
                            weighted.Add(card);
                            weighted.Add(card);
                        }
                        else if (card.rating == Rating.Medium)
                        {
                            weighted.Add(card);
                            weighted.Add(card);
                        }
                        else
                        {
                            weighted.Add(card);
                        }
                    }
                    validInput = false;

                    int numWeightedQuestions = 0;

                    while (!validInput)
                    {
                        try
                        {
                            Console.WriteLine("How many weighted questions do you want?: ");
                            numWeightedQuestions = Convert.ToInt32(Console.ReadLine());
                            validInput = true;



                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Enter a number!");
                        }
                    }

                    validInput = false;

                    if (numWeightedQuestions > weighted.Count)
                    {
                        Console.WriteLine("This number excedes the number of questions!");
                        Console.WriteLine("Using the number of question\n");
                        numWeightedQuestions = numQuestions;
                    }
                    



                    for (int i = 1; i <= numWeightedQuestions; i++)
                    {
                        indexWeightedQuestion = rand.Next(weighted.Count);
                        if (lastQuestion != indexWeightedQuestion)
                        {
                            Console.WriteLine($"{weighted[indexWeightedQuestion].question}\n");
                            Console.ReadKey();
                            Console.WriteLine($"{weighted[indexWeightedQuestion].answer}\n");
                            Rate(weighted[indexWeightedQuestion]);
                            lastQuestion = indexWeightedQuestion;
                        }                 
                    }
                    DoRestart();

                }
            }

            void Rate(Flashcard temp)
            {
                Console.Write("Rate this question(h for hard, m for medium, e for easy):");
                string input = Console.ReadLine().ToLower();



                switch (input)
                {
                    case ("h"):
                        {

                            temp.rating = Rating.Hard;
                            break;
                        }
                    case ("m"):
                        {
                            temp.rating = Rating.Medium;
                            break;
                        }
                    case ("e"):
                        {
                            temp.rating = Rating.Easy;
                            break;
                        }
                    default:
                        {
                            temp.rating = Rating.Medium;
                            break;
                        }
                }
                Console.WriteLine("\n");

            }

            void DoRestart()
            {
                Console.WriteLine("Do you want to restart?(y or n)?");
                string check = Console.ReadLine().ToLower();

                switch (check)
                {
                    case ("y"):
                        {
                            restart = true;
                            break;
                        }
                    case ("n"):
                        {
                            restart = false;

                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Invalid input! Abort!");
                            restart = false;
                            break;
                        }
                }
            }


        }
    }
}
