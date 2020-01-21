using System;
using System.Collections.Generic;
using System.Linq;

namespace _4._List_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            string[] commands = Console.ReadLine()
                .Split()
                .ToArray();

            while (commands[0]!="End")
            {
                string action = commands[0];
                switch (action)
                {
                    case "Add":
                        int numberNew = int.Parse(commands[1]);
                        numbers.Add(numberNew);
                        break;
                    case "Insert":
                        int insertNumber = int.Parse(commands[1]);
                        int index = int.Parse(commands[2]);
                        if (index<0 || index>=numbers.Count)
                        {
                            Console.WriteLine("Invalid index");
                            break;
                        }
                        numbers.Insert(index, insertNumber);
                        break;
                    case "Remove":
                        int removeAtIndex = int.Parse(commands[1]);
                        if (removeAtIndex < 0 || removeAtIndex >= numbers.Count)
                        {
                            Console.WriteLine("Invalid index");
                            break;
                        }
                        numbers.RemoveAt(removeAtIndex);
                        break;
                    case "Shift":
                        string direction = commands[1];
                        int countOfMoves = int.Parse(commands[2]);
                        if (direction=="left")
                        {
                            while (countOfMoves>0)
                            {
                                numbers.Add(numbers[0]);
                                numbers.RemoveAt(0);
                                countOfMoves--;
                            }
                        }
                        else
                        {
                            while (countOfMoves>0)
                            {
                                numbers.Insert(0, numbers[numbers.Count - 1]);
                                numbers.RemoveAt(numbers.Count - 1);
                                countOfMoves--;
                            }
                        }
                        break;
                    default:
                        break;
                }
                commands = Console.ReadLine()
                    .Split()
                    .ToArray();
            }
            Console.WriteLine(string.Join(" ",numbers));
        }
    }
}
