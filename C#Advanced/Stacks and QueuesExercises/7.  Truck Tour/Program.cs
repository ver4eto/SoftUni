using System;
using System.Collections.Generic;
using System.Linq;

namespace _7.__Truck_Tour
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] data = new int[2];

            int fuelAccumulated = 0;
            bool isCahnged = false;
            Queue<int> amount = new Queue<int>();
            Queue<int> distance = new Queue<int>();
            int indexOfLastChange = 0;
            int[] indexAmount = new int[n];
            int[] indexDIst = new int[n];
                

            for (int i = 0; i < n; i++)
            {
                data = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();
                int currAmount = data[0];
                amount.Enqueue(currAmount);
                
                int currDistance = data[1];
                distance.Enqueue(currDistance);
                indexAmount[i]=currAmount;
                indexDIst[i]=currDistance;
            }

            for (int i = 0; i < distance.Count; i++)
            {
                int currAmount = amount.Dequeue();
                fuelAccumulated += currAmount;
                int currDistance = distance.Dequeue();
                amount.Enqueue(currAmount);
                distance.Enqueue(currDistance);
                if (currDistance<fuelAccumulated)
                {
                    fuelAccumulated -= currDistance;
                }
                else
                {
                    isCahnged = true;
                    i = -1;
                    fuelAccumulated -= currAmount;
                }              
               
            }

            int index = 0;


            for (int i = 0; i < indexAmount.Count(); i++)
            {
                if (amount.Peek()==indexAmount[i]&&distance.Peek()==indexDIst[i])
                {
                    index = i;
                    break;
                }

            }
            Console.WriteLine(index);
            
        }
    }
}
