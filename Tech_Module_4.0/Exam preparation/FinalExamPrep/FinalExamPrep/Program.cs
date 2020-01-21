using System;
using System.Linq;
using System.Collections.Generic;

namespace FinalExamPrep
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Dictionary<string, List<string>> bandMembers = new Dictionary<string, List<string>>();
            Dictionary<string, int> bandPlayTime = new Dictionary<string, int>();
            List<string> members = new List<string>();

            while (input != "start of concert")
            {
                string[] tokens = input
                    .Split(new[] { ", ", "; " }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string command = tokens[0];
                string bandName = tokens[1];

                switch (command)
                {
                    case "Add":

                        if (!bandMembers.ContainsKey(bandName))
                        {
                            bandMembers.Add(bandName, new List<string>());
                            for (int i = 2; i < tokens.Length; i++)
                            {
                                string name = tokens[i];
                                bandMembers[bandName].Add(name);
                            }
                        }
                        else
                        {
                            for (int i = 2; i < tokens.Length; i++)
                            {
                                if (!bandMembers[bandName].Contains(tokens[i]))
                                {
                                    bandMembers[bandName].Add(tokens[i]);
                                }
                            }
                        }
                        //foreach (var band in bandMembers)
                        //{
                        //    Console.WriteLine(band.Key);
                        //    foreach (var name in band.Value)
                        //    {
                        //        Console.WriteLine($"----{name}----");
                        //    }
                        //}
                        break;
                    case "Play":
                        int time = int.Parse(tokens[2]);
                        if (!bandPlayTime.ContainsKey(bandName))
                        {
                            bandPlayTime.Add(bandName, time);
                        }
                        else
                        {
                            bandPlayTime[bandName] += time;
                        }
                        break;
                    default:
                        break;
                }

                input = Console.ReadLine();
            }

            string finalBand = Console.ReadLine();

            int totalTime = bandPlayTime.Sum(x => x.Value);
            Console.WriteLine($"Total time: { totalTime}");
            foreach (var band in bandPlayTime.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{band.Key} -> {band.Value}");
            }

            Console.WriteLine(finalBand);
            foreach (var name in bandMembers.Where(x => x.Key == finalBand))
            {
                foreach (var item in name.Value)
                {
                    Console.WriteLine($"=> {item}");
                }

            }
        }
    }
}
