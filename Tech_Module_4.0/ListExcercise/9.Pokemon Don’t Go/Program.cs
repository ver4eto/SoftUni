using System;
using System.Linq;
using System.Collections.Generic;

namespace _9.Pokemon_Don_t_Go
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToList();
            int sum = 0;           
            int currentNumber ;

            while (numbers.Count>0)
            {
                int indexReceived = int.Parse(Console.ReadLine());

                if (indexReceived < 0)
                {
                    int lastNumber = numbers.Last();
                    currentNumber = numbers[0];
                    sum += currentNumber;
                    numbers.RemoveAt(0);
                    numbers.Insert(0, lastNumber);
                }
                else if (indexReceived > numbers.Count - 1)
                {
                    int firstElement = numbers.First();
                    currentNumber = numbers[numbers.Count - 1];
                    sum += currentNumber;
                    numbers.RemoveAt(numbers.Count - 1);
                    numbers.Add(firstElement);
                }
                else
                {
                    currentNumber = numbers[indexReceived];
                    sum += currentNumber;
                    numbers.RemoveAt(indexReceived);
                }

                for (int i = 0; i < numbers.Count; i++)
                {

                    if (numbers[i] > currentNumber)
                    {
                        numbers[i] -= currentNumber;
                    }
                    else if (numbers[i] <= currentNumber)
                    {
                        numbers[i] += currentNumber;
                    }
                }
                
            }
            Console.WriteLine(sum);
        }
    }
}
