using System;
using System.Linq;
using System.Collections.Generic;

namespace _5.__Fashion_Boutique
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Stack<int> clothesInBox = new Stack<int>(input);
            int capacity = int.Parse(Console.ReadLine());
            int sumOfClothesValue = 0;
            int rackUsed = 1;

            while (clothesInBox.Count > 0)
            {
                sumOfClothesValue += clothesInBox.Peek();
                if (sumOfClothesValue<=capacity)
                {
                    clothesInBox.Pop();
                }
                else
                {
                    rackUsed++;
                    sumOfClothesValue = 0;
                }
            }
            Console.WriteLine(rackUsed);
        }
    }
}
