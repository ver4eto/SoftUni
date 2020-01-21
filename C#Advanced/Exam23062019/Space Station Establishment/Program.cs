using System;
using System.Collections.Generic;

namespace Space_Station_Establishment
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            char[,] matrix = new char[size, size];

            int stephansRow = -1;
            int stephansCol = -1;

            //Dictionary<int, int> blackHoles = new Dictionary<int, int>();
            List<int> blackHoles = new List<int>();

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] input = Console.ReadLine().ToCharArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                    if (matrix[row, col]=='S')
                    {
                        stephansRow = row;
                        stephansCol = col;
                    }
                    if (matrix[row, col]=='O')
                    {
                        //blackHoles.Add(row, col);
                        blackHoles.Add(row);
                        blackHoles.Add(col);
                    }
                }
            }

            bool isVoid = false;
            int starPower = 0;

            while (!isVoid/* && starPower<50*/)
            {
                string command = Console.ReadLine();
                switch (command)
                {
                    case "up":
                        int oldRow = stephansRow;
                        stephansRow -= 1;
                       
                        if (IsInsideMatrix(matrix, stephansRow, stephansCol))
                        {
                            if (FoundStar(matrix, stephansRow, stephansCol))
                            {
                                int currentPower = int.Parse(matrix[stephansRow, stephansCol].ToString());
                                starPower += currentPower;
                                matrix[oldRow, stephansCol] = '-';
                                matrix[stephansRow, stephansCol] = 'S';
                            }
                            else if (matrix[stephansRow, stephansCol]=='O')
                            {
                                matrix[stephansRow, stephansCol] = '-';
                                stephansRow = blackHoles[2];
                                stephansCol = blackHoles[3];
                                matrix[stephansRow, stephansCol] = 'S';
                               
                            }
                            else if (matrix[stephansRow, stephansCol]=='-')
                            {
                                matrix[oldRow, stephansCol] = '-';
                                matrix[stephansRow, stephansCol] = 'S';
                            }
                        }
                        else
                        {
                            isVoid = true;
                            stephansRow += 1;
                            matrix[stephansRow, stephansCol] = '-';
                        }
                        break;
                    case "down":
                        oldRow = stephansRow;
                        stephansRow += 1;

                        if (IsInsideMatrix(matrix, stephansRow, stephansCol))
                        {
                            if (FoundStar(matrix, stephansRow, stephansCol))
                            {
                                int currentPower = int.Parse(matrix[stephansRow, stephansCol].ToString());
                                starPower += currentPower;
                                matrix[oldRow, stephansCol] = '-';
                                matrix[stephansRow, stephansCol] = 'S';
                            }
                            else if (matrix[stephansRow, stephansCol] == 'O')
                            {
                                matrix[stephansRow, stephansCol] = '-';
                                stephansRow = blackHoles[2];
                                stephansCol = blackHoles[3];
                                matrix[stephansRow, stephansCol] = 'S';

                            }
                            else if (matrix[stephansRow, stephansCol] == '-')
                            {
                                matrix[oldRow, stephansCol] = '-';
                                matrix[stephansRow, stephansCol] = 'S';
                            }
                        }
                        else
                        {
                            isVoid = true;
                            stephansRow -= 1;
                            matrix[stephansRow, stephansCol] = '-';
                        }
                        break;
                    case "left":
                        int oldCol = stephansCol;
                        stephansCol-= 1;

                        if (IsInsideMatrix(matrix, stephansRow, stephansCol))
                        {
                            if (FoundStar(matrix, stephansRow, stephansCol))
                            {
                                int currentPower = int.Parse(matrix[stephansRow, stephansCol].ToString());
                                starPower += currentPower;
                                matrix[stephansRow, oldCol] = '-';
                                matrix[stephansRow, stephansCol] = 'S';
                            }
                            else if (matrix[stephansRow, stephansCol] == 'O')
                            {
                                matrix[stephansRow, oldCol] = '-';
                                stephansRow = blackHoles[2];
                                stephansCol = blackHoles[3];
                                matrix[stephansRow, stephansCol] = 'S';

                            }
                            else if (matrix[stephansRow, stephansCol] == '-')
                            {
                                matrix[stephansRow, oldCol] = '-';
                                matrix[stephansRow, stephansCol] = 'S';
                            }
                        }
                        else
                        {
                            isVoid = true;
                            stephansCol += 1;
                            matrix[stephansRow, stephansCol] = '-';
                        }
                        break;
                    case "right":
                        oldCol = stephansCol;
                        stephansCol += 1;

                        if (IsInsideMatrix(matrix, stephansRow, stephansCol))
                        {
                            if (FoundStar(matrix, stephansRow, stephansCol))
                            {
                                int currentPower = int.Parse(matrix[stephansRow, stephansCol].ToString());
                                starPower += currentPower;
                                matrix[stephansRow, oldCol] = '-';
                                matrix[stephansRow, stephansCol] = 'S';
                            }
                            else if (matrix[stephansRow, stephansCol] == 'O')
                            {
                               
                                matrix[stephansRow, oldCol] = '-';
                                matrix[stephansRow, oldCol + 1] = '-';
                                stephansRow = blackHoles[2];
                                stephansCol = blackHoles[3];
                                matrix[stephansRow, stephansCol] = 'S';

                            }
                            else if (matrix[stephansRow, stephansCol] == '-')
                            {
                                matrix[stephansRow, oldCol] = '-';
                                matrix[stephansRow, stephansCol] = 'S';
                            }
                        }
                        else
                        {
                            isVoid = true;
                            stephansCol -= 1;
                            matrix[stephansRow, stephansCol] = '-';
                        }
                        break;
                    default:
                        break;
                }

                if (starPower>=50)
                {
                    break;
                }
            }

            if (isVoid)
            {
                Console.WriteLine("Bad news, the spaceship went to the void.");
            }
            else
            {
                Console.WriteLine("Good news! Stephen succeeded in collecting enough star power!");
            }
            Console.WriteLine($"Star power collected: {starPower}");
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }

        private static bool FoundStar(char[,] matrix, int newRow, int stephansCol)
        {
            char current = matrix[newRow, stephansCol];
            if (Char.IsDigit(current))
            {
                return true;
            }
            return false;
        }

        private static bool IsInsideMatrix(char[,] matrix, int newRow, int stephansCol)
        {
            if (newRow>=0 && newRow<matrix.GetLength(0) && stephansCol>=0 && stephansCol<matrix.GetLength(1))
            {
                return true;
            }
            return false;
        }
    }
}
