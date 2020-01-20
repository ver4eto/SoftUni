using System;
using System.Linq;
using System.Collections.Generic;

namespace _10._SoftUni_Exam_Results
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> usersPoints = new Dictionary<string, int>();
            Dictionary<string, int> languages = new Dictionary<string, int>();

            string command = Console.ReadLine();
            //int submissionCount = 1;

            while (command!= "exam finished")
            {
                string[] tokens = command.Split('-').ToArray();
                string userName = tokens[0];
                string language = tokens[1];

                if (language=="banned")
                {
                    usersPoints.Remove(userName);
                }
                else
                {
                    int points =int.Parse( tokens[2]);
                    if (!usersPoints.ContainsKey(userName))
                    {
                        usersPoints.Add(userName, points);
                    }
                    else
                    {
                        if (usersPoints[userName]<=points)
                        {
                            usersPoints[userName] = points;
                        }
                      
                    }
                    if (!languages.ContainsKey(language))
                    {
                        languages.Add(language, 1);
                    }
                    else
                    {
                        languages[language]++;
                    }
                }

                command = Console.ReadLine();
            }

            Console.WriteLine("Results:");
            foreach (var name in usersPoints.OrderByDescending(x=>x.Value).ThenBy(x=>x.Key))
            {
                Console.WriteLine($"{name.Key} | {name.Value}");
            }
            Console.WriteLine("Submissions:");
            foreach (var submission in languages.OrderByDescending(x=>x.Value).ThenBy(x=>x.Key))
            {
                Console.WriteLine($"{ submission.Key} - { submission.Value}");
            }
        }
    }
}
