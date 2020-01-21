using System;
using System.Collections.Generic;
using System.Linq;


namespace _7._The_V_Logger
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            Dictionary<string, List<string>> vloggersAndFallowers = new Dictionary<string,List<string>>();
            Dictionary<string, List<string>> vloggersWhoFollowsOthers = new Dictionary<string, List<string>>();

            while (command?.ToLower() !="statistics")
            {
                string[] input = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string vlogger = input[0];
                string action = input[1];
                string vloggerTwo = input[2];

                switch (action)
                {
                    case "joined":
                        if (!vloggersAndFallowers.ContainsKey(vlogger))
                        {
                            vloggersAndFallowers.Add(vlogger, new List<string>());
                            vloggersWhoFollowsOthers.Add(vlogger, new List<string>());
                        }
                        break;
                    case "followed":
                        if (vloggersAndFallowers.ContainsKey(vlogger) 
                            && vloggersAndFallowers.ContainsKey(vloggerTwo) 
                            && vlogger != vloggerTwo)
                        {
                            if (!vloggersAndFallowers[vloggerTwo].Contains(vlogger))
                            {
                                vloggersAndFallowers[vloggerTwo].Add(vlogger);

                                if (!vloggersWhoFollowsOthers.ContainsKey(vlogger))
                                {
                                    vloggersWhoFollowsOthers.Add(vlogger, new List<string>());
                                    vloggersWhoFollowsOthers[vlogger].Add(vloggerTwo);
                                }
                                else
                                {
                                    vloggersWhoFollowsOthers[vlogger].Add(vloggerTwo);
                                }
                            }   
                        }
                        break;
                    default:
                        break;
                }
                command = Console.ReadLine();
            }

            int countOfVloggers = vloggersAndFallowers.Count();
            Console.WriteLine($"The V-Logger has a total of {countOfVloggers} vloggers in its logs.");
            int count = 2;

            var topUser = vloggersAndFallowers.OrderByDescending(x => x.Value.Count)
                .ThenBy(x => vloggersWhoFollowsOthers[x.Key].Count())
                .FirstOrDefault();

            Console.WriteLine($"1. {topUser.Key} : {topUser.Value.Count} followers, {vloggersWhoFollowsOthers[topUser.Key].Count} following");

            foreach (var userName in topUser.Value.OrderBy(x=>x))
            {
                Console.WriteLine($"*  {userName}");
            }
            foreach (var kvp in vloggersAndFallowers.Where(x=>x.Key != topUser.Key)
                .OrderByDescending(x=>x.Value.Count)
                .ThenBy(x=>vloggersWhoFollowsOthers[x.Key].Count()))
            {
                Console.WriteLine($"{count}. {kvp.Key} : {kvp.Value.Count} followers, {vloggersWhoFollowsOthers[kvp.Key].Count} following");
                count++;
            }
            
            
        }
    }
}
