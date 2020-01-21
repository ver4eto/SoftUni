using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P05_GreedyTimes
{
    public class Engine
    {
        private Dictionary<string, Dictionary<string, long>> bag;
        private long bagCapacity;

        public Engine()
        {
            bag = new Dictionary<string, Dictionary<string, long>>();
        }

        public void Run()
        {
            bagCapacity = long.Parse(Console.ReadLine());

            string[] items = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            long gold = 0;
            long gems = 0;
            long cash = 0;

            for (int i = 0; i < items.Length; i += 2)
            {
                string currentItem = items[i];
                long currentItemCount = long.Parse(items[i + 1]);

                string typeOfCurrentItem =this.WhatTypeIs(currentItem);
                

                if (typeOfCurrentItem == "")
                {
                    continue;
                }
                else if (IsBagCapacitySmallerThanCurrentBagSum(currentItemCount))
                {
                    continue;
                }

                switch (typeOfCurrentItem)
                {
                    case "Gem":
                        if (!bag.ContainsKey(typeOfCurrentItem))
                        {
                            if (bag.ContainsKey("Gold"))
                            {
                                if (currentItemCount > bag["Gold"].Values.Sum())
                                {
                                    continue;
                                }
                            }
                            else
                            {
                                continue;
                            }
                        }
                        else if (bag[typeOfCurrentItem].Values.Sum() + currentItemCount > bag["Gold"].Values.Sum())
                        {
                            continue;
                        }
                        break;
                    case "Cash":
                        if (!bag.ContainsKey(typeOfCurrentItem))
                        {
                            if (bag.ContainsKey("Gem"))
                            {
                                if (currentItemCount > bag["Gem"].Values.Sum())
                                {
                                    continue;
                                }
                            }
                            else
                            {
                                continue;
                            }
                        }
                        else if (bag[typeOfCurrentItem].Values.Sum() + currentItemCount > bag["Gem"].Values.Sum())
                        {
                            continue;
                        }
                        break;
                }

                if (!bag.ContainsKey(typeOfCurrentItem))
                {
                    bag[typeOfCurrentItem] = new Dictionary<string, long>();
                }

                if (!bag[typeOfCurrentItem].ContainsKey(currentItem))
                {
                    bag[typeOfCurrentItem][currentItem] = 0;
                }

                bag[typeOfCurrentItem][currentItem] += currentItemCount;

                if (typeOfCurrentItem == "Gold")
                {
                    gold += currentItemCount;
                }
                else if (typeOfCurrentItem == "Gem")
                {
                    gems += currentItemCount;
                }
                else if (typeOfCurrentItem == "Cash")
                {
                    cash += currentItemCount;
                }
            }

            foreach (var x in bag)
            {
                Console.WriteLine($"<{x.Key}> ${x.Value.Values.Sum()}");
                foreach (var item2 in x.Value.OrderByDescending(y => y.Key).ThenBy(y => y.Value))
                {
                    Console.WriteLine($"##{item2.Key} - {item2.Value}");
                }
            }
        }

        private bool IsBagCapacitySmallerThanCurrentBagSum(long currentItemCount)
        {
            return bagCapacity < bag.Values.Select(x => x.Values.Sum()).Sum() + currentItemCount;
        }

        private string WhatTypeIs(string currentItem)
        {
            string typeOfCurrentItem=string.Empty;

            if (currentItem.Length == 3)
            {
                typeOfCurrentItem = "Cash";
            }
            else if (currentItem.ToLower().EndsWith("gem"))
            {
                typeOfCurrentItem = "Gem";
            }
            else if (currentItem.ToLower() == "gold")
            {
                typeOfCurrentItem = "Gold";
            }

            return typeOfCurrentItem;
        }
    }
}
