using System;
using System.Collections.Generic;
using System.Linq;

namespace _4._Matrix_shuffling
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int rowSize = sizes[0];
            int colSize = sizes[1];

            string[,] matrix = new string[rowSize, colSize];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string[] data = Console.ReadLine()
                    .Split()
                    .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = data[col];
                }
            }

            string input = Console.ReadLine();
            bool isValid = false;
            int rowOne = 0;
            int colOne = 0;
            int rowTwo = 0;
            int colTwo = 0;

            while (input !="END")
            {
                List<string> tokens = input
                    .Split()
                    .ToList();
                string command = tokens[0];

                if (tokens.Count == 5 && command == "swap")
                {
                     rowOne = int.Parse(tokens[1]);
                     colOne = int.Parse(tokens[2]);
                     rowTwo = int.Parse(tokens[3]);
                     colTwo = int.Parse(tokens[4]);


                    if (rowOne < matrix.GetLength(0)
                           && rowTwo < matrix.GetLength(0)
                           && colOne < matrix.GetLength(1)
                           && colTwo < matrix.GetLength(1))
                    {
                        isValid = true;
                    }
                }
                   
                    if (isValid)
                    {
                       string cuurentOneRow = matrix[rowOne, colOne];
                    string currentSecondRow=matrix[rowTwo,colTwo];

                        for (int row = 0; row < matrix.GetLength(0); row++)
                        {

                            for (int col = 0; col < matrix.GetLength(1); col++)
                            {
                                if (row == rowOne && col == colOne)
                                {
                                    matrix[rowOne, colOne] = currentSecondRow;
                                }
                                if (row == rowTwo && col == colTwo)
                                {
                                    matrix[rowTwo, colTwo] = cuurentOneRow;
                                }
                                Console.Write($"{matrix[row, col]} ");
                            }
                            Console.WriteLine();
                        }
                        cuurentOneRow = string.Empty;
                    }                   

                
                else
                {
                    Console.WriteLine("Invalid input!");
                }

              
                input = Console.ReadLine();
                isValid = false;
                
            }
        }
    }
}
