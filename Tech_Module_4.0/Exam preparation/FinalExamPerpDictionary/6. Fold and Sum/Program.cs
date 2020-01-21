using System;
using System.Collections.Generic;
using System.Linq;


namespace _6._Fold_and_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            List<int> sum = new List<int>();

           
            List<int> upper = new List<int>();

            int countOfLeftAndRight = numbers.Length / 4;
            int countOfLower = countOfLeftAndRight*2;

            List<int> lower = numbers.Skip(countOfLeftAndRight).Take(countOfLower).ToList();
            for (int i=countOfLeftAndRight-1; i >=0; i--)
            {
                int current = numbers[i];
                upper.Add(current);              
            }
            for (int i = numbers.Length - 1; i >= 0 && countOfLeftAndRight>0; i--)
            {
                int current = numbers[i];
                upper.Add(current);
                countOfLeftAndRight--;
            }
                       
            for (int i = 0; i < upper.Count; i++)
            {
                sum.Add(upper[i] + lower[i]);
            }
            Console.WriteLine(string.Join(" ", sum));


        }
    }
}
