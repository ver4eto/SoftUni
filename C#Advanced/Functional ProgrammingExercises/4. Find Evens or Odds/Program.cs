using System;
using System.Collections.Generic;
using System.Linq;

namespace _4._Find_Evens_or_Odds
{
    class Program
    {
        static void Main(string[] args)
        {


            int[] range = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

                int lowerBound = range[0];
            int upperBound = range[1];

            List<int> numbers = new List<int>();

            string numberType = Console.ReadLine();

            for (int i = lowerBound; i <= upperBound; i++)
            {
                numbers.Add(i);
            }

            Predicate<int> isEven = x => x % 2 == 0;
            Predicate<int> isOdd = x => x % 2 != 0;

            Action<List<int>> printNumbers = outputNumbers =>
            Console.WriteLine(string.Join(" ",outputNumbers));

            if (numberType=="odd")
            {
               numbers= numbers.Where(x => isOdd(x)).ToList();
            }
            else
            {
                numbers = numbers.Where(x => isEven(x)).ToList();
            }

            printNumbers(numbers);
        }
    }
}
