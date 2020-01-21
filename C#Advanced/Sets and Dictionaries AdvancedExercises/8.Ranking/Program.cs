using System;
using System.Collections.Generic;
using System.Linq;

namespace _8.Ranking
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> examsAndPasses = new Dictionary<string, string>();
            Dictionary<string, Dictionary<string, int>> userExams = new Dictionary<string, Dictionary<string, int>>();

            string input = Console.ReadLine();
            while (input != "end of contests")
            {
                string[] tokens = input
                    .Split(":", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string exam = tokens[0];
                string pass = tokens[1];

                if (!examsAndPasses.ContainsKey(exam))
                {
                    examsAndPasses.Add(exam, pass);
                }
                input = Console.ReadLine();
            }

            input = Console.ReadLine();
            while (input != "end of submissions")
            {
                string[] tokens = input
                    .Split("=>", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string user = tokens[2];
                string contest = tokens[0];
                string pass = tokens[1];
                int points = int.Parse(tokens[3]);

                if (!userExams.ContainsKey(user))
                {
                    if (examsAndPasses.ContainsKey(contest) && pass == examsAndPasses[contest])
                    {
                        userExams.Add(user, new Dictionary<string, int>());
                        userExams[user].Add(contest, points);
                    }
                }
                else
                {
                    if (examsAndPasses.ContainsKey(contest) && pass == examsAndPasses[contest])
                    {
                        if (userExams[user].ContainsKey(contest) && userExams[user][contest]<points)
                        {
                            userExams[user][contest] = points;
                        }
                        else if(!userExams[user].ContainsKey(contest))
                        {
                            userExams[user].Add(contest, points);
                        }
                    }
                }
                input = Console.ReadLine();
            }

            Dictionary<string, int> totalPoint = new Dictionary<string, int>();

            foreach (var kvp in userExams)
            {
                totalPoint.Add(kvp.Key, kvp.Value.Values.Sum());
            }

            string bestUser = totalPoint.Keys.Max();
            int bestUserPoints = totalPoint.Values.Max();

            Console.WriteLine($"Best candidate is {bestUser} with total {bestUserPoints} points.");
            Console.WriteLine("Ranking:");
            foreach (var kvp in userExams.OrderBy(x=>x.Key))
            {
                Console.WriteLine(kvp.Key);
                foreach (var name in kvp.Value.OrderByDescending(x=>x.Value))
                {
                    Console.WriteLine($"#  {name.Key} -> {name.Value}");
                }
            }
        }
    }
}
