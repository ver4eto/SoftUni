using System;
using System.Linq;

namespace _2._Character_Multiplier
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries).ToArray();
            string one = input[0];
            string two = input[1];

            ReturnMultipliedSum(one, two);


        }

        private static void ReturnMultipliedSum(string one, string two)
        {
            int sum = 0;

            if (one.Length == two.Length)
            {
                for (int i = 0; i < one.Length; i++)
                {
                    sum += one[i] * two[i];
                }                
            }
            else
            {
                if (one.Length<two.Length)
                {
                    for (int i = 0; i < one.Length; i++)
                    {
                        sum += one[i] * two[i];
                    }
                    for (int i = one.Length; i < two.Length; i++)
                    {
                        sum += two[i];
                    }
                }
                else
                {
                    for (int i = 0; i < two.Length; i++)
                    {
                        sum += one[i] * two[i];
                    }
                    for (int i = two.Length; i < one.Length; i++)
                    {
                        sum += one[i];
                    }
                }
            }
            Console.WriteLine(sum);
        }
    }
}
