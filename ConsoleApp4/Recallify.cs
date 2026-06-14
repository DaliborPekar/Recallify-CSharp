using System.Globalization;

namespace Recallify
{
    internal class Recallify
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            int modeSelect = 1;
            bool restart = true;
            string check;
            int numQuestions = 5;
            int index;
            string difficulty;
            int indexWeightedQuestion;
            int indexWeightedAnswer;
            int weightedIndex;

            string[] questions = new string[numQuestions];
            string[] answers = new string[numQuestions];
            string[] ratings = new string[numQuestions];



            while (1 == 1)
            {
                Console.WriteLine("Select mode: ");
                modeSelect = Convert.ToInt32(Console.ReadLine());
                switch (modeSelect)
                {
                    case (1):

                        StudyMode(questions, answers);
                        break;

                    case (2):

                        RecallMode(questions, answers);
                        break;

                    case (3):
                        AddQuesitons(questions, answers);
                        break;
                }
            }


            void AddQuesitons(string[] questions, string[] answers)
            {
                string wantContinue;
                int temp = 0;
                do
                {

                    Console.WriteLine($"Enter {temp} question: ");
                    questions[temp] = Console.ReadLine();
                    Console.WriteLine($"Enter {temp} answer: ");
                    answers[temp] = Console.ReadLine();

                    temp++;
                    Console.WriteLine("Do you want to continue?");
                    wantContinue = Console.ReadLine().ToLower();

                }
                while (wantContinue != "n" && temp < numQuestions);
            }

            void StudyMode(string[] questions, string[] answers)
            {

                while (restart)
                {
                    foreach (string question in questions)
                    {
                        index = Array.IndexOf(questions, question);

                        Console.WriteLine($"{question}\n");
                        Console.ReadKey();
                        Console.WriteLine($"{answers[index]}\n");
                        Rate(index);

                    }
                    DoRestart();

                }
            }

            void RecallMode(string[] questions, string[] answers)
            {
                while (restart)
                {
                    List<string> weighted = new List<string>();

                    foreach (string question in questions)
                    {
                        index = Array.IndexOf(questions, question);
                        if (ratings[index] == "h")
                        {
                            weighted.Add(questions[index]);
                            weighted.Add(questions[index]);
                            weighted.Add(questions[index]);
                        }
                        else if (ratings[index] == "m")
                        {
                            weighted.Add(questions[index]);
                            weighted.Add(questions[index]);
                        }
                        else
                        {
                            weighted.Add(questions[index]);
                        }
                    }
                    for (weightedIndex = 1; weightedIndex <= 5; weightedIndex++)
                    {
                        indexWeightedQuestion = rand.Next(weighted.Count);
                        indexWeightedAnswer = Array.IndexOf(questions, weighted[indexWeightedQuestion]);

                        Console.WriteLine($"{weighted[indexWeightedQuestion]}\n");
                        Console.ReadKey();
                        Console.WriteLine($"{answers[indexWeightedAnswer]}\n");
                        Rate(indexWeightedAnswer);
                    }
                    DoRestart();

                }


            }

            void Rate(int index)
            {
                Console.Write("Rate this question(h for hard, m for medium, e for easy):");
                string input = Console.ReadLine().ToLower();

                switch (input)
                {
                    case ("h"):
                        {
                            ratings[index] = "h";
                            break;
                        }
                    case ("m"):
                        {
                            ratings[index] = "m";
                            break;
                        }
                    case ("e"):
                        {
                            ratings[index] = "e";
                            break;
                        }
                    default:
                        {
                            ratings[index] = "m";
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
