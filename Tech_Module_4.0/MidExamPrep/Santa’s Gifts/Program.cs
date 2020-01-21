using System;
using System.Collections.Generic;
using System.Linq;

namespace Santa_s_Gifts
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfCommands = int.Parse(Console.ReadLine());
            List<int> houses = Console.ReadLine()
                 .Split()
                 .Select(int.Parse)
                 .ToList();

            int previousIndex = 0;
            int currentIndex = previousIndex;

            while (numberOfCommands>0)
            {
                string [] command = Console.ReadLine().Split().ToArray();

                string action = command[0];
                switch (action)
                {
                    case "Forward":
                        int numberOfSteps =int.Parse( command[1]);
                        currentIndex = previousIndex + numberOfSteps;
                        if (currentIndex>=houses.Count)
                        {
                            currentIndex -=  numberOfSteps;
                            break;
                        }
                        else
                        {
                            previousIndex = currentIndex;
                            houses.RemoveAt(currentIndex);                            
                        }
                        break;
                    case "Back":
                        numberOfSteps =int.Parse( command[1]);
                        currentIndex = previousIndex - numberOfSteps;
                        if (currentIndex<0)
                        {
                            currentIndex += numberOfSteps;
                            break;
                        }
                        else
                        {
                            previousIndex = currentIndex;
                            houses.RemoveAt(currentIndex);
                        }
                        break;
                    case "Gift":
                        int index = int.Parse(command[1]);
                        int houseNumber = int.Parse(command[2]);
                        if (index<0 || index>=houses.Count)
                        {
                            break;
                        }
                        houses.Insert(index, houseNumber);
                        previousIndex = index;
                        break;
                    case "Swap":
                        int firstNumber = int.Parse(command[1]);
                        int secondNumber = int.Parse(command[2]);
                        if (!houses.Contains(firstNumber) || !houses.Contains(secondNumber))
                        {
                            break;
                        }
                        else
                        {
                            int indexFirst = houses.IndexOf(firstNumber);
                            int secondIndex = houses.IndexOf(secondNumber);
                            int temp = firstNumber;
                            houses.RemoveAt(indexFirst);
                            houses.Insert(indexFirst, secondNumber);
                            houses.RemoveAt(secondIndex);
                            houses.Insert(secondIndex, temp);
                           
                        }
                        break;
                    default:
                        break;
                }
                numberOfCommands--;
            }
            Console.WriteLine($"Position: {previousIndex}");
            Console.WriteLine(string.Join(", ", houses));
        }
    }
}
