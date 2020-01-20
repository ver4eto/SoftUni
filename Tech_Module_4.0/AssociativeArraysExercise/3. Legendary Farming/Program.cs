using System;
using System.Linq;
using System.Collections.Generic;

namespace _3._Legendary_Farming
{
    class Program
    {
        static void Main(string[] args)
        {
         

            Dictionary<string, int> keyMaterials = new Dictionary<string, int>
            {
                ["fragments"] = 0,
                ["shards"] = 0,
                ["motes"] = 0
            };

            Dictionary<string, int> others = new Dictionary<string, int>();

            string item = string.Empty;
            int quantity = 0;
            bool reached250 = false;

            while (!reached250)
            {
              string[]  input = Console.ReadLine()
               .Split(' ',StringSplitOptions.RemoveEmptyEntries)
               .ToArray();

                for (int i = 0; i < input.Length; i += 2)
                {
                    quantity = int.Parse(input[i]);
                    item = input[i + 1].ToLower();

                    if (item== "fragments"|| item== "shards" || item== "motes")
                    {
                        keyMaterials[item] += quantity;
                        if (keyMaterials[item] >= 250)
                        {
                            keyMaterials[item] -= 250;
                            if (item == "shards")
                            {
                                Console.WriteLine("Shadowmourne obtained!");
                            }
                            else if (item == "fragments")
                            {
                                Console.WriteLine("Valanyr obtained!");
                            }
                            else if (item == "motes")
                            {
                                Console.WriteLine("Dragonwrath obtained!");
                            }
                            reached250 =true;
                            break;
                        }
                    }
                    else
                    {
                        if (!others.ContainsKey(item))
                        {
                            others.Add(item, quantity);
                        }
                        else
                        {                         
                            others[item] += quantity;
                        }
                    }

                }
               
            }

            foreach (var keyMaterial in keyMaterials.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{keyMaterial.Key.ToLower()}: {keyMaterial.Value}");
            }

            foreach (var junk in others.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{junk.Key.ToLower()}: {junk.Value}");
            }
        }
    }
}
