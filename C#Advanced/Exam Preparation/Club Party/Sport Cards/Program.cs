using System;
using System.Collections.Generic;
using System.Linq;

namespace Sport_Cards
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, double>> cards = new Dictionary<string, Dictionary<string, double>>();

            string command = Console.ReadLine();

            while (command!="end")
            {
                string[] tokens = command.Split(new char[] {' ','-'},StringSplitOptions.RemoveEmptyEntries);
                string action = tokens[0];

                if (action!="check")
                {
                    string sport = tokens[1];

                    double price = double.Parse(tokens[2]);

                    if (!cards.ContainsKey(action))
                    {
                        cards.Add(action, new Dictionary<string, double>());
                        cards[action].Add(sport,price);
                    }
                    else
                    {
                        if (!cards[action].ContainsKey(sport))
                        {
                            cards[action].Add(sport, price);
                        }
                        else
                        {
                            cards[action][sport] = price;
                        }
                    }
                }
                else
                {
                    string currentCard = tokens[1];

                    if (!cards.ContainsKey(currentCard))
                    {
                        Console.WriteLine($"{currentCard} is not available!");
                    }
                    else
                    {
                        Console.WriteLine($"{currentCard} is available!");
                    }
                }


                command = Console.ReadLine();
            }

           

            foreach (var card in cards.OrderByDescending(x => x.Value.Keys.Count()))
            {
                Console.WriteLine($"{ card.Key}:");
                foreach (var sport in card.Value.OrderBy(x=>x.Key))
                {
                    Console.WriteLine($"-{sport.Key} - {sport.Value:f2}");
                }
            }
        }
    }
}
