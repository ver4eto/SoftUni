using System;
using System.Collections.Generic;
using System.Linq;

namespace Hello__France
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> items = Console.ReadLine()
                .Split('|')
                               .ToList();
            List<double> boughtIncreasedPrice = new List<double>();
            double increasedPrice = 0;

            double clothesMaxPrice = 50.00;
            double shoesMaxPrice = 35.00;
            double accessMaxPrice = 20.50;

            double budget = double.Parse(Console.ReadLine());

            double profit = 0;


            string typeOfItem = string.Empty;
            double priceCurrentItem = 0;

            for (int i = 0; i < items.Count; i++)
            {
                string current = items[i].ToString();
                string[] currentItem = current.Split("->").ToArray();
                typeOfItem = currentItem[0];
                priceCurrentItem = double.Parse(currentItem[1]);

                switch (typeOfItem)
                {
                    case "Clothes":
                        if (priceCurrentItem > clothesMaxPrice)
                        {
                            break;
                        }
                        else
                        {
                            if (budget >= priceCurrentItem)
                            {
                                budget -= priceCurrentItem;
                                increasedPrice = priceCurrentItem * 1.4;
                                profit += increasedPrice - priceCurrentItem;
                                boughtIncreasedPrice.Add(increasedPrice);
                            }

                        }
                        break;
                    case "Shoes":
                        if (priceCurrentItem > shoesMaxPrice)
                        {
                            break;
                        }
                        else
                        {
                            if (budget >= priceCurrentItem)
                            {
                                budget -= priceCurrentItem;
                                increasedPrice = priceCurrentItem * 1.4;
                                profit += increasedPrice - priceCurrentItem;
                                boughtIncreasedPrice.Add(increasedPrice);
                            }

                        }
                        break;
                    case "Accessories":
                        if (priceCurrentItem > accessMaxPrice)
                        {
                            break;
                        }
                        else
                        {
                            if (budget >= priceCurrentItem)
                            {
                                budget -= priceCurrentItem;
                                increasedPrice = priceCurrentItem * 1.4;
                                profit += increasedPrice - priceCurrentItem;
                                boughtIncreasedPrice.Add(increasedPrice);
                            }

                        }
                        break;
                    default:
                        break;
                }
            }

            double sumAll = boughtIncreasedPrice.Sum();
            double newBudget = budget + sumAll;

            foreach (var item in boughtIncreasedPrice)
            {
                Console.Write($"{item:f2} " );
            }
            Console.WriteLine();
            Console.WriteLine($"Profit: {profit:f2}");
            if (newBudget >= 150)
            {
                Console.WriteLine("Hello, France!");
            }
            else
            {
                Console.WriteLine("Time to go.");
            }
        }
    }
}
