using System;
using System.Linq;

namespace _7.__Knight_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            char[,] board = new char[size, size];

            for (int row = 0; row < board.GetLength(0); row++)
            {
                char[] input = Console.ReadLine().ToCharArray();
                for (int col = 0; col < board.GetLength(1); col++)
                {
                    board[row, col] = input[col];
                }
            }

            int counter = 0;
            
            //bool isChanged = false;

            while (true)
            {
                int maxCoubntOfKnights = 0;
                int knightsCounter = 0;
                int rowOfTargetedKnight = 0;
                int colOfTargetedKnight = 0;

                for (int row = 0; row < board.GetLength(0); row++)
                {              
                    for (int col = 0; col < board.GetLength(1); col++)
                    {
                        knightsCounter = 0;

                        if (board[row, col] == 'K')
                        {
                            if (IsInside(board, row - 2, col + 1) && board[row - 2, col + 1] == 'K')
                            {
                                knightsCounter++;
                            }
                            if (IsInside(board, row - 2, col - 1) && board[row - 2, col - 1] == 'K')
                            {
                                knightsCounter++;
                            }
                            if (IsInside(board, row - 1, col + 2) && board[row - 1, col + 2] == 'K')
                            {
                                knightsCounter++;
                            }
                            if (IsInside(board, row - 1, col - 2) && board[row - 1, col - 2] == 'K')
                            {
                                knightsCounter++;
                            }
                            if (IsInside(board, row + 1, col - 2) && board[row + 1, col - 2] == 'K')
                            {
                                knightsCounter++;
                            }
                            if (IsInside(board, row + 1, col + 2) && board[row + 1, col + 2] == 'K')
                            {
                                knightsCounter++;
                            }
                            if (IsInside(board, row + 2, col + 1) && board[row + 2, col + 1] == 'K')
                            {
                                knightsCounter++;
                            }
                            if (IsInside(board, row + 2, col - 1) && board[row + 2, col - 1] == 'K')
                            {
                                knightsCounter++;
                            }
                            if (maxCoubntOfKnights < knightsCounter)
                            {
                                maxCoubntOfKnights = knightsCounter;
                                rowOfTargetedKnight = row;
                                colOfTargetedKnight = col;
                                //isChanged = true;
                            }
                        }
                    }
                }                                                 

                if (maxCoubntOfKnights == 0)
                {
                    break;
                }

                board[rowOfTargetedKnight, colOfTargetedKnight] = '0';
                counter++;
            }

            Console.WriteLine(counter);
        }

        private static bool IsInside(char[,] board, int desiredRoq, int desiredCol)
        {
            return (desiredRoq < board.GetLength(0) && desiredRoq >= 0
                 && desiredCol < board.GetLength(1) && desiredCol >= 0);

        }
    }
}
