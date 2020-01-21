using System;
using System.Collections.Generic;
using System.Text;

namespace _5.__Multiply_Big_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            string bigNumber = Console.ReadLine().TrimStart(new char[] { '0'});

            int smallNumber = int.Parse(Console.ReadLine());

            StringBuilder product = new StringBuilder();
            List<int> forReverse = new List<int>();

            int remaining = 0;
            int toBeAdded = 0;
            if (bigNumber=="0" || smallNumber==0)
            {
                product.Append(0);
                
            }
            else
            {
                for (int i = bigNumber.Length - 1; i >= 0; i--)
                {
                    int currentNumber = Math.Abs(int.Parse(bigNumber[i].ToString()));
                    if (i == 0 && currentNumber == 0)
                    {
                        toBeAdded = 0;
                        forReverse.Add(toBeAdded);
                        continue;
                    }
                    int currentSum = Math.Abs(smallNumber) * currentNumber + remaining;

                    if (currentSum >= 10 && i != 0)
                    {
                        remaining = currentSum / 10;
                        toBeAdded = currentSum % 10;
                    }
                    else if (currentSum >= 10 && i == 0)
                    {
                        toBeAdded = currentSum;
                    }
                    else
                    {
                        toBeAdded = currentSum;
                        remaining = 0;
                    }
                    forReverse.Add(toBeAdded);
                }
            }
           
            for (int i = forReverse.Count - 1; i >= 0; i--)
            {
                product.Append(forReverse[i]);
            }
            
            Console.WriteLine(product);
            
           
        }
    }
}
