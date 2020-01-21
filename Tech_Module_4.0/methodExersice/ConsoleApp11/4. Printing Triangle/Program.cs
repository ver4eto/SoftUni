using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.Printing_Triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            UpperTrianglePart(number);
            DownTrianglePart(number);

        }
        static void UpperTrianglePart(int number)
        {
            for (int i = 1; i <= number; i++)
            {
                RowPrint(i);
            }

        }
        static void DownTrianglePart(int number)
        {
            for (int i =number - 1; i >=1; i--)
            {
                RowPrint(i);
            }
        }
        static void RowPrint(int number)
        {
            for (int i = 1; i <= number; i++)
            {
                Console.Write(i+" ");
            }
            Console.WriteLine();
        }
    }
}
