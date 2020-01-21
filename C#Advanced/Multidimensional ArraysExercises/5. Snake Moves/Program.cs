using System;
using System.Linq;
using System.Collections.Generic;


namespace _5._Snake_Moves
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

           string input = Console.ReadLine();
            Queue <char> word= new Queue<char>();

            foreach (var ch in input)
            {
                word.Enqueue(ch);
            }
            char[,] matrix = new char[rowSize, colSize];


            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    char current = word.Peek();
                    matrix[row, col] = word.Dequeue();
                    word.Enqueue(current);
                    Console.Write($"{matrix[row, col]}");
                }
                Console.WriteLine();
            }

            //for (int row = 0; row < matrix.GetLength(0); row++)
            //{
            //    for (int col = 0; col < matrix.GetLength(1); col++)
            //    {
            //        Console.Write($"{matrix[row,col]}");
            //    }
            //    Console.WriteLine();
            //}
        }
    }
}
