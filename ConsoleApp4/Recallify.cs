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


            /*
            Console.WriteLine("Enter the number of questions: ");
            numQuestions = Convert.ToInt32(Console.ReadLine());
            */


            string[] questions = new string[numQuestions];
            string[] answers = new string[numQuestions];
            string[] ratings = new string[numQuestions];

            questions[0] = "Question 1";
            answers[0] = "Answer 1";
            ratings[0] = "h";

            questions[1] = "Question 2";
            answers[1] = "Answer 2";
            ratings[1] = "m";

            questions[2] = "Question 3";
            answers[2] = "Answer 3";
            ratings[2] = "e";

            questions[3] = "Question 4";
            answers[3] = "Answer 4";
            ratings[3] = "h";

            questions[4] = "Question 5";
            answers[4] = "Answer 5";
            ratings[4] = "m";

            Console.WriteLine("Select mode: ");
            modeSelect = Convert.ToInt32(Console.ReadLine());

            switch (modeSelect)
            {
                case (1):
                    {
                        StudyMode(questions, answers);
                        break;
                    }
                case (2):
                    {
                        RecallMode(questions, answers);
                        break;
                    }
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
