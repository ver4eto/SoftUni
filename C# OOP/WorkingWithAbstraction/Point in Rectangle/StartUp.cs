using System;
using System.Linq;

namespace Point_in_Rectangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] data= ParseInput();

            int topLeftX = data[0];
            int topLeftY = data[1];
            int bottomRightX = data[2];
            int bottomRightY = data[3];


            Point topLeft = new Point(topLeftX, topLeftY);
            Point bottomRight = new Point(bottomRightX, bottomRightY);

            int count = int.Parse(Console.ReadLine());

            Rectangle rectangle = new Rectangle(topLeft, bottomRight);

            for (int i = 0; i < count; i++)
            {
              int[] points=  ParseInput();

                Point pointToCheck = new Point(points[0],points[1]);

                Console.WriteLine(rectangle.Contains(pointToCheck));
            }


        }

        private static int[] ParseInput()
        {
           return Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
        }
    }
}
