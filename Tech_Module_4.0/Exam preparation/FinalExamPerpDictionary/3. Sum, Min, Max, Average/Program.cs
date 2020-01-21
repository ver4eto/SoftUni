using System;
using System.Linq;
using System.Collections.Generic;

namespace _3._Sum__Min__Max__Average
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>();
            int current = 0;
            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                current = int.Parse(Console.ReadLine());
                numbers.Add(current);
            }

            int sum = numbers.Sum();
            int min = numbers.Min();
            int max = numbers.Max();
            double average = numbers.Average();

            Console.WriteLine($"Sum = {sum}");
            Console.WriteLine($"Min = {min}");
            Console.WriteLine($"Max = {max}");
            Console.WriteLine($"Average = {average}");
        }
    }
}
