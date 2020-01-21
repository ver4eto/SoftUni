using System;
using System.Linq;
using System.Collections.Generic;

namespace _6._Cards_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> firstDeckCards = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            List<int> secondDeckCards = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            int firstDeckLength = firstDeckCards.Count;
            int secondDeckLenght = secondDeckCards.Count;

            for (int i = 0; i < firstDeckCards.Count; i++)
            {
                if (firstDeckCards[i] > secondDeckCards[i])
                {
                    firstDeckCards.Add(firstDeckCards[i]);
                    firstDeckCards.Add(secondDeckCards[i]);
                    firstDeckCards.RemoveAt(i);
                    secondDeckCards.RemoveAt(i);
                    secondDeckLenght--;
                    firstDeckLength++;
                    i -= 1;
                    if (secondDeckLenght==0 || firstDeckLength==0)
                    {
                        break;
                    }
                   

                }
                else if (secondDeckCards[i] > firstDeckCards[i])
                {
                    secondDeckCards.Add(secondDeckCards[i]);
                    secondDeckCards.Add(firstDeckCards[i]);
                    secondDeckCards.RemoveAt(i);
                    firstDeckCards.RemoveAt(i);
                    i -= 1;
                    firstDeckLength--;
                    secondDeckLenght++;
                    if (firstDeckLength == 0 || secondDeckLenght==0)
                    {
                        break;
                    }
                }
                else if (secondDeckCards[i] == firstDeckCards[i])
                {
                    secondDeckCards.RemoveAt(i);
                    firstDeckCards.RemoveAt(i);
                    i -= 1;
                    firstDeckLength--;
                    secondDeckLenght--;
                    if (firstDeckLength == 0 || secondDeckLenght==0)
                    {
                        break;
                    }
                }
            }

            if (firstDeckCards.Sum()>secondDeckCards.Sum())
            {
                Console.WriteLine($"First player wins! Sum: {firstDeckCards.Sum()}");
            }
            else if (secondDeckCards.Sum()>firstDeckCards.Sum())
            {
                Console.WriteLine($"Second player wins! Sum: {secondDeckCards.Sum()}");
            }
        }
    }
}
