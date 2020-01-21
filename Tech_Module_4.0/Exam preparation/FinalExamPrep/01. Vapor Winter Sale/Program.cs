using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Vapor_Winter_Sale
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(", ")
                .ToArray();

            Dictionary<string, double> games = new Dictionary<string, double>();
            Dictionary<string, string> gamesDLC = new Dictionary<string, string>();

            for (int i = 0; i < input.Length; i++)
            {
                string current = input[i];
                string[] tokens = current.Split(new char[] { ':', '-' }).ToArray();
                string game = tokens[0];

                if (current.Contains('-'))
                {
                    double price = double.Parse(tokens[1]);
                    if (!games.ContainsKey(game))
                    {
                        games[game] = price;
                    }

                    games[game] = price;

                }
                else if (current.Contains(':'))
                {
                    string dlc = tokens[1];
                    if (games.ContainsKey(game))
                    {
                        gamesDLC.Add(game, dlc);
                        games[game] *= 1.2;
                    }
                }
            }

            Dictionary<string, double> reducedPrice = new Dictionary<string, double>();

            foreach (var item in games)
            {
                reducedPrice.Add(item.Key, 0);
                if (gamesDLC.ContainsKey(item.Key))
                {
                    reducedPrice[item.Key] = 0.5 * item.Value;
                }
                else
                {
                    reducedPrice[item.Key] = 0.8 * item.Value;
                }
            }

            foreach (var game in reducedPrice.OrderBy(x => x.Value))
            {
                foreach (var item in gamesDLC)
                {
                    if (item.Key == game.Key)
                    {
                        Console.WriteLine($"{game.Key} - {item.Value} - {game.Value:f2}");
                    }
                }

            }



            foreach (var game in reducedPrice.OrderByDescending(x => x.Value))
            {

                if (gamesDLC.ContainsKey(game.Key))
                {
                    continue;
                }
                else
                {
                    Console.WriteLine($"{game.Key} - {game.Value:f2}");
                }

            }
        }
    }
}
