using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;


namespace arraysExcercise
{
    class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            int countOfNumbers = int.Parse(Console.ReadLine());

            int[] myArray = new int[length];
            int sum = 0;

            for (int i = 0; i < myArray.Length; i++)
            {
                if (i==0)
                {
                    myArray[i] = 1;
                }
                else
                {
                    for (int j = i; j <= countOfNumbers && j > 0; j--)
                    {
                        
                        sum += myArray[j];

                    }
                    myArray[i] = sum;
                }

                sum = 0;
                Console.Write(myArray[i]+" ");
            }

}
    }
}




