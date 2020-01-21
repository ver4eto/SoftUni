using System;
using System.Linq;

namespace _11._Array_Manipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arrayForManipulation = Console.ReadLine()
                 .Split()
                 .Select(int.Parse)
                 .ToArray();

            string[] command = Console.ReadLine().Split().ToArray();


            while (command[0] != "end")
            {
                if (command[0] == "exchange")
                {
                    int indexForChange = int.Parse(command[1]);
                    if (indexForChange < 0 || indexForChange >= arrayForManipulation.Length )
                    {
                        Console.WriteLine("Invalid index");
                        command = Console.ReadLine().Split().ToArray();
                        continue;
                    }
                    ExchangeIndex(indexForChange, arrayForManipulation);
                }

                else if (command[0] == "max")
                {
                    string evenOrOdd = command[1];
                    string maxOrMin = command[0];
                    if (PrintMaxIndex(evenOrOdd, arrayForManipulation) < 0)
                    {
                        Console.WriteLine("No matches");
                        command = Console.ReadLine().Split().ToArray();
                        continue;
                    }
                    else
                    {
                        Console.WriteLine(PrintMaxIndex(evenOrOdd, arrayForManipulation));
                    }

                }

                else if (command[0] == "min")
                {
                    string evenOrOdd = command[1];
                    string maxOrMin = command[0];
                    if (PrintMinIndex(evenOrOdd, arrayForManipulation) < 0)
                    {
                        Console.WriteLine("No matches");
                        command = Console.ReadLine().Split().ToArray();
                        continue;
                    }
                    else
                    {
                        Console.WriteLine(PrintMinIndex(evenOrOdd, arrayForManipulation));
                    }

                }
                else if (command[0]=="first")
                {
                    int count = int.Parse(command[1]);

                    if (count > arrayForManipulation.Length)
                    {
                        Console.WriteLine("Invalid count");
                        command = Console.ReadLine().Split().ToArray();
                        continue;
                    }

                    string evenOrOdd = command[2];
                    int[] result = new int[count];

                    
                    if (evenOrOdd=="even")
                    {
                      result=FirstEvenOrOddIndex(count,0,arrayForManipulation);
                    }
                    else
                    {
                       result= FirstEvenOrOddIndex(count, 1, arrayForManipulation);
                    }
                    Console.WriteLine($"[{string.Join(", ", result)}]");
                }
                else if (command[0]=="last")
                {
                    int count = int.Parse(command[1]);
                    if (count > arrayForManipulation.Length)
                    {
                        Console.WriteLine("Invalid count");
                        command = Console.ReadLine().Split().ToArray();
                        continue;
                    }

                    string evenOrOdd = command[2];
                    int[] result = new int[count];

                   
                    if (evenOrOdd == "even")
                    {
                        result = LastEvenOrOddIndex(count, 0, arrayForManipulation);
                    }
                    else
                    {
                        result = LastEvenOrOddIndex(count, 1, arrayForManipulation);
                    }
                    Console.WriteLine($"[{string.Join(", ", result)}]");
                }
                command = Console.ReadLine().Split().ToArray();
            }
            Console.WriteLine($"[{string.Join(", ",arrayForManipulation)}]");
        }

        private static int[] LastEvenOrOddIndex(int count, int divisionResult, int[] arrayForManipulation)
        {
            int[] arrayCopy = new int[count];
            int currentCount = 0;

            for (int i = arrayForManipulation.Length-1; i >= 0; i--)
            {
                if (arrayForManipulation[i] % 2 == divisionResult && currentCount < count)
                {
                    arrayCopy[currentCount] = arrayForManipulation[i];
                    currentCount++;
                }
            }
            if (currentCount >= count)
            {
                return arrayCopy.Reverse().ToArray();
            }
            else
            {
                int[] temp = new int[currentCount];
                Array.Copy(arrayCopy, temp, currentCount);
                return temp.Reverse().ToArray();
            }
        }

        private static int[] FirstEvenOrOddIndex(int count, int divisionResult, int[] arrayForManipulation)
        {
            int[] arrayCopy = new int[count];
            int currentCount = 0;

            for (int i = 0; i < arrayForManipulation.Length; i++)
            {
                if (arrayForManipulation[i]%2==divisionResult && currentCount<count)
                {
                    arrayCopy[currentCount] = arrayForManipulation[i];
                    currentCount++;
                }               
            }
            if (currentCount >= count)
            {
                return arrayCopy;
            }
            else
            {
                int[] temp = new int[currentCount];
                Array.Copy(arrayCopy, temp, currentCount);
                return temp;
            }
        }

        private static int[] ExchangeIndex(int index, int[] array)
        {

            for (int i = 0; i <= index; i++)
            {
                int currentNumber = array[0];

                for (int j = 0; j < array.Length - 1; j++)
                {
                    array[j] = array[j + 1];
                }
                array[array.Length - 1] = currentNumber;
            }
            
            return array;

        }

        private static int PrintMaxIndex(string evenOrOdd, int[] array)
        {
            bool isEven = false;

            if (evenOrOdd == "even")
            {
                isEven = true;
            }
            int index = -1;


            int maxValue = int.MinValue;

            for (int i = 0; i < array.Length; i++)
            {

                if (array[i] % 2 == 0 && array[i] >= maxValue && isEven)
                {
                    maxValue = array[i];
                    index = i;
                }
                else if (array[i] % 2 != 0 && array[i] >= maxValue && !isEven)
                {
                    maxValue = array[i];
                    index = i;
                }
            }

            return index;
        }

        private static int PrintMinIndex(string evenOrOdd, int[] array)
        {
            bool isEven = false;
            if (evenOrOdd == "even")
            {
                isEven = true;
                    
            }
            int index = -1;
            int minValue = int.MaxValue;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] % 2 == 0 && array[i] <= minValue && isEven)
                {
                    minValue = array[i];
                    index = i;
                }
                else if (array[i] % 2 != 0 && array[i] <= minValue && !isEven)
                {
                    minValue = array[i];
                    index = i;
                }

            }
            return index;
        }

    }
}

    
