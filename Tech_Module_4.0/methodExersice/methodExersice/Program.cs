using System;
using System.Linq;
using System.Text;

namespace methodExersice
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] initialArray = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            string[] command = Console.ReadLine()
                .Split()
                .ToArray();

            while (command[0] != "end")
            {
                switch (command[0])
                {
                    case "exchange":
                        int exchangeIndex = int.Parse(command[1])+1;
                        if (exchangeIndex < 0 || exchangeIndex > initialArray.Length)
                        {                             
                            Console.WriteLine("Invalid index");
                            break;
                        }
                        ExchangeIndexes(initialArray, exchangeIndex);
                        break;
                    case "max":
                        if (command[1] == "even")
                        {
                            Console.WriteLine(MaxEvenElement(initialArray));
                        }
                        else if (command[1] == "odd")
                        {
                            Console.WriteLine(MaxOddElement(initialArray));
                        }
                        break;
                    case "min":
                        if (command[1] == "even")
                        {
                            Console.WriteLine(MinEvenElement(initialArray));
                        }
                        else if (command[1] == "odd")
                        {
                            Console.WriteLine(MinOddElement(initialArray));
                        }
                        break;
                    case "first":
                        if (command[2]=="even")
                        {
                            Console.WriteLine(FirstEvenElements(initialArray,int.Parse(command[1])));
                        }
                        else if(command[2]=="odd")
                        {
                            Console.WriteLine(FirstOddnElements(initialArray,int.Parse(command[1])));
                        }
                        break;
                    case "last":
                        if (command[2]=="even")
                        {
                            Console.WriteLine(LastEvenElements(initialArray,int.Parse(command[1])));
                        }
                        else if(command[2]=="odd")
                        {
                            Console.WriteLine(LastOddElements(initialArray,int.Parse(command[1])));
                        }
                        break;
                    default:
                        break;
                }

                command = Console.ReadLine()
                    .Split()
                    .ToArray();
            }
            Console.WriteLine($"[{string.Join(", ", initialArray)}]");
        }

        static string ExchangeIndexes(int[] input, int exchange)
        {
            int indexTobeExchanged = exchange;

            string result = string.Empty;
                        
            for (int i = 1; i <= indexTobeExchanged; i++)
            {
                int currentDigit = input[0];

                for (int j = 0; j < input.Length - 1; j++)
                {
                    input[j] = input[j + 1];
                }

                input[input.Length - 1] = currentDigit;
            }
           string.Join(" ", input);
            return result;
        }

        static string MaxOddElement(int[] input)
        {
            int maxOdd = -1;
            int maxOddValue = int.MinValue;

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] % 2 != 0)
                {
                    if (input[i] >= maxOddValue)
                    {
                        maxOddValue = input[i];
                        maxOdd = i;
                    }
                }
            }

            if (maxOdd !=-1)
            {
                return maxOdd.ToString();
            }
            else
            {
                string result= "No matches";
                return result;                
            }
           
        }

        static string MaxEvenElement(int[] input)
        {
            int maxEven = -1;
            int maxEvenValue = int.MinValue;

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] % 2 == 0)
                {
                    if (input[i] >= maxEvenValue)
                    {
                        maxEvenValue = input[i];
                        maxEven = i;
                    }
                }
            }
            if (maxEven != -1)
            {
                return maxEven.ToString();
            }
            else
            {
                string result = "No matches";
                return result;
            }
        }

        static string MinOddElement(int[] input)
        {
            int minOdd = -1;
            int minOddValue = int.MaxValue;

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] % 2 != 0)
                {
                    if (input[i] <= minOddValue)
                    {
                        minOddValue = input[i];
                        minOdd = i;
                    }
                }
            }
            if (minOdd != -1)
            {
                return minOdd.ToString();

            }
            else
            {
                string result = "No matches";
                return result;
            }
        }

        static string MinEvenElement(int[] input)
        {
            int minEven = -1;
            int minEvenValue = int.MaxValue;

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] % 2 == 0)
                {
                    if (input[i] <= minEvenValue)
                    {
                        minEvenValue = input[i];
                        minEven = i;
                    }
                }
            }
            if (minEven != -1)
            {
                return minEven.ToString();
            }
            else
            {
                string result = "No matches";
                return result;
            }
            
        }

        static string FirstEvenElements(int[] array, int count)
        {
            string result = string.Empty;

            if (count < 0 || count > array.Length)
            {
              return result = "Invalid count";
            }
            else
            {
                string[] resultArray = new string[count];

                for (int i = 0; i < resultArray.Length; i++)
                {
                    for (int j = i; j < array.Length; j++)
                    {
                        if (array[j] % 2 == 0)
                        {
                            resultArray[i] = array[j].ToString();
                            count--;

                            break;
                        }
                    }
                    if (count <= 0)
                    {
                        break;
                    }
                }

                foreach (var item in resultArray)
                {
                    result += item + ", ";
                }

            }
            char[] trimEnd = { ',', ' ' };
            return $"[{result.TrimEnd(trimEnd).TrimStart(trimEnd)}]";
        }

        static string FirstOddnElements(int[] array, int count)
        {
            string result = string.Empty;

            if (count < 0 || count > array.Length)
            {
                return result = "Invalid count";
            }
            else
            {
                string[] resultArray = new string[count];

                for (int i = 0; i < resultArray.Length; i++)
                {
                    for (int j = i; j < array.Length; j++)
                    {
                        if (array[j] % 2 != 0)
                        {
                            resultArray[i] = array[j].ToString();
                            count--;

                            break;
                        }
                    }
                    if (count <= 0)
                    {
                        break;
                    }
                }
                
                foreach (var item in resultArray)
                {
                    result+=item+", ";
                }
                
            }
            char[] trimEnd = { ',', ' ' };

            return $"[{result.TrimEnd(trimEnd).TrimStart(trimEnd)}]";
        }

        static string LastEvenElements(int [] array, int count)
        {
            string result = string.Empty;

            if (count<0 || count>array.Length)
            {
                result = "Invalid count";
            }
            else
            {
                string[] inputArray = new string[count];

                for (int i = inputArray.Length-1; i >=0; i--)
                {
                    for (int j = i; j >= 0; j--)
                    {
                        if (array[j] % 2 == 0)
                        {
                            inputArray[i]= array[j].ToString();
                            count--;
                        }
                        if (count <= 0)
                        {
                            break;
                        }
                    }
                }
                
                foreach (var item in inputArray.Reverse())
                {
                    result += item + ", ";
                }
            }
            char[] trimEnd = { ',', ' ' };

            return $"[{result.TrimEnd(trimEnd).TrimStart(trimEnd)}]";
        }
        static string LastOddElements(int[] array, int count)
        {
            string result = string.Empty;

            if (count < 0 || count > array.Length)
            {
                result = "Invalid count";
            }
            else
            {
                string[] inputArray = new string[count];

                for (int i = inputArray.Length - 1; i >= 0; i--)
                {
                    for (int j = i; j >= 0; j--)
                    {
                        if (array[i] % 2 != 0)
                        {
                            inputArray[j] = array[j].ToString();
                            count--;
                        }
                        if (count <= 0)
                        {
                            break;
                        }
                    }
                }

              
                foreach (var item in inputArray.Reverse())
                {
                    result += item + ", ";
                }
            }
            char[] trimEnd = { ',', ' ' };
            return $"[{result.TrimEnd(trimEnd).TrimStart(trimEnd)}]";

        }
    }
}
