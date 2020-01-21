using System;
using System.Linq;

namespace _8._Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            int[,] matrix = new int[size, size];

            for (int row = 0; row < size; row++)
            {
                int[] input = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = input[col];
                }
            }

            int[] inputCoordinates = Console.ReadLine()
                .Split(new char[] {' ',','}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int countAliveCells = 0;
            int sumAlive = 0;

            for (int i = 0; i < inputCoordinates.Length; i+=2)
            {
                int rowNumber = inputCoordinates[i];
                int colNumber = inputCoordinates[i + 1];
                countAliveCells++;

                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        if (row==rowNumber && col==colNumber && matrix[row,col]>0)
                        {
                            int currentBomb = matrix[row, col];
                            sumAlive += currentBomb;

                            if (row-1>=0)
                            {
                                if (col-1>=0)
                                {
                                    matrix[row - 1, col - 1] -= currentBomb;
                                }
                                matrix[row - 1, col] -= currentBomb;
                                if (col+1<=size-1)
                                {
                                    matrix[row - 1, col + 1] -= currentBomb;
                                }
                            }
                            if (col-1>=0)
                            {
                                matrix[row , col - 1] -= currentBomb;
                            }
                            if (col+1<=size-1)
                            {
                                matrix[row , col + 1] -= currentBomb;
                            }
                            if (row+1<=size-1)
                            {
                                if (col-1>=0)
                                {
                                    matrix[row + 1, col - 1] -= currentBomb;
                                }
                                matrix[row + 1, col] -= currentBomb;
                            }
                            if (col+1<=size-1)
                            {
                                matrix[row + 1, col + 1] -= currentBomb;
                            }
                            matrix[row, col] = 0;
                        }
                    }
                }
            }
            Console.WriteLine($"Alive cells: {countAliveCells}");
            Console.WriteLine($"Sum: {sumAlive}");
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write($"{matrix[row,col]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
