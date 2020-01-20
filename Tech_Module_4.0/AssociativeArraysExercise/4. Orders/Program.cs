using System;
using System.Collections.Generic;
using System.Linq;

namespace _4._Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, double[]> products = new Dictionary<string, double[]>();
           

            string command = Console.ReadLine();

            while (command!= "buy")
            {
                string[] input = command.Split().ToArray();

                string productName = input[0];
                double price = double.Parse(input[1]);
                double quantity = double.Parse(input[2]);

                if (!products.ContainsKey(productName))
                {
                    products.Add(productName,new double[2]);
                    products[productName][0] = price;
                    products[productName][1] = quantity;
                }
                else
                {
                    if (products[productName][0]!=price)
                    {
                        products[productName][0] = price;
                    }
                    products[productName][1] += quantity;
                }
                command = Console.ReadLine();
            }

            foreach (var product in products)
            {
                Console.WriteLine($"{product.Key} -> {(product.Value[0]*product.Value[1]):f2}");
            }
           
        }
    }
}
