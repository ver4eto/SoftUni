using System;
using System.Collections.Generic;
using System.Linq;

namespace _6._Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            Dictionary<string, Dictionary<string, int>> clothesInWardrobe = new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < number; i++)
            {
                string[] data = Console.ReadLine()
                    .Split(" -> ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string color = data[0];
                if (!clothesInWardrobe.ContainsKey(color))
                {
                    clothesInWardrobe.Add(color, new Dictionary<string, int>());
                }
                string [] clothes = data[1]
                    .Split(",", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                               
                for (int j = 0; j < clothes.Length; j++)
                {
                    string currentClothe = clothes[j];
                    if (!clothesInWardrobe[color].ContainsKey(currentClothe))
                    {
                        clothesInWardrobe[color].Add(currentClothe, 1);
                    }
                    else
                    {
                        clothesInWardrobe[color][currentClothe]++;
                    }
                    
                }
            }

            string[] toBeFound = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            string colorToBeFound = toBeFound[0];
            string clotheToBeFound= toBeFound[1];

            foreach (var color in clothesInWardrobe)
            {
                Console.WriteLine($"{color.Key} clothes: ");
                foreach (var clothe in color.Value)
                {
                    if (colorToBeFound==color.Key && clotheToBeFound==clothe.Key)
                    {
                        Console.WriteLine($"* {clothe.Key} - {clothe.Value} (found!) ");
                    }
                    else
                    {
                        Console.WriteLine($"* {clothe.Key} - {clothe.Value} ");
                    }
                }
            }
        }
    }
}
