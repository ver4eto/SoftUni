using System;
using System.Collections.Generic;
using System.Linq;

namespace _4._Even_Times
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            Dictionary<int, int> allNumbers = new Dictionary<int, int>();

            for (int i = 0; i < number; i++)
            {
                int input = int.Parse(Console.ReadLine());
                if (!allNumbers.ContainsKey(input))
                {
                    allNumbers.Add(input,1);
                }
                else
                {
                    allNumbers[input]++;
                }
            }

            //foreach (var item in allNumbers)
            //{
            //    if (item.Value %2 ==0)
            //    {
            //        Console.WriteLine(item.Key);
            //    }
            //}

            int evenTimes = allNumbers
                .SingleOrDefault(x => x.Value % 2 == 0)
                .Key;

            Console.WriteLine(evenTimes);
        }
    }
}
