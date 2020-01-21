using System;
using System.Linq;

namespace Tron_Racers
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            char[,] matrix = new char[number, number];

            int indexRowFirst = -1;
            int indexColFirst = -1;

            int indexRowSecond = -1;
            int indexColSecond = -1;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] input = Console.ReadLine().ToCharArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                    if (matrix[row, col] == 'f')
                    {
                        indexRowFirst = row;
                        indexColFirst = col;
                    }
                    else if (matrix[row, col] == 's')
                    {
                        indexRowSecond = row;
                        indexColSecond = col;
                    }
                }
            }

            int countOfPlayers = 2;

            while (countOfPlayers == 2)
            {
                string[] commands = Console.ReadLine().Split();

                string firstCommand = commands[0];

                string secondCommand = commands[1];

                if (firstCommand == "up")
                {
                    if (IsInside(indexRowFirst - 1, indexColFirst, matrix))
                    {
                        if (!CanBeChanged(matrix, indexRowFirst - 1, indexColFirst))
                        {
                            matrix[indexRowFirst - 1, indexColFirst] = 'x';
                            countOfPlayers--;
                            break;
                        }
                        matrix[indexRowFirst - 1, indexColFirst] = 'f';
                        indexRowFirst = indexRowFirst - 1;
                    }
                    else
                    {
                        int newRow = number - 1;
                        if (!CanBeChanged(matrix, newRow, indexColFirst))
                        {
                            matrix[newRow, indexColFirst] = 'x';
                            countOfPlayers--;
                            break;
                        }
                        matrix[newRow, indexColFirst] = 'f';
                        indexRowFirst = newRow;
                    }

                }
                else if (firstCommand == "down")
                {
                    if (IsInside(indexRowFirst + 1, indexColFirst, matrix))
                    {
                        if (!CanBeChanged(matrix, indexRowFirst + 1, indexColFirst))
                        {
                            matrix[indexRowFirst + 1, indexColFirst] = 'x';
                            countOfPlayers--;
                            break;
                        }
                        matrix[indexRowFirst + 1, indexColFirst] = 'f';
                        indexRowFirst = indexRowFirst + 1;
                    }
                    else
                    {
                        int newRow = 0;
                        matrix[newRow, indexColFirst] = 'f';
                        indexRowFirst = newRow;
                    }
                }
                else if (firstCommand == "right")
                {
                    if (IsInside(indexRowFirst, indexColFirst + 1, matrix))
                    {
                        if (!CanBeChanged(matrix, indexRowFirst, indexColFirst + 1))
                        {
                            matrix[indexRowFirst, indexColFirst + 1] = 'x';
                            countOfPlayers--;
                            break;
                        }
                        matrix[indexRowFirst, indexColFirst + 1] = 'f';
                        indexColFirst += 1;
                    }
                    else
                    {
                        int newCol = 0 /*col - (number - 1)*/;
                        int newRow = indexRowFirst /*+ 1*/;
                        if (!CanBeChanged(matrix, newRow, newCol))
                        {
                            matrix[newRow, newCol] = 'x';
                            countOfPlayers--;
                            break;
                        }
                        matrix[newRow, newCol] = 'f';
                        indexRowFirst = newRow;
                        indexColFirst = newCol;
                    }
                }
                else if (firstCommand == "left")
                {
                    if (IsInside(indexRowFirst, indexColFirst - 1, matrix))
                    {
                        if (!CanBeChanged(matrix, indexRowFirst, indexColFirst - 1))
                        {
                            countOfPlayers--;
                            matrix[indexRowFirst, indexColFirst - 1] = 'x';
                            break;
                        }
                        matrix[indexRowFirst, indexColFirst - 1] = 'f';
                        indexColFirst = indexColFirst - 1;
                    }
                    else
                    {
                        int newRow = indexRowFirst /*+ 1*/;
                        int newCol = matrix.GetLength(1) - 1; /*col + (number - 1);*/

                        if (!CanBeChanged(matrix, newRow, newCol))
                        {
                            countOfPlayers--;
                            matrix[newRow, newCol] = 'x';
                            break;
                        }
                        matrix[newRow, newCol] = 'f';
                        indexRowFirst = newRow;
                        indexColFirst = newCol;
                    }
                }

                if (secondCommand == "up")
                {
                    if (IsInside(indexRowSecond - 1, indexColSecond, matrix))
                    {
                        if (!CanBeChanged(matrix, indexRowSecond - 1, indexColSecond))
                        {
                            matrix[indexRowSecond - 1, indexColSecond] = 'x';
                            countOfPlayers--;
                            break;
                        }
                        matrix[indexRowSecond - 1, indexColSecond] = 's';
                        indexRowSecond = indexRowSecond - 1;
                    }
                    else
                    {
                        int newRow = number - 1;
                        if (!CanBeChanged(matrix, newRow, indexColSecond))
                        {
                            matrix[newRow, indexColSecond] = 'x';
                            countOfPlayers--;
                            break;
                        }
                        matrix[newRow, indexColSecond] = 's';
                        indexRowSecond = newRow;
                    }

                }
                else if (secondCommand == "down")
                {
                    if (IsInside(indexRowSecond + 1, indexColSecond, matrix))
                    {
                        if (!CanBeChanged(matrix, indexRowSecond + 1, indexColSecond))
                        {
                            matrix[indexRowSecond + 1, indexColSecond] = 'x';
                            countOfPlayers--;
                            break;
                        }
                        matrix[indexRowSecond + 1, indexColSecond] = 's';
                        indexRowSecond = indexRowSecond + 1;
                    }
                    else
                    {
                        int newRow = 0;
                        if (!CanBeChanged(matrix, newRow, indexColSecond))
                        {
                            matrix[newRow, indexColSecond] = 'x';
                            countOfPlayers--;
                            break;
                        }
                        matrix[newRow, indexColSecond] = 's';
                        indexRowSecond = newRow;

                    }
                }
                else if (secondCommand == "right")
                {
                    if (IsInside(indexRowSecond, indexColSecond + 1, matrix))
                    {
                        if (!CanBeChanged(matrix, indexRowSecond, indexColSecond + 1))
                        {
                            matrix[indexRowSecond, indexColSecond + 1] = 'x';
                            countOfPlayers--;
                            break;
                        }
                        matrix[indexRowSecond, indexColSecond + 1] = 's';

                        indexColSecond += 1;
                    }
                    else
                    {
                        int newCol = 0;
                        int newRow = indexRowSecond;
                        if (!CanBeChanged(matrix, newRow, newCol))
                        {
                            matrix[newRow, newCol] = 'x';
                            countOfPlayers--;
                            break;
                        }
                        matrix[newRow, newCol] = 's';
                        indexRowSecond = newRow;
                        indexColSecond = newCol;
                    }
                }
                else if (secondCommand == "left")
                {
                    if (IsInside(indexRowSecond, indexColSecond - 1, matrix))
                    {
                        if (!CanBeChanged(matrix, indexRowSecond, indexColSecond - 1))
                        {
                            matrix[indexRowSecond - 1, indexColSecond] = 'x';
                            countOfPlayers--;
                            break;
                        }
                        matrix[indexRowSecond, indexColSecond - 1] = 's';
                        indexColSecond = indexColSecond - 1;
                    }
                    else
                    {
                        int newCol = matrix.GetLength(1) - 1; /*col + (number - 1);*/
                        int newRow = indexRowSecond;
                        if (!CanBeChanged(matrix, newRow, newCol))
                        {
                            matrix[newRow, newCol] = 'x';
                            countOfPlayers--;
                            break;
                        }
                        matrix[newRow, newCol] = 'f';
                        indexRowSecond = newRow;
                        indexColSecond = newCol;
                    }
                  
                }


            }
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }

        private static bool CanBeChanged(char[,] matrix, int row, int col)
        {
            if (matrix[row, col] == '*')
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static bool IsInside(int row, int col, char[,] matrix)
        {
            if (row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
