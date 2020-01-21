using System;
using System.Linq;
using System.Collections.Generic;

namespace DemoMID
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> breads = Console.ReadLine().Split('#').Select(int.Parse).ToList();
            string command = Console.ReadLine();

            while (command != "Bake It!")
            {
                List<int> commands = command.Split('#').Select(int.Parse).ToList();

                if (commands.Sum()>breads.Sum())
                {
                    breads = commands;
                }
                if (breads.Sum()==commands.Sum() && breads.Count>commands.Count)
                {
                    breads = commands;
                }
                command = Console.ReadLine();
            }
            Console.WriteLine($"Best Batch quality: {breads.Sum()}");
            Console.WriteLine(string.Join(" ",breads));
        }
    }
}
