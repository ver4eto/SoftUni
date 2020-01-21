using System;
using System.Linq;

namespace Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            int numbers = int.Parse(Console.ReadLine());

            int[,] matrix = new int[numbers, numbers];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] input = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                }
            }


            int[] coordinates = Console.ReadLine()
                .Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

        

            for (int i = 0; i < coordinates.Length; i+=2)
            {
                int currentRow = coordinates[i];
                int currentCol = coordinates[i + 1];

                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        if (row==currentRow && col==currentCol && matrix[row, col]>0)
                        {
                            int power = matrix[row, col];
                            matrix[row, col] = 0;

                            if (IsInside(row-1,col-1, matrix))
                            {
                                if (matrix[row - 1, col - 1] >0 )
                                {
                                    matrix[row - 1, col - 1] -= power;
                                }
                            
                            }
                            if (IsInside(row-1, col, matrix))
                            {
                                if (matrix[row - 1, col] >0)
                                {
                                    matrix[row - 1, col] -= power;
                                }
                                
                            }
                            if (IsInside(row-1,col+1, matrix))
                            {
                                if (matrix[row - 1, col + 1]>0)
                                {
                                    matrix[row - 1, col + 1] -= power;
                                }
                            
                            }
                            if (IsInside(row, col-1, matrix))
                            {
                                if (matrix[row, col - 1]>0)
                                {
                                    matrix[row, col - 1] -= power;
                                }
                               
                            }
                            if (IsInside(row, col + 1, matrix))
                            {
                                if (matrix[row, col + 1]>0)
                                {
                                    matrix[row, col + 1] -= power;
                                }
                                
                            }
                            if (IsInside(row+1, col - 1, matrix))
                            {
                                if (matrix[row + 1, col - 1]>0)
                                {
                                    matrix[row + 1, col - 1] -= power;
                                }
                               
                            }
                            if (IsInside(row + 1, col , matrix))
                            {
                                if (matrix[row + 1, col]>0)
                                {
                                    matrix[row + 1, col] -= power;
                                }
                               
                            }
                            if (IsInside(row+1, col + 1, matrix))
                            {
                                if (matrix[row + 1, col + 1] >0)
                                {
                                    matrix[row + 1, col + 1] -= power;
                                }
                              
                            }
                        }
                    }
                }
                
            }
            int countAlive = 0;
            int sumAlive = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] > 0)
                    {
                        countAlive++;

                        sumAlive += matrix[row, col];
                    }
                }
            }
            Console.WriteLine($"Alive cells: {countAlive}");
            Console.WriteLine($"Sum: {sumAlive}");

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (col == matrix.GetLength(1) - 1)
                    {
                        Console.Write(matrix[row, col]);
                    }
                    else
                    {
                        Console.Write(matrix[row, col] + " ");
                    }

                }
                Console.WriteLine();
            }
        }

        private static bool IsInside(int row, int col, int[,] matrix)
        {
            if (row>=0 && row<matrix.GetLength(0) &&
                col>=0 && col<matrix.GetLength(1))
            {
                return true;
            }
            return false;
        }
    }
}
