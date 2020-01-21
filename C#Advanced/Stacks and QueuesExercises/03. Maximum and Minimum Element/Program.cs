using System;
using System.Linq;
using System.Collections.Generic;

namespace _03._Maximum_and_Minimum_Element
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
                       
            Stack<int> final = new Stack<int>();

            while (n>0)
            {
               int[] tokens= Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
                string command = tokens[0].ToString();
                switch (command)
                {
                    case "1":
                        int toPush = tokens[1];
                        final.Push(toPush);
                        break;
                    case "2":
                        if (final.Count>0)
                        {
                            final.Pop();
                        }                        
                        break;
                    case "3":
                        if (final.Count>0)
                        {
                            Console.WriteLine($"{final.Max()}");
                        }
                       
                        break;
                    case "4":
                        if (final.Count>0)
                        {
                            Console.WriteLine($"{final.Min()}");
                        }
                       
                        break;
                    default:
                        break;
                }
                n--;
            }
            Console.WriteLine(string.Join(", ",final));
        }
    }
}
