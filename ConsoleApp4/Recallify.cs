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
            int modeSelect = 1;
            bool restart = true;
           
            int numQuestions = 5;

            int indexWeightedQuestion;
            
            int weightedIndex;

            bool modeMenu = true;

            bool validInput = false;

            List<Flashcard> flashcard = new List<Flashcard>();

            int temp = 0;

            while (modeMenu)
            {
               
                
                while(!validInput)
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

                validInput = false;
                

                switch (modeSelect)
                {
                    case (1):

                        StudyMode(flashcard);
                        break;

                    case (2):

                        RecallMode(flashcard);
                        break;

                    case (3):
                        AddQuestions();
                        break;
                    
                }
                Console.WriteLine("Do you want to change mode? (y for yes or n for no):");
                string modeContinue = Console.ReadLine().ToLower();
                
                if (modeContinue == "y")
                    modeMenu = true;
                else
                    modeMenu = false;

            }
            

            void AddQuestions()
            {
                string wantContinue;
                
                do
                {
                    Flashcard card = new Flashcard();

                    Console.WriteLine($"Enter {temp + 1} question: ");

                    card.question = Console.ReadLine();

                    Console.WriteLine($"Enter {temp + 1} answer: ");
                    card.answer = Console.ReadLine();

                    flashcard.Add(card);

                    temp++;
                    Console.WriteLine("Do you want to continue?");
                    wantContinue = Console.ReadLine().ToLower();

                }
                while (wantContinue != "n" && temp < numQuestions);
            }

            void StudyMode(List<Flashcard> flashcards)
            {

                while (restart)
                {
                    foreach (Flashcard temp in flashcards)
                    {
                        
                        Console.WriteLine($"{temp.question}\n");
                        Console.ReadKey();
                        Console.WriteLine($"{temp.answer}\n");

                        Rate(temp);
                        
                    }
                    DoRestart();

                }
            }

            void RecallMode(List<Flashcard> flashcards)
            {
                while (restart)
                {
                    List<Flashcard> weighted = new List<Flashcard>();

                    foreach (Flashcard temp in flashcards)
                    {
                        
                        if (temp.rating == Rating.Hard)
                        {
                            weighted.Add(temp);
                            weighted.Add(temp);
                            weighted.Add(temp);
                        }
                        else if (temp.rating == Rating.Medium)
                        {
                            weighted.Add(temp);
                            weighted.Add(temp);
                        }
                        else
                        {
                            weighted.Add(temp);
                        }
                    }
                    int numWeightedQuestions = 0;
                    while(!validInput)
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
                        numWeightedQuestions = temp;
                    }

                    for (int i  = 1; i <= numWeightedQuestions; i++)
                    {
                        indexWeightedQuestion = rand.Next(weighted.Count);
                        

                        Console.WriteLine($"{weighted[indexWeightedQuestion].question}\n");
                        Console.ReadKey();
                        Console.WriteLine($"{weighted[indexWeightedQuestion].answer}\n");
                        Rate(weighted[indexWeightedQuestion]);
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
