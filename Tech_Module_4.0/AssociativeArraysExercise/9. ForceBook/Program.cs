using System;
using System.Linq;
using System.Collections.Generic;

namespace _9._ForceBook
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, List<string>> sides = new SortedDictionary<string, List<string>>();
            string command = Console.ReadLine();

            while (command!= "Lumpawaroo")
            {
                
                if (command.Contains("|"))
                {
                    string[] input = command.Split(" | ",StringSplitOptions.RemoveEmptyEntries).ToArray();
                    string side = input[0];
                    string user = input[1];
                    
                    if (!sides.ContainsKey(side))
                    {
                        sides.Add(side, new List<string>());
                        if (!sides.Any(x=>x.Value.Contains(user)))
                        {
                            sides[side].Add(user);
                        }
                    }
                    else 
                    {
                        if (!sides.Any(x=>x.Value.Contains(user)))
                        {
                            sides[side].Add(user);
                        }                      
                    }
                }
                else if (command.Contains("->"))
                {
                    string[] input = command.Split(" -> ",StringSplitOptions.RemoveEmptyEntries).ToArray();
                    string side = input[1];
                    string user = input[0];

                    if (sides.Any(x=>x.Value.Contains(user)))
                    {
                        foreach (var sideUser in sides)
                        {
                            if (sideUser.Value.Contains(user))
                            {
                                sideUser.Value.Remove(user);
                            }
                        }
                        if (sides.ContainsKey(side))
                        {
                            sides[side].Add(user);
                        }
                        else
                        {
                            sides.Add(side, new List<string>());
                            sides[side].Add(user);
                        }
                    }
                    else
                    {
                        if (sides.ContainsKey(side))
                        {
                            sides[side].Add(user);
                        }
                        else
                        {
                            sides.Add(side, new List<string>());
                            sides[side].Add(user);
                        }
                    }
                    Console.WriteLine($"{user} joins the {side} side!");
                }
                command = Console.ReadLine();
            }

            foreach (var side in sides.OrderByDescending(x=>x.Value.Count()).Where(x=>x.Value.Count>0))
            {
                Console.WriteLine($"Side: {side.Key}, Members: {side.Value.Count()}");
                foreach (var name in side.Value.OrderBy(x=>x))
                {
                    Console.WriteLine($"! {name}");
                }
            }
        }
    }
}
