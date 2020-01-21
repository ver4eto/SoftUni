using System;
using System.Linq;
using System.Collections.Generic;

namespace _4._Largest_3_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            foreach (var item in numbers.OrderByDescending(x => x).Take(3))
            {
                Console.Write($"{item} ");
            }
        }
    }
}
