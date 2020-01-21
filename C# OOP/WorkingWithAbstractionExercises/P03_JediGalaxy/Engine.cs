using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P03_JediGalaxy
{
   public  class Engine
    {
       private int[,] matrix ;
        private long sum;

        public void Run()
        {
            int[] dimensions = Console.ReadLine()
            .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

            int rowSize = dimensions[0];
            int colSize = dimensions[1];
           
            this.InitializeMatrix( rowSize, colSize);

            string command = Console.ReadLine();

            while (command != "Let the Force be with you")
            {
                int[] playerCoordinates = ReadingCoordinates(command);

                int[] evilCoordinates = ReadingCoordinates(Console.ReadLine());

                int evelRow = evilCoordinates[0];
                int evelCol = evilCoordinates[1];

                MoveEvil( evelRow,  evelCol);

                int playerRow = playerCoordinates[0];
                int playerCol = playerCoordinates[1];

                MovePlayer(/*sum,*/ ref playerRow, ref playerCol);

                command = Console.ReadLine();
            }

            Console.WriteLine(sum);
        }

        private static int[] ReadingCoordinates(string command)
        {
            int[] playerCoordinates = command
                .Split(new string[] { " "/*, "-"*/ }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            return playerCoordinates;
        }

        private void MovePlayer(/*ref long sum,*/ ref int playerRow, ref int playerCol)
        {
            while (playerRow >= 0 && playerCol < matrix.GetLength(1))
            {
                if (IsInsideMatrix(playerRow, playerCol))
                {
                    sum += matrix[playerRow, playerCol];                  
                }
                playerCol++;
                playerRow--;
            }
        }

        private void MoveEvil( int evelRow,  int evelCol)
        {
            while (evelRow >= 0 && evelCol >= 0)
            {
                if (IsInsideMatrix(evelRow, evelCol))
                {
                    matrix[evelRow, evelCol] = 0;
                    
                }
                evelRow--;
                evelCol--;
            }
        }

        private bool IsInsideMatrix(int row, int col)
        {
            if (row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1))
            {
                return true;  
            }
            return false;
        }

        private void InitializeMatrix(int rowSize, int colSize)
        {
            matrix = new int[rowSize, colSize];

            int value = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = value++;
                }
            }
        }

    }
}
