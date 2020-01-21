using System;
using System.Linq;

namespace _2._Dungeonest_Dark
{
    class Program
    {
        static void Main(string[] args)
        {
            int initialHealth = 100;
            int initialCoins = 0;
            int currentHealth = initialHealth;

            string inpput = Console.ReadLine();
            

            string[] rooms = inpput
                .Split('|')
                .ToArray();

            for (int i = 0; i < rooms.Length; i++)
            {
                string[] currentRoom = rooms[i].Split().ToArray();

                string typeOfRoom = currentRoom[0];
                int number = int.Parse(currentRoom[1]);

                switch (typeOfRoom)
                {
                    case "potion":
                        if (number+currentHealth>100)
                        {
                            int diff = 100 - currentHealth ;
                            number = diff;
                        }
                        currentHealth += number;
                        Console.WriteLine($"You healed for {number} hp." );
                        Console.WriteLine($"Current health: {currentHealth} hp.");
                        break;
                    case "chest":
                        initialCoins += number;
                        Console.WriteLine($"You found {number} coins.");
                        break;

                    default:
                        currentHealth -= number;
                        if (currentHealth>0)
                        {
                            Console.WriteLine($"You slayed {typeOfRoom}.");
                        }
                        else
                        {

                            Console.WriteLine($"You died! Killed by {typeOfRoom}.");
                            Console.WriteLine($"Best room: {i+1}");
                            break;
                        }
                        break;
                }
                if (currentHealth<=0)
                {
                    break;
                }

            }
            if (currentHealth>0)
            {
                Console.WriteLine("You've made it!");
                Console.WriteLine($"Coins: {initialCoins}");
                Console.WriteLine($"Health: {currentHealth}"); 
            }
           
        }
    }
}
