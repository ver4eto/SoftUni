using System;
using System.Linq;
using System.Collections.Generic;

namespace _2._A_Miner_Task
{
    class Program
    {
        static void Main(string[] args)
        {
            string resource = Console.ReadLine();
            int quantity = 0;

            //int count = 0;

            Dictionary<string, int> allResourcesQuantity = new Dictionary<string, int>();

            while (resource!="stop")
            {
                quantity = int.Parse(Console.ReadLine());
                //count++;

                if (allResourcesQuantity.ContainsKey(resource))
                {
                    allResourcesQuantity[resource] += quantity;
                }
                else
                {
                    allResourcesQuantity.Add(resource, quantity);
                }
                resource = Console.ReadLine();
            }

            foreach (var item in allResourcesQuantity)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}
