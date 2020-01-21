using System;
using System.Linq;


namespace _6._Bomb_the_Basement
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine()
                 .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse)
                 .ToArray();

            int countRow = size[0];
            int countCols = size[1];

            int [] coordinates= Console.ReadLine()
                 .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse)
                 .ToArray();
            int whichRow = coordinates[0];
            int whichCol = coordinates[1];
            int radius = coordinates[2];

            int[,] basement= new int[countRow,countCols];

            
            for (int row = 0; row < countRow; row++)
            {
                for (int col = 0; col < countCols; col++)
                {
                    double area = Math.Sqrt(Math.Pow(row - whichRow, 2) + Math.Pow(col - whichCol, 2));

                    if (area<=radius)
                    {
                        basement[row, col] = 1;
                    }
                   
                }
               
            }

            for (int col = 0; col < basement.GetLength(1); col++)
            {
                int counter = 0;
                for (int row = 0; row < basement.GetLength(0); row++)
                {
                    if (basement[row,col]==1)
                    {
                        counter++;
                        basement[row, col] = 0;
                    }
                }

                for (int row = 0; row < counter; row++)
                {
                    basement[row, col]= 1;
                }
            }

            for (int col = 0; col < basement.GetLength(0); col++)
            {
                for (int row = 0; row < basement.GetLength(1); row++)
                {
                    Console.Write(basement[col, row]);
                }
                Console.WriteLine();
            }
        }
    }
}
