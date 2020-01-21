using System;
using System.Collections.Generic;
using System.Linq;

namespace _1._Phonebook
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, string> phoneBook = new SortedDictionary<string, string>();
            string command = Console.ReadLine();

            while (command != "END")
            {
                if (command== "ListAll")
                {
                    foreach (var kvp in phoneBook)
                    {
                            Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
                    }

                    command = Console.ReadLine();
                    continue;
                }
                string [] tokens = command
                    .Split()
                    .ToArray();

                string action = tokens[0];
                string name = tokens[1];

                switch (action)
                {
                    case "A":
                        string number = tokens[2];

                        if (!phoneBook.ContainsKey(name))
                        {
                            phoneBook.Add(name,number);
                        }
                        else
                        {
                            phoneBook[name] = number;
                        }
                        break;
                    case "S":
                        if (!phoneBook.ContainsKey(name))
                        {
                            Console.WriteLine($"Contact {name} does not exist.");
                            
                        }
                        else
                        {
                            Console.WriteLine($"{name} -> {phoneBook[name]}");

                            //foreach (var kvp in phoneBook)
                            //{
                            //    if (kvp.Key==name)
                            //    {
                            //        Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
                            //    }
                            //}
                        }
                        break;
                    default:
                        break;
                }
                command = Console.ReadLine();
            }
        }
    }
}
