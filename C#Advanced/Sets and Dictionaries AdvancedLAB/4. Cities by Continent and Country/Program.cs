using System;
using System.Linq;
using System.Collections.Generic;

namespace _4._Cities_by_Continent_and_Country
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            Dictionary<string, Dictionary<string, List<string>>> continents = new Dictionary<string, Dictionary<string, List<string>>>();


            for (int i = 0; i < number; i++)
            {
                var data = Console.ReadLine()
                   .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string continent = data[0];
                string country = data[1];
                string town = data[2];

                if (!continents.ContainsKey(continent))
                {
                    continents[continent]= new Dictionary<string, List<string>>();
                }
                if (!continents[continent].ContainsKey(country))
                {
                    continents[continent][country]=new List<string>();
                }
                continents[continent][country].Add(town);
            }

            foreach (var continent in continents)
            {
                Console.WriteLine($"{continent.Key}: ");
                foreach (var town in continent.Value)
                {
                    Console.WriteLine($" {town.Key} -> {(string.Join(", ", town.Value))}");
                }
            }
        }
    }
}
