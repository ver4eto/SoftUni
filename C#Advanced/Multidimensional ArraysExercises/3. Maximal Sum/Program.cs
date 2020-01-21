using System;
using System.Linq;

namespace _3._Maximal_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine()
                 .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse)
                 .ToArray();

            int[,] matrix = new int[sizes[0], sizes[1]];

            int[,] maxMatrix = new int[3, 3];

            int maxSum = int.MinValue;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                }
            }

            int startIndexRow = 0;
            int startIndexCol = 0;


            for (int row = 0; row < matrix.GetLength(0)-2; row++)
            {
                for (int col = 0; col < matrix.GetLength(1)-2; col++)
                {
                    int currentSum = matrix[row, col]
                        + matrix[row, col + 1]
                        + matrix[row, col + 2]
                        + matrix[row + 1, col]
                        + matrix[row + 1, col + 1]
                        + matrix[row + 1, col + 2]
                        + matrix[row + 2, col]
                        + matrix[row + 2, col + 1]
                        + matrix[row + 2, col + 2];

                    if (currentSum>maxSum)
                    {
                        maxSum = currentSum;
                        startIndexCol = col;
                        startIndexRow = row;
                        //maxMatrix = new int[3, 3] {
                        //   { matrix[row, col], matrix[row, col + 1], matrix[row, col + 2] },
                        //{ matrix[row + 1, col], matrix[row + 1, col + 1], matrix[row + 1, col + 2] },
                        // { matrix[row + 2, col], matrix[row + 2, col + 1], matrix[row + 2, col + 2] }
                        //};
                    }
                    currentSum = 0;
                }
            }
            Console.WriteLine($"Sum = {maxSum}");
            for (int row = startIndexRow; row < startIndexRow+3; row++)
            {
                for (int col =startIndexCol; col < startIndexCol+3; col++)
                {
                    Console.Write($"{matrix[row,col]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
