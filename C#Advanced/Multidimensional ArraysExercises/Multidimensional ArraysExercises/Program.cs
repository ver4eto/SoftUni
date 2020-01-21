using System;
using System.Linq;

namespace Multidimensional_ArraysExercises
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            int[,] matrix = new int[size, size];

            int firstDiagonalSum = 0;
            int secondDiagonalSum = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] input = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];

                    if (col==row)
                    {
                        firstDiagonalSum += matrix[row, col];
                    }
                    if (col+row==size-1)
                    {
                        secondDiagonalSum += matrix[row, col];
                    }
                }
            }

            //for (int row = 0; row < matrix.GetLength(0); row++)
            //{
            //    for (int col = matrix.GetLength(1) - 1; col >= 0; col--)
            //    {
            //        if (col==row)
            //        {
            //            secondDiagonalSum += matrix[row, col];
            //        }
            //    }
            //}

            int absSum = firstDiagonalSum - secondDiagonalSum;
            Console.WriteLine(Math.Abs(absSum));
        }
    }
}
