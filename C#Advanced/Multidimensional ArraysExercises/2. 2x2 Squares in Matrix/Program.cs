using System;
using System.Linq;

namespace _2._2x2_Squares_in_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            //char[,] equalMatrix = new char[2, 2];

            string[,] matrix = new string[sizes[0], sizes[1]];

            int countOfSquareMat = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string[] input = Console.ReadLine()
                    .Split()                    
                    .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                }
            }

            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    if (matrix[row, col] == matrix[row, col + 1]
                        && matrix[row, col] == matrix[row + 1, col]
                        && matrix[row + 1, col] == matrix[row + 1, col + 1])
                    {
                        countOfSquareMat++;
                    }
                }
            }
            Console.WriteLine(countOfSquareMat);
        }
    }
}
