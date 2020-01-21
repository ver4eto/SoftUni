using System;

namespace methodLab5._Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            string typeOfProduct = Console.ReadLine().ToLower();
            int quantityOfProduct = int.Parse(Console.ReadLine());

            switch (typeOfProduct)
            {
                case "coffee":
                    CoffeeCalculation(quantityOfProduct);
                    break;
                case "water":
                    WaterCalculation(quantityOfProduct);
                    break;
                case "coke":
                    CokeCalculation(quantityOfProduct);
                    break;
                case "snacks":
                    SnacksCalculation(quantityOfProduct);
                    break;
                default:
                    break;
            }

        }
        static void CoffeeCalculation( int quantity)
        {
            double priceOf1piece = 1.50;
            double totalPrice = priceOf1piece * quantity;
            Console.WriteLine($"{totalPrice:f2}");
        }

        static void WaterCalculation( int quantity)
        {
            double priceOf1Piece = 1.00;
            double totalPrice = priceOf1Piece * quantity;
            Console.WriteLine($"{totalPrice:f2}");
        }

        static void CokeCalculation( int quantity)
        {
            double priceOf1Piece = 1.40;
            double totalPrice = priceOf1Piece * quantity;
            Console.WriteLine($"{totalPrice:f2}");
        }

        static void SnacksCalculation(int quantity)
        {
            double priceOf1Piece = 2.00;
            double totalPrice = priceOf1Piece * quantity;
            Console.WriteLine($"{totalPrice:f2}");
        }
    }
}
