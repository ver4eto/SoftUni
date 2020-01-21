using System;
using System.Linq;
using System.Collections.Generic;

namespace _3._Product_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, Dictionary<string, double>> shops = new SortedDictionary<string, Dictionary<string, double>>();

            var entry = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries);

            while (entry[0] != "Revision")
            {
                string currShop = entry[0];
                string product = entry[1];
                double price = double.Parse(entry[2]);

                if (!shops.ContainsKey(currShop))
                {
                    shops.Add(currShop,new Dictionary<string, double>());  
                }
                if (!shops[currShop].ContainsKey(product))
                {
                    shops[currShop].Add(product,0);
                }
                shops[currShop][product] = price;

                entry = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries);
            }

            foreach (var shop in shops)
            {
                Console.WriteLine($"{shop.Key}->");

                foreach (var product in shop.Value)
                {
                    Console.WriteLine($"Product: {product.Key}, Price: {product.Value}");
                }
            }
        }
    }
}
