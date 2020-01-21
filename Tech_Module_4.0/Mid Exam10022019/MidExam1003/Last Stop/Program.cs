using System;
using System.Collections.Generic;
using System.Linq;

namespace Last_Stop
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> paintings = Console.ReadLine()
                 .Split()
                 .Select(int.Parse)
                 .ToList();

            string command = Console.ReadLine();

            while (command != "END")
            {
                string[] tokens = command.
                    Split()
                    .ToArray();
                string action = tokens[0];

                switch (action)
                {
                    case "Change":
                        int number = int.Parse(tokens[1]);
                        int changedNumber = int.Parse(tokens[2]);
                       
                        if (paintings.Contains(number))
                        {
                            int index = paintings.IndexOf(number);
                            paintings.RemoveAt(index);
                            paintings.Insert(index, changedNumber);
                        }                      
                        break;
                    case "Hide":
                       number = int.Parse(tokens[1]);
                                               
                        if (paintings.Contains(number))
                        {
                           int index = paintings.IndexOf(number);
                            paintings.RemoveAt(index);
                        }
                        break;
                    case "Switch":
                        int paintingOne = int.Parse(tokens[1]);
                        int paintingTwo = int.Parse(tokens[2]);

                        if (paintings.Contains(paintingOne)&&paintings.Contains(paintingTwo))
                        {
                            int firstIndex = paintings.IndexOf(paintingOne);
                            int secondIndex = paintings.IndexOf(paintingTwo);
                            int temp = paintings[firstIndex];
                            paintings.RemoveAt(firstIndex);
                            paintings.Insert(firstIndex, paintingTwo);
                            paintings.RemoveAt(secondIndex);
                            paintings.Insert(secondIndex, temp);
                        }
                        break;
                    case "Insert":
                        int place = int.Parse(tokens[1]);
                        int paintingNumber = int.Parse(tokens[2]);
                        if (place>=0&& place<=paintings.Count-1)
                        {
                            if (place==paintings.Count-1)
                            {
                                paintings.Add(paintingNumber);
                            }
                            else
                            {
                                paintings.Insert(place + 1, paintingNumber);
                            }
                        }
                        break;
                    case "Reverse":
                        paintings.Reverse();
                        break;
                    default:
                        break;
                }
                command = Console.ReadLine();
            }
            Console.WriteLine(string.Join(" ",paintings));
        }
    }
}
