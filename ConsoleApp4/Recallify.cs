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

            List<Flashcard> flashcard = new List<Flashcard>();

            bool modeMenu = true;

            List<string> data = new List<string>();

            if(File.Exists("flashcards.csv"))
            {
                string[] loading = File.ReadAllLines("flashcards.csv");
                string[] y;
                foreach (string x in loading)
                {
                    numQuestions++;
                    y = x.Split(",");

                    if (Convert.ToString(y[2]) == "Easy")
                    {
                        Flashcard card = new Flashcard(y[0], y[1], Rating.Easy);
                        flashcard.Add(card);
                    }
                    else if (Convert.ToString(y[2]) == "Medium")
                    {
                        Flashcard card = new Flashcard(y[0], y[1], Rating.Medium);
                        flashcard.Add(card);
                    }
                    else if (Convert.ToString(y[2]) == "Hard")
                    {
                        Flashcard card = new Flashcard(y[0], y[1], Rating.Hard);
                        flashcard.Add(card);
                    }
                }

            }

            while (modeMenu)
            {
                bool validInput = false;
                while (!validInput)
                {
                    Console.WriteLine("Select mode: ");
                    string input = Console.ReadLine();

                    if (int.TryParse(input, out modeSelect))
                    {
                        validInput = true;
                    }
                    else
                    {
                        Console.WriteLine("Enter a number!");
                    }
                }

                switch (modeSelect)
                {
                    case 1:
                        StudyMode(flashcard);
                        break;

                    case 2:
                        RecallMode(flashcard);
                        break;

                    case 3:
                        AddQuestions();
                        break;

                    case 4:
                        modeMenu = false;
                        break;

                    default:
                        modeMenu = false;
                        break;

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

                        Console.WriteLine($"{card.Question}\n");
                        Console.ReadKey();
                        Console.WriteLine($"{card.Answer}\n");

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

                        if (card.Rating == Rating.Hard)
                        {
                            weighted.Add(card);
                            weighted.Add(card);
                            weighted.Add(card);
                        }
                        else if (card.Rating == Rating.Medium)
                        {
                            weighted.Add(card);
                            weighted.Add(card);
                        }
                        else
                        {
                            weighted.Add(card);
                        }
                    }

                    bool validInput = false;

                    int numWeightedQuestions = 0;

                    while (!validInput)
                    {
                        Console.WriteLine("How many weighted questions do you want?: ");
                        string input = Console.ReadLine();
                        if (int.TryParse(input, out numWeightedQuestions))
                        {
                            validInput = true;

                        }
                        else
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
                            Console.WriteLine($"{weighted[indexWeightedQuestion].Question}\n");
                            Console.ReadKey();
                            Console.WriteLine($"{weighted[indexWeightedQuestion].Answer}\n");
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
                    case "h":

                            temp.Rating = Rating.Hard;
                            break;

                    case "m":

                            temp.Rating = Rating.Medium;
                            break;

                    case "e":

                            temp.Rating = Rating.Easy;
                            break;

                    default:

                            temp.Rating = Rating.Medium;
                            break;

                }

                Console.WriteLine("\n");

            }

            void DoRestart()
            {
                Console.WriteLine("Do you want to restart?(y or n)?");
                string check = Console.ReadLine().ToLower();

                switch (check)
                {
                    case "y":
                        {
                            restart = true;
                            break;
                        }

                    case "n":
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

            foreach (Flashcard card in flashcard)
            {
                data.Add($"{card.Question},{card.Answer},{card.Rating},");
                Console.WriteLine($"{card.Question},{card.Answer},{card.Rating},");
            }

            File.WriteAllLines("flashcards.csv", data);

        }
    }
}
