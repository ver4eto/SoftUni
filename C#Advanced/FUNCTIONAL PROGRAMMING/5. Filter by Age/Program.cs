using System;
using System.Collections.Generic;
using System.Linq;

namespace _5._Filter_by_Age
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());

            List<KeyValuePair<string, int>> people = new List<KeyValuePair<string, int>>();

            for (int i = 0; i < count; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries);

                string name = input[0];
                int age = int.Parse(input[1]);

                people.Add(new KeyValuePair<string, int>(name, age));
                
            }
            string filter = Console.ReadLine();
            int ageFilter = int.Parse(Console.ReadLine());

            string[] printPattern = Console.ReadLine()
                .Split(' ');

            people
                .Where(p => filter == "younger" ? p.Value < ageFilter : p.Value >= ageFilter)
                .ToList()
                .ForEach(p => Printer(p, printPattern));


        } 
        
        static void Printer(KeyValuePair<string, int> person, string [] printerPattern)
        {
            if (printerPattern.Length==2)
            {
                Console.WriteLine(printerPattern[0]=="name" ?
                    $"{person.Key} - {person.Value}" :
                    $"{person.Value} - { person.Key}");                    
            }
            else
            {
                Console.WriteLine(printerPattern[0] == "name" ?
                    $"{person.Key} " :
                    $"{person.Value} ");
            }
        }
    }
}
