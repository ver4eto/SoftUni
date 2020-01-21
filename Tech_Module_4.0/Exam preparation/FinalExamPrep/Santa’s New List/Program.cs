using System;
using System.Collections.Generic;
using System.Linq;

namespace Santa_s_New_List
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> toys = new Dictionary<string, int>();
            Dictionary<string, int> children = new Dictionary<string, int>();

            string input = Console.ReadLine();

            while (input!="END")
            {
                string[] tokens = input.Split("->").ToArray();
                string action = tokens[0];
               
                if (action=="Remove")
                {
                    string name = tokens[1];
                    if (children.ContainsKey(name))
                    {
                        children.Remove(name);
                    }
                }
                else
                {
                    string name = action;
                    string typeOfToy = tokens[1];
                    int quantity = int.Parse(tokens[2]);

                    if (!toys.ContainsKey(typeOfToy))
                    {
                        toys.Add(typeOfToy,quantity);
                    }
                    else
                    {
                        toys[typeOfToy] += quantity;
                    }
                    if (!children.ContainsKey(name))
                    {
                        children.Add(name, quantity);
                    }
                    else 
                    {                      
                        children[name] += quantity;
                    }
                }
                input = Console.ReadLine();
            }
            Console.WriteLine("Children: ");
            foreach (var child in children.OrderByDescending(x=>x.Value).ThenBy(x=>x.Key))
            {
                Console.WriteLine($"{ child.Key} -> { child.Value}");
            }
            Console.WriteLine("Presents: ");
            foreach (var toy in toys/*.OrderByDescending(x=>x.Value)*/)
            {
                Console.WriteLine($"{ toy.Key} -> { toy.Value}");
            }
        }
    }
}
