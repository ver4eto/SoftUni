using System;
using System.Collections.Generic;

namespace _3._A_Miner_Task
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> resources = new Dictionary<string, int>();
            string command = Console.ReadLine();

            while (command!="stop")
            {
                int quantity = int.Parse(Console.ReadLine());

                if (!resources.ContainsKey(command))
                {
                    resources.Add(command, quantity);
                }
                else
                {
                    resources[command] += quantity;
                }

                command = Console.ReadLine();
            }

            foreach (var kvp in resources)
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
            }
        }
    }
}
