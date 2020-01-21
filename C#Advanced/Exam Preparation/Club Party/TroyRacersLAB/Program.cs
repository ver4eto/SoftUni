using System;

namespace TroyRacersLAB
{

    class Program
    {

        static char[][] battleField;
        static int firstPlayerRow;
        static int firstPlayerCol;

        static int secondPlayerRow;
        static int secondPlayerCol;

        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            battleField = new char[rows][];

            Initialize();


            while (true)
            {
                string[] direction = Console.ReadLine().Split();

                string firstDirection = direction[0];
                string secondDirection = direction[1];

                if (firstDirection=="down")
                {
                    firstPlayerRow++;

                    if (firstPlayerRow>battleField.Length-1)
                    {
                        firstPlayerRow = 0;
                    }
                }
                else if (firstDirection=="up")
                {
                    firstPlayerRow--;
                    if (firstPlayerRow<0)
                    {
                        firstPlayerRow = battleField.Length - 1;
                    }
                }
                else if (firstDirection == "left")
                {
                    firstPlayerCol--;
                    if (firstPlayerCol < 0)
                    {
                        firstPlayerCol = battleField[firstPlayerRow].Length - 1;
                    }
                }
                else if (firstDirection == "right")
                {
                    firstPlayerCol++;
                    if (firstPlayerCol == battleField[firstPlayerRow].Length-1)
                    {
                        firstPlayerCol = 0;
                    }
                }

               else if (battleField[firstPlayerRow][firstPlayerCol]=='s')
                {
                    battleField[firstPlayerRow][firstPlayerCol] = 'x';
                    End();
                }

                if (secondDirection=="down")
                {
                    secondPlayerRow++;
                    if (secondPlayerRow>battleField[secondPlayerRow].Length-1)
                    {
                        secondPlayerRow = 0;
                    }
                    else if(secondDirection=="up")
                    {
                        secondPlayerRow--;
                        if (secondPlayerRow<0)
                        {
                            secondPlayerRow = battleField[secondPlayerRow].Length - 1;
                        }
                    }
                    else if (secondDirection=="right")
                    {
                        secondPlayerCol++;
                        if (secondPlayerCol == battleField[secondPlayerRow].Length - 1)
                        {
                            secondPlayerCol = 0;
                        }
                    }
                    else if (secondDirection == "left")
                    {
                        secondPlayerCol--;
                        if (secondPlayerCol < 0)
                        {
                            secondPlayerCol = battleField[secondPlayerRow].Length - 1;
                        }
                    }
                }
            }
        }

        private static void End()
        {
            for (int row = 0; row < battleField.Length; row++)
            {
                for (int col = 0; col < battleField[row].Length; col++)
                {
                    Console.Write(battleField[row][col]);
                }
                Console.WriteLine();
            }
            Environment.Exit(0);
        }

        private static void Initialize()
        {
            for (int row = 0; row < battleField.Length; row++)
            {
                char[] input = Console.ReadLine().ToCharArray();
                battleField[row] = new char[input.Length];

                for (int col = 0; col < input.Length; col++)
                {
                    battleField[row][col] = input[col];

                    if (battleField[row][col]=='f')
                    {
                        firstPlayerCol = col;
                        firstPlayerRow = row;
                    }
                    else if (battleField[row][col]=='s')
                    {
                        secondPlayerCol = col;
                        secondPlayerRow = row;
                    }
                }
            }
        }
    }
}
