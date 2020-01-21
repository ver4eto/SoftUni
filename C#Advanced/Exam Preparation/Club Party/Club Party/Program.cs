using System;
using System.Collections.Generic;
using System.Linq;

namespace Club_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            int capacity = int.Parse(Console.ReadLine());

            Stack<string> information = new Stack<string>();

            string[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
           
          
            Queue<string> halls = new Queue<string>();
            List<int> allGroups = new List<int>();


            foreach (var item in input)
            {
                information.Push(item);
            }

            int currentCapacity = 0;

            while (information.Count>0)
            {
                string current = information.Pop();
             
                bool isNumber = int.TryParse(current, out int parsedNumber);

                if (!isNumber)
                {
                    halls.Enqueue(current);
                }
                else
                {
                    if (halls.Count==0)
                    {
                        continue;
                    }
                    if (currentCapacity+parsedNumber>capacity)
                    {
                        Console.WriteLine($"{halls.Dequeue()} -> {string.Join(", ",allGroups)}");
                        allGroups.Clear();
                        currentCapacity = 0;
                    }

                    if (halls.Count>0)
                    {
                        allGroups.Add(parsedNumber);

                        currentCapacity += parsedNumber;
                    }
                  
                }
            }
        }
    }
}
