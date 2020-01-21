using System;
using System.Linq;
using System.Collections.Generic;

namespace _5._Bomb_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            List<int> bomb = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            int numberOfBomb = bomb[0];
            int powerOfBomb = bomb[1];

            while (numbers.Contains(numberOfBomb))
            {
                int indexOfBomb = numbers.IndexOf(numberOfBomb);

                for (int i = powerOfBomb; i > 0 && (indexOfBomb - 1) >= 0; i--)
                {
                    numbers.RemoveAt(indexOfBomb - 1);
                    indexOfBomb--;
                }
                indexOfBomb = numbers.IndexOf(numberOfBomb);

                for (int i = powerOfBomb; i > 0 && (indexOfBomb + 1) <= numbers.Count - 1; i--)
                {
                    numbers.RemoveAt(indexOfBomb + 1);
                }

                numbers.RemoveAt(indexOfBomb);
            }            

            Console.WriteLine(numbers.Sum());
        }
    }
}
