using System;
using System.Linq;
using System.Collections.Generic;

namespace AssociativeArraysExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Dictionary<char, int> counts = new Dictionary<char, int>();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i]==' ')
                {
                    continue;
                }
                if (counts.ContainsKey(input[i]))
                {
                    counts[input[i]]++;
                }
                else
                {
                    counts.Add(input[i], 1);    
                }
            }
            foreach (var item in counts)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}
