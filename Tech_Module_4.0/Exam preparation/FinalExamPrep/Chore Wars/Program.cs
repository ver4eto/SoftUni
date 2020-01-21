using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Chore_Wars
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int totalTimeDishes = 0;
            int totalTimeCleaning = 0;
            int totalTimeLaundry = 0;

            while (input != "wife is happy")
            {
                string dishesPattern = @"<(?<dishes>[a-z0-9]+)>";
                string cleaningTheHousePattern = @"\[(?<CLEANING>[A-Z0-9]+)\]";
                string laundryPattern = @"{(?<laundry>.+)}";

                Regex regexDishes = new Regex(dishesPattern);
                Regex regexCleaning = new Regex(cleaningTheHousePattern);
                Regex laundryRegex = new Regex(laundryPattern);

                if (regexDishes.IsMatch(input))
                {
                    Match dishes = Regex.Match(input, dishesPattern);
                    for (int i = 0; i < dishes.ToString().Length; i++)
                    {
                        if (char.IsDigit(dishes.ToString()[i]))
                        {
                            totalTimeDishes += int.Parse(dishes.ToString()[i].ToString());
                        }
                    }
                }
                else if (regexCleaning.IsMatch(input))
                {
                    Match cleaning = Regex.Match(input, cleaningTheHousePattern);
                    for (int i = 0; i < cleaning.Length; i++)
                    {
                        if (char.IsDigit(cleaning.ToString()[i]))
                        {
                            totalTimeCleaning += int.Parse(cleaning.ToString()[i].ToString());
                        }
                    }
                }
                else if (laundryRegex.IsMatch(input))
                {
                    Match laundry = Regex.Match(input, laundryPattern);
                    for (int i = 0; i < laundry.Length; i++)
                    {
                        if (char.IsDigit(laundry.ToString()[i]))
                        {
                            totalTimeLaundry += int.Parse(laundry.ToString()[i].ToString());
                        }
                    }
                }

                input = Console.ReadLine();
            }
            Console.WriteLine($"Doing the dishes - {totalTimeDishes} min.");
            Console.WriteLine($"Cleaning the house - {totalTimeCleaning} min.");
            Console.WriteLine($"Doing the laundry - {totalTimeLaundry} min.");
            int totalTime = totalTimeCleaning + totalTimeDishes + totalTimeLaundry;
            Console.WriteLine($"Total - {totalTime} min.");


        }
    }
}
