using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._Odd_Occurrences
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine()
                .Split()
                .ToList();

            Dictionary<string, int> words = new Dictionary<string, int>();

            for (int i = 0; i < input.Count; i++)
            {
                string current = input[i].ToLower();
                if (!words.ContainsKey(current))
                {
                    words[current] = 1;
                }
                else
                {
                    words[current]++;
                }
            }

            var listOdd = words.Where(x => x.Value % 2 != 0).Select(x => x.Key.ToString());

            Console.WriteLine(string.Join(", ",listOdd));
            //foreach (var item in listOdd)
            //{
            //    Console.Write($"{item.Key}, ");
            //}
        }
    }
}
