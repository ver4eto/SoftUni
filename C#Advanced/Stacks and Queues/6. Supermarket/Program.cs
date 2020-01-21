using System;
using System.Collections.Generic;
using System.Linq;

namespace _6._Supermarket
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Queue<string> customers = new Queue<string>();

            while (input !="End")
            {
                if (input=="Paid")
                {
                    Console.WriteLine(string.Join("\n",customers));
                    customers.Clear();
                }
                else
                {
                    customers.Enqueue(input);
                }
                input = Console.ReadLine();
            }

            int count = customers.Count();
            Console.WriteLine($"{count} people remaining.");
        }
    }
}
