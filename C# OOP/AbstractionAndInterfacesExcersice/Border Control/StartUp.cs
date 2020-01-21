using System;
using System.Collections.Generic;
using System.Linq;

namespace BorderControl
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int numberOfNames = int.Parse(Console.ReadLine());

            List<IBuyer> buyers = new List<IBuyer>();

            for (int i = 0; i < numberOfNames; i++)
            {
                string[] input = Console.ReadLine().Split();
                string name = input[0];
                string age = input[1];

                if (input.Length==3)
                {
                    
                    string group = input[2];

                    Rebel rebel = new Rebel(name,age,group);
                    buyers.Add(rebel);
                }
                else if(input.Length==4)
                {
                    string id = input[2];
                    string birthDay = input[3];

                    Citizen citizen = new Citizen(name, age, id, birthDay);
                    buyers.Add(citizen);
                }
            }

            string command = Console.ReadLine();

            while ( command != "End")
            {
                IBuyer buyer = buyers.FirstOrDefault(b => b.Name == command);

                if (buyer != null)
                {
                    buyer.BuyFood();
                }
                command = Console.ReadLine();
            }

            int sum = buyers.Sum(b => b.Food);
            Console.WriteLine(sum);
        }
    }
}
