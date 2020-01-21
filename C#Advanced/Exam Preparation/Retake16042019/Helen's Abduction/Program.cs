using System;

namespace Helen_s_Abduction
{
    class Program
    {
        static void Main(string[] args)
        {
            int parisSEnergy = int.Parse(Console.ReadLine());
            int rowsNumber = int.Parse(Console.ReadLine());

            char[][] field = new char[rowsNumber][];

            int parisRow = -1;
            int parisCol = -1;

            for (int i = 0; i < field.Length; i++)
            {
                char[] col = Console.ReadLine().ToCharArray();
                field[i] = col;
                for (int j = 0; j < col.Length; j++)
                {
                    if (col[j] == 'P')
                    {
                        parisRow = i;
                        parisCol = j;
                    }
                }
            }

            bool isMissionAccomplishe = false;

            while (parisSEnergy>0)
            {
                string[] tokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string direction = tokens[0];
                int spawnRow = int.Parse(tokens[1]);
                int spawnCol = int.Parse(tokens[2]);


                field[spawnRow][spawnCol] = 'S';
                switch (direction)
                {
                    case "up":
                        field[parisRow][parisCol] = '-';
                        parisRow -= 1;
                        parisSEnergy -= 1;
                        if (isOutside(parisRow, parisCol, field))
                        {
                            parisRow += 1;
                            field[parisRow][parisCol] = 'P';
                        }
                        else
                        {
                            if (FoundHelen(parisRow, parisCol, field))
                            {
                                field[parisRow][parisCol] = '-';
                                isMissionAccomplishe = true;
                                Console.WriteLine($"Paris has successfully abducted Helen! Energy left: {parisSEnergy}");
                                break;
                            }
                            else if (field[parisRow][parisCol] == 'S')
                            {
                                parisSEnergy -= 2;
                                if (EneryDropBelowZero(parisSEnergy))
                                {
                                    field[parisRow][parisCol] = 'X';
                                    Console.WriteLine($"“Paris died at {parisRow};{parisCol}.");
                                    break;
                                }
                                else
                                {
                                    field[parisRow][parisCol] = 'P';
                                }
                            }
                            else 
                            {
                                if (EneryDropBelowZero(parisSEnergy))
                                {
                                    field[parisRow][parisCol] = 'X';
                                    Console.WriteLine($"“Paris died at {parisRow};{parisCol}.");
                                    break;
                                }
                                field[parisRow][parisCol] = 'P';
                            }

                        }
                        break;
                    case "down":
                        field[parisRow][parisCol] = '-';
                        parisRow += 1;
                        parisSEnergy -= 1;
                        if (isOutside(parisRow, parisCol, field))
                        {
                            parisRow -= 1;
                            field[parisRow][parisCol] = 'P';
                        }
                        else
                        {
                            if (FoundHelen(parisRow, parisCol, field))
                            {
                                field[parisRow][parisCol] = '-';
                                isMissionAccomplishe = true;
                                Console.WriteLine($"Paris has successfully abducted Helen! Energy left: {parisSEnergy}");
                                break;
                            }
                            else if (field[parisRow][parisCol] == 'S')
                            {
                                parisSEnergy -= 2;
                                if (EneryDropBelowZero(parisSEnergy))
                                {
                                    field[parisRow][parisCol] = 'X';
                                    Console.WriteLine($"“Paris died at {parisRow};{parisCol}.");
                                    break;
                                }
                                else
                                {
                                    field[parisRow][parisCol] = 'P';
                                }
                            }
                            else
                            {
                                if (EneryDropBelowZero(parisSEnergy))
                                {
                                    field[parisRow][parisCol] = 'X';
                                    Console.WriteLine($"“Paris died at {parisRow};{parisCol}.");
                                    break;
                                }
                                field[parisRow][parisCol] = 'P';
                            }

                        }
                        break;
                    case "right":
                        field[parisRow][parisCol] = '-';
                        parisCol += 1;
                        parisSEnergy -= 1;
                        if (isOutside(parisRow, parisCol, field))
                        {
                            parisCol-= 1;
                            field[parisRow][parisCol] = 'P';
                        }
                        else
                        {
                            if (FoundHelen(parisRow, parisCol, field))
                            {
                                field[parisRow][parisCol] = '-';
                                isMissionAccomplishe = true;
                                Console.WriteLine($"Paris has successfully abducted Helen! Energy left: {parisSEnergy}");
                                break;
                            }
                            else if (field[parisRow][parisCol] == 'S')
                            {
                                parisSEnergy -= 2;
                                if (EneryDropBelowZero(parisSEnergy))
                                {
                                    field[parisRow][parisCol] = 'X';
                                    Console.WriteLine($"“Paris died at {parisRow};{parisCol}.");
                                    break;
                                }
                                else
                                {
                                    field[parisRow][parisCol] = 'P';
                                }
                            }
                            else
                            {
                                if (EneryDropBelowZero(parisSEnergy))
                                {
                                    field[parisRow][parisCol] = 'X';
                                    Console.WriteLine($"“Paris died at {parisRow};{parisCol}.");
                                    break;
                                }
                                field[parisRow][parisCol] = 'P';
                            }

                        }
                        break;
                    case "left":
                        field[parisRow][parisCol] = '-';
                        parisCol-= 1;
                        parisSEnergy -= 1;
                        if (isOutside(parisRow, parisCol, field))
                        {
                            parisCol += 1;
                            field[parisRow][parisCol] = 'P';
                        }
                        else
                        {
                            if (FoundHelen(parisRow, parisCol, field))
                            {
                                field[parisRow][parisCol] = '-';
                                isMissionAccomplishe = true;
                                Console.WriteLine($"Paris has successfully abducted Helen! Energy left: {parisSEnergy}");
                                break;
                            }
                            else if (field[parisRow][parisCol] == 'S')
                            {
                                parisSEnergy -= 2;
                                if (EneryDropBelowZero(parisSEnergy))
                                {
                                    field[parisRow][parisCol] = 'X';
                                    Console.WriteLine($"“Paris died at {parisRow};{parisCol}.");
                                    break;
                                }
                                else
                                {
                                    field[parisRow][parisCol] = 'P';
                                }
                            }
                            else
                            {
                                if (EneryDropBelowZero(parisSEnergy))
                                {
                                    field[parisRow][parisCol] = 'X';
                                    Console.WriteLine($"“Paris died at {parisRow};{parisCol}.");
                                    break;
                                }
                                field[parisRow][parisCol] = 'P';
                            }

                        }
                        break;
                    default:
                        break;
                }
                if (isMissionAccomplishe)
                {
                    break;
                }
            }

            foreach (char[] item in field)
            {
                Console.WriteLine(string.Join("",item ));
            }
            
        }


        private static bool FoundHelen(int row, int col, char[][] field)
        {
            if (field[row][col] == 'H')
            {
                return true;
            }
            return false;
        }

        private static bool EneryDropBelowZero(int energy)
        {
            if (energy <= 0)
            {
                return true;
            }
            return false;
        }

        private static bool isOutside(int row, int col, char[][] field)
        {
            if (row < 0 || row >= field.Length
                || col < 0 || col > field[row].Length)
            {
                return true;
            }
            return false;
        }
    }
}
