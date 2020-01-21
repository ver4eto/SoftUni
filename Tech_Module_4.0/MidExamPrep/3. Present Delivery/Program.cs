using System;
using System.Collections.Generic;
using System.Linq;

namespace _3._Present_Delivery
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> housesWithNumberOfPersons = Console.ReadLine()
                .Split('@')
                .Select(int.Parse)
                .ToList();
            string command = Console.ReadLine();
            int initialIndex = 0;
            int lastPositionIndex = 0;

            while (command != "Merry Xmas!")
            {
                string[] tokens = command.Split().ToArray();
                int lenght = int.Parse(tokens[1]);

                int currentIndex = initialIndex + lenght;
                if (currentIndex >= housesWithNumberOfPersons.Count)
                {
                    int count = lenght;
                    int newIndex = initialIndex;
                    while (count>0)
                    {
                        newIndex += 1;
                        if (newIndex==housesWithNumberOfPersons.Count)
                        {
                            newIndex = 0;
                        }
                        count--;
                    }
                    currentIndex = newIndex;
                }


                if (housesWithNumberOfPersons[currentIndex] == 0)
                {
                    Console.WriteLine($"House {currentIndex} will have a Merry Christmas.");
                }
                else
                {
                    housesWithNumberOfPersons[currentIndex] -= 2;
                }
                lastPositionIndex = currentIndex;

                initialIndex = currentIndex;
                command = Console.ReadLine();
            }
            Console.WriteLine($"Santa's last position was {lastPositionIndex}.");

            if (housesWithNumberOfPersons.Sum() == 0)
            {
                Console.WriteLine("Mission was successful.");
            }
            else
            {
                int count = 0;
                for (int i = 0; i < housesWithNumberOfPersons.Count; i++)
                {
                    if (housesWithNumberOfPersons[i] != 0)
                    {
                        count++;
                    }
                }
                Console.WriteLine($"Santa has failed {count} houses.");
            }
        }
    }
}
