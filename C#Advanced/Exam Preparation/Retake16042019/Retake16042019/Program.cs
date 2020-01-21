using System;
using System.Collections.Generic;
using System.Linq;

namespace Retake16042019
{
    class Program
    {
        static void Main(string[] args)
        {
            //            3-number of waves
            //10 20 30-plates queue
            //4 5 1-warriors for current wave stack
            //10 5 5-warriors for current wave
            //10 10 10-warriors for current wave
            //4-every third wave get 1 additional line with the plate we need to add

            int numberOfWaves = int.Parse(Console.ReadLine());
            int [] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            //Queue<int> plates = new Queue<int>(input);

            List<int> plates = new List<int>(input);

            input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            Stack<int> warriors = new Stack<int>(input);


            for (int i = 1; i <= numberOfWaves; i++)
           
            {
                if (warriors.Count==0 || plates.Count==0)
                {
                    break;
                }
                if (i % 3 == 0)
                {
                    int additonalLine = int.Parse(Console.ReadLine());
                    plates.Add(additonalLine);

                }                             

                while (plates.Count>0 && warriors.Count>0)
                {
                    int currentPlatesValue = plates[0];
                    plates.RemoveAt(0);

                    int currentWarriorValue = warriors.Pop();

                    if (currentWarriorValue > currentPlatesValue)
                    {
                        warriors.Push(currentWarriorValue - currentPlatesValue);
                        //plates.Dequeue();
                    }
                    else if (currentPlatesValue > currentWarriorValue)
                    {
                        currentPlatesValue -= currentWarriorValue;
                        //plates.Dequeue();
                        plates.Insert(0,currentPlatesValue);
                    }
                    else
                    {
                        currentPlatesValue -= currentWarriorValue;                       
                    }
                }
                if (plates.Count==0)
                {
                    break;
                }

                if (i==numberOfWaves)
                {
                    break;
                }
                input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                foreach (var item in input)
                {
                    warriors.Push(item);
                }

            }
            if (plates.Count==0)
            {
                Console.WriteLine("The Trojans successfully destroyed the Spartan defense.");
                Console.WriteLine($"Warriors left: {string.Join(", ", warriors)}");
            }
            else
            {
                Console.WriteLine("The Spartans successfully repulsed the Trojan attack.");
                Console.WriteLine($"Plates left: {string.Join(", ",plates)}");
            }
        }
    }
}
