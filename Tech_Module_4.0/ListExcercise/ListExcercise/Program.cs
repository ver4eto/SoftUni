using System;
using System.Linq;
using System.Collections.Generic;

namespace ListExcercise
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> wagonsWithNumberOfPassengers = Console.ReadLine()
                .Split()
                 .Select(int.Parse)
                 .ToList();

            int singleWagonCapacity = int.Parse(Console.ReadLine());
            string[] command = Console.ReadLine()
                .Split()
                .ToArray();

            while (command[0]!="end")
            {
                if (command[0]=="Add")
                {
                    int newWagonPassengers = int.Parse(command[1]);
                    wagonsWithNumberOfPassengers.Add(newWagonPassengers);
                }
                else
                {
                    int passengersToBeAdded = int.Parse(command[0]);
                    
                    for (int i = 0; i < wagonsWithNumberOfPassengers.Count; i++)
                    {
                        if (wagonsWithNumberOfPassengers[i]+passengersToBeAdded<=singleWagonCapacity)
                        {
                            wagonsWithNumberOfPassengers[i] += passengersToBeAdded;
                            break;
                        }
                    }
                }

                command = Console.ReadLine()
                    .Split()
                    .ToArray();
            }
            Console.WriteLine(string.Join(" ",wagonsWithNumberOfPassengers));
        }
    }
}
