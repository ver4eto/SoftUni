using System;
using System.Linq;

namespace Miner
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            int countOfCoals = 0;

            string[] commands = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);

            char[,] matrix = new char[size, size];

            int starPositionRow = 0;
            int startPositionCol = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                    if (matrix[row, col]=='s')
                    {
                        starPositionRow = row;
                        startPositionCol = col;
                    }
                    else if (matrix[row, col]=='c')
                    {
                        countOfCoals++;
                    }
                }
            }

            int collectedCoals = 0;
            bool isOver = false;

            for (int i = 0; i < commands.Length; i++)
            {
                string currentCommand = commands[i];

                switch (currentCommand)
                {
                    case "up":

                        if (IsInside(starPositionRow - 1, startPositionCol, matrix))
                        {
                            matrix[starPositionRow, startPositionCol] = '*';

                            starPositionRow -= 1;

                            if (HasEnded(starPositionRow, startPositionCol,matrix))
                            {
                                Console.WriteLine($"Game over! ({starPositionRow}, {startPositionCol})");
                                isOver = true;
                            }
                            else if (IsCoal(starPositionRow, startPositionCol, matrix))
                            {
                                countOfCoals--;
                                collectedCoals++;
                                matrix[starPositionRow, startPositionCol] = '*';
                            }                           
                          
                        }
                        break;
                    case "down":
                        if (IsInside(starPositionRow + 1, startPositionCol, matrix))
                        {
                            matrix[starPositionRow, startPositionCol] = '*';

                            starPositionRow += 1;

                            if (HasEnded(starPositionRow, startPositionCol, matrix))
                            {
                                Console.WriteLine($"Game over! ({starPositionRow}, {startPositionCol})");
                                isOver = true;
                            }
                            else if (IsCoal(starPositionRow, startPositionCol, matrix))
                            {
                                countOfCoals--;
                                collectedCoals++;
                                matrix[starPositionRow, startPositionCol] = '*';
                            }

                        }
                        break;
                    case "right":
                        if (IsInside(starPositionRow , startPositionCol+1, matrix))
                        {
                            matrix[starPositionRow, startPositionCol] = '*';

                            startPositionCol += 1;

                            if (HasEnded(starPositionRow, startPositionCol, matrix))
                            {
                                Console.WriteLine($"Game over! ({starPositionRow}, {startPositionCol})");
                                isOver = true;
                            }
                            else if (IsCoal(starPositionRow, startPositionCol, matrix))
                            {
                                countOfCoals--;
                                collectedCoals++;
                                matrix[starPositionRow, startPositionCol] = '*';
                            }

                        }
                        break;
                    case "left":
                        if (IsInside(starPositionRow , startPositionCol -1, matrix))
                        {
                            matrix[starPositionRow, startPositionCol] = '*';

                            startPositionCol -= 1;

                            if (HasEnded(starPositionRow, startPositionCol, matrix))
                            {
                                Console.WriteLine($"Game over! ({starPositionRow}, {startPositionCol})");
                                isOver = true;
                            }
                            else if (IsCoal(starPositionRow, startPositionCol, matrix))
                            {
                                countOfCoals--;
                                collectedCoals++;
                                matrix[starPositionRow, startPositionCol] = '*';
                            }

                        }
                        break;
                    default:
                        break;
                }
                if (isOver || countOfCoals==0)
                {
                    break;
                }
            }
            if (!isOver)
            {
                if (countOfCoals==0)
                {
                    Console.WriteLine($"You collected all coals! ({ starPositionRow}, { startPositionCol})");
                }
                else
                {
                    Console.WriteLine($"{countOfCoals-collectedCoals} coals left. ({starPositionRow}, {startPositionCol})");
                }
            }
        }

        private static bool IsCoal(int starPositionRow, int startPositionCol, char[,] matrix)
        {
            if (matrix[starPositionRow, startPositionCol] == 'c')
            {
                return true;
            }
            return false;
        }

        private static bool HasEnded(int starPositionRow, int startPositionCol, char[,] matrix)
        {
            if (matrix[starPositionRow,startPositionCol]=='e')
            {
                return true;
            }
            return false;
        }

        private static bool IsInside(int row, int col, char [,] matrix)
        {
            if (row>=0 && row<matrix.GetLength(0)&&
                col>=0 && col<matrix.GetLength(1))
            {
                return true;
            }
            return false;
        }
    }
}
