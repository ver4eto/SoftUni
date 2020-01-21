using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1___SoftUni_Reception
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstEmployeeEfficiency = int.Parse(Console.ReadLine());
            int secondEmployeeEfficiency = int.Parse(Console.ReadLine());
            int thirdEmployeeEfficiency = int.Parse(Console.ReadLine());

            int studentsCount = int.Parse(Console.ReadLine());
           
            double restTime = 0;
            double studentsPerHourForAll = firstEmployeeEfficiency + secondEmployeeEfficiency + thirdEmployeeEfficiency;
            double timeNeeded = 0d;
          
            timeNeeded =Math.Ceiling( studentsCount / studentsPerHourForAll);
            int restCount = 0;
            if (timeNeeded>3)
            {
                restTime = timeNeeded;
                while (restTime>3)
                {
                    restTime -= 3;
                    restCount++;
                }
            }
            Console.WriteLine($"Time needed: { timeNeeded+restCount}h.");
        }
    }
}
