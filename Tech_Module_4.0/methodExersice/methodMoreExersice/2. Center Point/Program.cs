using System;

namespace _2._Center_Point
{
    class Program
    {
        static void Main(string[] args)
        {
            double x1Coordinate = double.Parse(Console.ReadLine());
            double y1Coordinate = double.Parse(Console.ReadLine());
            double x2Coordinated = double.Parse(Console.ReadLine());
            double y2Coordinate = double.Parse(Console.ReadLine());

          ClosestPointToTheCenter(x1Coordinate, y1Coordinate, x2Coordinated, y2Coordinate);  
        }

        static void ClosestPointToTheCenter(double one, double two, double three, double four)
        {
            double firstSum = Math.Abs(one) + Math.Abs(two);
            double secondSum = Math.Abs(three) + Math.Abs(four);

            
            if (firstSum<=secondSum)
            {
                Console.WriteLine($"({one}, {two})");
            }

            else if (secondSum<firstSum)
            {
                Console.WriteLine($"({three}, {four})");
            }
            
        }
    }
}
