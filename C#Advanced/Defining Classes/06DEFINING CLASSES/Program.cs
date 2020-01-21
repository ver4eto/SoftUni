using System;

namespace _06DEFINING_CLASSES
{
        class Program
        {

            static void Main()
            {
                Car myCar = new Car(10);
                myCar.Make = "Renault";
                myCar.Model = "Megane";

            myCar.Drive(76);
            Console.WriteLine(myCar.Fuel);

            }
        }   
}
