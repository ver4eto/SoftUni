using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2___Grains_of_Sand
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> grainsOfSands = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            string command = Console.ReadLine();
            while (command != "Mort")
            {
                string[] tokens = command.Split().ToArray();
                string action = tokens[0];
                int value = int.Parse(tokens[1]);

                switch (action)
                {
                    case "Add":
                        grainsOfSands.Add(value);
                        break;
                    case "Remove":
                        if (grainsOfSands.Contains(value))
                        {
                            grainsOfSands.Remove(value);
                        }
                        else
                        {
                            int index = value;
                            if (index>=0&& index<=grainsOfSands.Count-1)
                            {
                                grainsOfSands.RemoveAt(value);
                            }
                        }
                        break;
                    case "Replace":
                        int replacementValue = int.Parse(tokens[2]);
                       int valueIndex= grainsOfSands.IndexOf(value);
                        if (valueIndex>=0&&valueIndex<=grainsOfSands.Count-1)
                        {
                            grainsOfSands.RemoveAt(valueIndex);
                            grainsOfSands.Insert(valueIndex, replacementValue);
                        }
                        break;
                    case "Increase":
                        int valueToBeAdded = 0;
                        for (int i = 0; i < grainsOfSands.Count; i++)
                        {
                            if (grainsOfSands[i]>=value)
                            {
                                valueToBeAdded = grainsOfSands[i];
                                break;
                            }
                            if (i==grainsOfSands.Count-1)
                            {
                                valueToBeAdded = grainsOfSands[i];
                            }
                        }
                        for (int i = 0; i < grainsOfSands.Count; i++)
                        {
                            grainsOfSands[i] += valueToBeAdded;
                        }
                        break;
                    case "Collapse":
                        var newGrains = grainsOfSands.RemoveAll(x => x < value);
                        //foreach (var item in grainsOfSands)
                        //{
                        //    Console.WriteLine(item);
                        //}
                        break;
                    default:
                        break;
                }
                command = Console.ReadLine();
            }
            Console.WriteLine(string.Join(" ",grainsOfSands));
        }
    }
}
