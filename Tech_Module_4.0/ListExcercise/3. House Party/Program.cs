using System;
using System.Linq;
using System.Collections.Generic;

namespace _3._House_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfCommands = int.Parse(Console.ReadLine());
            List<string> commands = new List<string>();
            
            List<string> guests = new List<string>();

            while (numberOfCommands>0)
            {
                commands = Console.ReadLine()
               .Split()
               .ToList();
                string name = commands[0];

                if (commands.Contains("not"))
                {
                    if (guests.Contains(name))
                    {
                        guests.Remove(name);
                    }
                    else
                    {
                        Console.WriteLine($"{name} is not in the list!");
                    }
                }
                else
                {
                    if (guests.Contains(name))
                    {
                        Console.WriteLine($"{name} is already in the list!");
                    }
                    else
                    {
                        guests.Add(name);
                    }
                }
               
                numberOfCommands--;
            }

          
            foreach (var guest in guests)
            {
                Console.WriteLine(guest);
            }

        }
    }
}
