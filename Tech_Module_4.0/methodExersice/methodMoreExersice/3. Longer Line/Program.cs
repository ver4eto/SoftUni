using System;

namespace _3._Longer_Line
{
    class Program
    {
        static void Main(string[] args)
        {
            double firstLineX1Coor = double.Parse(Console.ReadLine());
            double firstLineY1Coor = double.Parse(Console.ReadLine());
            double firstLineX2Coor = double.Parse(Console.ReadLine());
            double firstLineY2Coor = double.Parse(Console.ReadLine());
            double secondLineX1Coor = double.Parse(Console.ReadLine());
            double secondLineY1Coor = double.Parse(Console.ReadLine());
            double secondLineX2Coor = double.Parse(Console.ReadLine());
            double secondLineY2Coor = double.Parse(Console.ReadLine());

            double firstLineLenght = FirstLineLength(firstLineX1Coor, firstLineY1Coor, firstLineX2Coor, firstLineY2Coor);
            double secondLineLegth = SecondLineLength(secondLineX1Coor, secondLineY1Coor, secondLineX2Coor, secondLineY2Coor);

            if (firstLineLenght >= secondLineLegth)
            {
                FirstLineClosetsToCenterCoordinates(firstLineX1Coor, firstLineY1Coor, firstLineX2Coor, firstLineY2Coor);
            }
            else
            {
                SecondLineClosetsToCenterCoordinates(secondLineX1Coor, secondLineY1Coor, secondLineX2Coor, secondLineY2Coor);
            }
        }

        private static double FirstLineLength(double firstLineX1Coor, double firstLineY1Coor, double firstLineX2Coor, double firstLineY2Coor)
        {
            double length = Math.Abs(firstLineX1Coor) + Math.Abs(firstLineY1Coor)
                + Math.Abs(firstLineX2Coor) + Math.Abs(firstLineY2Coor);
            return length;
        }
        static void FirstLineClosetsToCenterCoordinates(double firstLineX1Coor, double firstLineY1Coor, double firstLineX2Coor, double firstLineY2Coor)
        {
            double firstSumOfCoors = Math.Abs(firstLineX1Coor) + Math.Abs(firstLineY1Coor);
            double secondSumOfCoors = Math.Abs(firstLineX2Coor) + Math.Abs(firstLineY2Coor);

            if (firstSumOfCoors<=secondSumOfCoors)
            {
                Console.WriteLine($"({firstLineX1Coor}, {firstLineY1Coor})({firstLineX2Coor}, {firstLineY2Coor})");
            }
            else
            {
                Console.WriteLine($"({firstLineX2Coor}, {firstLineY2Coor})({firstLineX1Coor}, {firstLineY1Coor})");
            }
        }

        static void SecondLineClosetsToCenterCoordinates(double firstLineX1Coor, double firstLineY1Coor, double firstLineX2Coor, double firstLineY2Coor)
        {
            double firstSumOfCoors = Math.Abs(firstLineX1Coor) + Math.Abs(firstLineY1Coor);
            double secondSumOfCoors = Math.Abs(firstLineX2Coor) + Math.Abs(firstLineY2Coor);

            if (firstSumOfCoors <= secondSumOfCoors)
            {
                Console.WriteLine($"({firstLineX1Coor}, {firstLineY1Coor})({firstLineX2Coor}, {firstLineY2Coor})");
            }
            else
            {
                Console.WriteLine($"({firstLineX2Coor}, {firstLineY2Coor})({firstLineX1Coor}, {firstLineY1Coor})");
            }
        }
        private static double SecondLineLength(double secondLineX1Coor, double secondLineY1Coor, double secondLineX2Coor, double secondLineY2Coor)
        {
            double length = Math.Abs(secondLineX1Coor) + Math.Abs(secondLineY1Coor)
                + Math.Abs(secondLineX2Coor) + Math.Abs(secondLineY2Coor);
            return length;
        }
    }
        
}
