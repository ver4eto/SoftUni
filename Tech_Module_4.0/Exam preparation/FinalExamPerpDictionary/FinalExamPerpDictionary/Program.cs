using System;
using System.Collections.Generic;
using System.Linq;

namespace FinalExamPerpDictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<double, int> numbers = new Dictionary<double, int>();

            List<double> input = Console.ReadLine()
                .Split()
                .Select(double.Parse)
                .ToList();

            for (int i = 0; i < input.Count; i++)
            {
                if (!numbers.ContainsKey(input[i]))
                {
                    numbers[input[i]] = 1;
                }
                else
                {
                    numbers[input[i]]++;
                }
            }

            foreach (var number in numbers.OrderBy(x=>x.Key))
            {
                Console.WriteLine($"{number.Key} -> {number.Value}" );
            }
        }
    }
}
