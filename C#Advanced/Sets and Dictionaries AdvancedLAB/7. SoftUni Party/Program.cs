using System;
using System.Collections.Generic;
using System.Linq;

namespace _7._SoftUni_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> guests = new HashSet<string>();

            string entry = Console.ReadLine();

            while (entry?.ToLower() !="party")
            {
                guests.Add(entry);

                entry = Console.ReadLine();
            }
            entry = Console.ReadLine();

            while (entry?.ToLower() != "end")
            {
                guests.Remove(entry);

                entry = Console.ReadLine();
            }

            Console.WriteLine(guests.Count);

            foreach (var name in guests)
            {
                if (char.IsDigit(name[0]))
                {
                    Console.WriteLine(name);
                }
                
            }

            foreach (var name in guests)
            {
                if (!char.IsDigit(name[0]))
                {
                    Console.WriteLine(name);
                }
               
            }
        }
    }
}
