using System;

namespace methodMoreExersice
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string secondLine = Console.ReadLine();

            switch (input)
            {
                case "int":
                    int number = int.Parse(secondLine);
                    PrintInt(number);
                    break;
                case "real":
                    double doubleNumber = double.Parse(secondLine);
                    PrintReal(doubleNumber);
                    break;
                case "string":
                    PrintString(secondLine);
                    break;
                default:
                    break;
            }
        }

        private static void PrintString(string input)
        {
            Console.WriteLine("$"+input+"$");
        }

        private static void PrintReal(double doubleNumber)
        {
            doubleNumber *= 1.5;
            Console.WriteLine($"{doubleNumber:f2}");
        }

        private static void PrintInt(int number)
        {
            number *= 2;
            Console.WriteLine(number);
        }
    }
}
