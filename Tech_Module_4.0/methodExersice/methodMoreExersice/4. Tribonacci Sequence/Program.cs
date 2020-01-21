using System;

namespace _4._Tribonacci_Sequence
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
                      

            PrintTribonacciSequance(num);
        }

        private static void PrintTribonacciSequance(int num)
        {
            int[] numArray = new int[num];

            for (int i = 0; i < numArray.Length; i++)
            {
                if (i==0)
                {
                    numArray[i] = 1;
                }

                else if (i==1)
                {
                    numArray[i] = numArray[i - 1];
                }
                else if (i==2)
                {
                    numArray[i] = numArray[i - 1] + numArray[i - 2];
                }
                else
                {
                    numArray[i] = numArray[i - 1] + numArray[i - 2] + numArray[i - 3];
                }
                
            }

            Console.WriteLine(string.Join(" ",numArray));
           
        }
    }
}
