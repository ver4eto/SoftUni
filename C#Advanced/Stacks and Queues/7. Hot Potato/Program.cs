using System;
using System.Collections.Generic;
using System.Linq;

namespace _7._Hot_Potato
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Queue<string> names = new Queue<string>(input);

            int count = int.Parse(Console.ReadLine());

            while (names.Count>1)
            {
                for (int i = 1; i < count; i++)
                {
                    string current = names.Dequeue();
                    names.Enqueue(current);
                }

                Console.WriteLine($"Removed {names.Dequeue()}");                                
            }
            Console.WriteLine($"Last is {names.Dequeue()}");
        }
        
    }
}
