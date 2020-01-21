using System;
using System.Collections.Generic;
using System.Linq;

namespace _5._Count_Symbols
{
    class Program
    {
        static void Main(string[] args)
        {

            string input = Console.ReadLine();

            Dictionary<char, int> textCount = new Dictionary<char, int>();

            for (int i = 0; i < input.Length; i++)
            {
                if (!textCount.ContainsKey(input[i]))
                {
                    textCount.Add(input[i],1);
                }
                else
                {
                    textCount[input[i]]++;
                }
            }


            foreach (var symbol in textCount.OrderBy(x=>x.Key))
            {
                Console.WriteLine($"{symbol.Key}: {symbol.Value} time/s");
            }
        }
    }
}
