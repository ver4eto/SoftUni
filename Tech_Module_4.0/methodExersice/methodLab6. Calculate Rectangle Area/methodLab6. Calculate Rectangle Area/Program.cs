using System;
using System.Text;

namespace methodLab6._Calculate_Rectangle_Area
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstNumber = Console.ReadLine();
            string operators = Console.ReadLine();
            string secondNumber = Console.ReadLine();
            double result = 0d;
            
            switch (operators)
            {
                case "/":
                    result = DividedOperatorResult(firstNumber, secondNumber);
                    Console.WriteLine($"{result:f0}");
                    break;
                case "-":
                    result = SubstractOperatorResult(firstNumber, secondNumber);
                    Console.WriteLine($"{result:f0}");
                    break;
                case "+":
                    result = AddOperatorResult(firstNumber, secondNumber);
                    Console.WriteLine($"{result:f0}");
                    break;
                case "*":
                    result = MultiplyOperatorResult(firstNumber, secondNumber);
                    Console.WriteLine($"{result:f0}");
                    break;
                default:
                    break;
            }
        }

        static double DividedOperatorResult(string one, string two)
        {
            double result = double.Parse(one) / double.Parse(two);
            return result;
        }

        static double MultiplyOperatorResult(string one, string two)
        {
            double result = double.Parse(one) * double.Parse(two);
            return result;
        }

        static double AddOperatorResult(string one, string two)
        {
            double result = double.Parse(one) + double.Parse(two);
            return result;
        }

        static double SubstractOperatorResult(string one, string two)
        {
            double result = double.Parse(one) - double.Parse(two);
            return result;
        }
    }
}
