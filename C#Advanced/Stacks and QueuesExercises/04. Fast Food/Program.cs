using System;
using System.Linq;
using System.Collections.Generic;


namespace _04._Fast_Food
{
    class Program
    {
        static void Main(string[] args)
        {
            int foodQuantity = int.Parse(Console.ReadLine());

            int[] inputOrders = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Queue<int> orders = new Queue<int>(inputOrders);

            Console.WriteLine($"{orders.Max()}");
            while (foodQuantity>=0 || orders.Count==0)
            {
                if (foodQuantity>=orders.Peek())
                {
                    int currentOrder = orders.Peek();
                    orders.Dequeue();
                    foodQuantity -= currentOrder;
                    if (foodQuantity == 0)
                    {
                        if (orders.Count == 0)
                        {
                            Console.WriteLine("Orders complete");
                            break;
                        }
                    }
                    if (orders.Count==0)
                    {
                        if (foodQuantity>=0)
                        {
                            Console.WriteLine("Orders complete");
                            break;
                        }
                    }
                }
                else if(foodQuantity<orders.Peek())
                {                    
                        Console.WriteLine($"Orders left: { string.Join(" ", orders)}");
                        break;
                    
                }
                             
            }
        }
    }
}
