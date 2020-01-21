using System;
using System.Linq;

namespace _4._Add_VAT
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] prices = Console.ReadLine()
                 .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                 .Select(double.Parse)
                 .Select(p => p * 1.2)
                 .ToArray();

            foreach (var item in prices)
            {
                Console.WriteLine($"{ item:f2}");
            }
        }
    }
}
