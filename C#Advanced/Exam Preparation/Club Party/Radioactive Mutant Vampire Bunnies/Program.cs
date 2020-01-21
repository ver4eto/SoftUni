using System;
using System.Collections.Generic;
using System.Linq;

namespace Radioactive_Mutant_Vampire_Bunnies
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            char[,] field = new char[sizes[0], sizes[1]];

            int playerRow = -1;
            int playerCol = -1;

            Dictionary<int, List<int>> bunniesIndexes = new Dictionary<int, List<int>>();

            for (int row = 0; row < field.GetLength(0); row++)
            {
                char[] input = Console.ReadLine().ToCharArray();

                for (int col = 0; col < field.GetLength(1); col++)
                {
                    field[row, col] = input[col];
                    if (field[row, col]=='P')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                    if (field[row, col]=='B')
                    {
                        if (!bunniesIndexes.ContainsKey(row))
                        {
                            bunniesIndexes.Add(row, new List<int>());
                            bunniesIndexes[row].Add(col);
                        }
                        else
                        {
                            bunniesIndexes[row].Add(col);
                        }
                    }
                }
            }

            char[] commands = Console.ReadLine().ToCharArray();
            bool isDead = false;
            bool hasWon = false;

            for (int i = 0; i < commands.Length; i++)
            {
                char currentCommand = commands[i];

                switch (currentCommand)
                {
                    case 'U':
                        field[playerRow, playerCol] = '.';
                        playerRow -= 1;
                        if (WinTheGame(playerRow, playerCol, field))
                        {
                            hasWon = true;
                            
                        }
                        else if(field[playerRow,playerCol]=='.')
                        {
                            field[playerRow, playerCol] = 'P';
                        }
                        else
                        {
                            isDead = true;
                        }
                        break;
                    case 'D':
                        field[playerRow, playerCol] = '.';
                        playerRow += 1;
                        if (WinTheGame(playerRow, playerCol, field))
                        {
                            hasWon = true;

                        }
                        else if (field[playerRow, playerCol] == '.')
                        {
                            field[playerRow, playerCol] = 'P';
                        }
                        else
                        {
                            isDead = true;
                        }
                        break;
                    case 'L':
                        field[playerRow, playerCol] = '.';
                        playerCol -= 1;
                        if (WinTheGame(playerRow, playerCol, field))
                        {
                            hasWon = true;

                        }
                        else if (field[playerRow, playerCol] == '.')
                        {
                            field[playerRow, playerCol] = 'P';
                        }
                        else
                        {
                            isDead = true;
                        }
                        break;
                    case 'R':
                        field[playerRow, playerCol] = '.';
                        playerCol += 1;
                        if (WinTheGame(playerRow, playerCol, field))
                        {
                            hasWon = true;

                        }
                        else if (field[playerRow, playerCol] == '.')
                        {
                            field[playerRow, playerCol] = 'P';
                        }
                        else
                        {
                            isDead = true;
                        }
                        break;
                    default:
                        break;
                }
                BunniesMove(field,bunniesIndexes,isDead);
                if (hasWon || isDead)
                {
                    break;
                }
            }

            for (int row = 0; row < field.GetLength(0); row++)
            {
                for (int col = 0; col < field.GetLength(1); col++)
                {
                    Console.Write(field[row, col]);
                }
                Console.WriteLine();
            }

            if (isDead)
            {
                Console.WriteLine($"dead:{playerRow}{playerCol}");
            }
            else
            {
                Console.WriteLine($"won:{playerRow}{playerCol}");
            }
        }

        private static void BunniesMove(char[,] field, Dictionary<int, List<int>> bunnieIndexes, /*int finalRow, int finalCol,*/ bool isDead)
        {
            isDead = false;
            Dictionary<int, List<int>> bunniesAdded = bunnieIndexes;

            foreach (var row in bunnieIndexes)
            {
                if (!bunniesAdded.ContainsKey(row.Key))
                {
                    bunniesAdded.Add(row.Key,new List<int>());
                }
                foreach (var col in row.Value)
                {
                    int bunnyRow = row.Key;
                    int bunnyCol = col;
                    if (!bunniesAdded[row.Key].Contains(col))
                    {
                        bunniesAdded[row.Key].Add(col);
                    }
                    if (isInside(field, bunnyRow+1, bunnyCol))
                    {
                        if (!bunniesAdded.ContainsKey(bunnyRow+1))
                        {
                            bunniesAdded.Add(bunnyRow + 1, new List<int>());
                            bunniesAdded[bunnyRow + 1].Add(bunnyCol);
                        }
                        else
                        {
                            bunniesAdded[bunnyRow + 1].Add(bunnyCol);
                        }
                        if (field[bunnyRow + 1, bunnyCol] == 'P')
                        {
                            isDead = true;
                            field[bunnyRow + 1, bunnyCol] = 'B';
                        }
                        else
                        {
                            field[bunnyRow + 1, bunnyCol] = 'B';
                        }
                    }
                    if (isInside(field, bunnyRow - 1, bunnyCol))
                    {
                        if (!bunniesAdded.ContainsKey(bunnyRow - 1))
                        {
                            bunniesAdded.Add(bunnyRow - 1, new List<int>());
                            bunniesAdded[bunnyRow - 1].Add(bunnyCol);
                        }
                        else
                        {
                            bunniesAdded[bunnyRow - 1].Add(bunnyCol);
                        }
                        if (field[bunnyRow - 1, bunnyCol] == 'P')
                        {
                            isDead = true;
                            field[bunnyRow - 1, bunnyCol] = 'B';
                        }
                        else
                        {
                            field[bunnyRow - 1, bunnyCol] = 'B';
                        }
                    }
                    if (isInside(field, bunnyRow, bunnyCol + 1))
                    {
                        if (!bunniesAdded.ContainsKey(bunnyRow ))
                        {
                            bunniesAdded.Add(bunnyRow , new List<int>());
                            bunniesAdded[bunnyRow ].Add(bunnyCol+1);
                        }
                        else
                        {
                            bunniesAdded[bunnyRow ].Add(bunnyCol+1);
                        }
                        if (field[bunnyRow, bunnyCol + 1] == 'P')
                        {
                            isDead = true;
                            field[bunnyRow, bunnyCol + 1] = 'B';
                        }
                        else
                        {
                            field[bunnyRow, bunnyCol + 1] = 'B';
                        }
                    }
                    if (isInside(field, bunnyRow, bunnyCol - 1))
                    {
                        if (!bunniesAdded.ContainsKey(bunnyRow ))
                        {
                            bunniesAdded.Add(bunnyRow , new List<int>());
                            bunniesAdded[bunnyRow ].Add(bunnyCol-1);
                        }
                        else
                        {
                            bunniesAdded[bunnyRow].Add(bunnyCol-1);
                        }
                        if (field[bunnyRow, bunnyCol - 1] == 'P')
                        {
                            isDead = true;
                            field[bunnyRow, bunnyCol - 1] = 'B';
                        }
                        else
                        {
                            field[bunnyRow, bunnyCol - 1] = 'B';
                        }
                    }
                }
            }

            //bunnieIndexes = bunniesAdded;

            
        }

        private static bool isInside(char[,] field, int row, int col)
        {
            if (row>=0 && col>=0 && row < field.GetLength(0) && col<field.GetLength(1))
            {
                return true;
            }
            return false;
        }

        private static bool WinTheGame(int playerRow, int playerCol, char[,] field)
        {
            if (playerRow<0 || playerCol>=field.GetLength(0) || playerCol<0 || playerCol>=field.GetLength(1))
            {
                return true;
            }
            return false;
        }
    }
}
