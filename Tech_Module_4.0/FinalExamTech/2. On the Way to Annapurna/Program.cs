using System;
using System.Linq;
using System.Collections.Generic;

namespace _2._On_the_Way_to_Annapurna
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Dictionary<string, List<string>> stores = new Dictionary<string, List<string>>();


            while (input!= "END")
            {
                string[] tokens = input
                    .Split( "->" /*,StringSplitOptions.RemoveEmptyEntries*/)
                    .ToArray();
                string action = tokens[0];
                string store = tokens[1];

                switch (action)
                {
                    case "Add":
                         List<string> items = new List<string>();
                        string[] itemsToAdd = tokens[2].Split(',').ToArray();

                        for (int i = 0; i < itemsToAdd.Length; i++)
                        {
                            items.Add(itemsToAdd[i]);
                        }
                        if (!stores.ContainsKey(store))
                        {
                            stores.Add(store,items);
                        }
                        else
                        {
                            foreach (var item in items)
                            {

                                //if (!stores[store].Contains(item))
                                //{
                                    stores[store].Add(item);
                                //}
                               
                            }
                        }
                        break;
                    case "Remove":
                        if (stores.ContainsKey(store))
                        {
                            stores.Remove(store);
                        }
                        break;
                    default:
                        break;
                }
                input = Console.ReadLine();
            }

            Console.WriteLine("Stores list:");
            foreach (var store in stores.OrderByDescending(x=>x.Value.Count).ThenByDescending(x => x.Key))
            {
                Console.WriteLine($"{ store.Key}");
                foreach (var item in store.Value)
                {
                    Console.WriteLine($"<<{ item}>>");
                }
            }
        }
    }
}
