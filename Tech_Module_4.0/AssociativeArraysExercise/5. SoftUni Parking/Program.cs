using System;
using System.Linq;
using System.Collections.Generic;

namespace _5._SoftUni_Parking
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> users = new Dictionary<string, string>();

            int numberOfCommands = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfCommands; i++)
            {
                string[] command = Console.ReadLine().Split().ToArray();
                string action = command[0];
                string userName = command[1];

                switch (action)
                {
                    case "register":
                        string plateNumber = command[2];
                        if (!users.ContainsKey(userName))
                        {
                            users.Add(userName, plateNumber);
                            Console.WriteLine($"{userName} registered {plateNumber} successfully");
                        }
                        else
                        {
                            Console.WriteLine($"ERROR: already registered with plate number {users[userName]}");
                        }
                        break;
                    case "unregister":
                        if (!users.ContainsKey(userName))
                        {
                            Console.WriteLine($"ERROR: user {userName} not found");
                        }
                        else
                        {
                            Console.WriteLine($"{userName} unregistered successfully");
                            users.Remove(userName);
                        }
                        break;
                    default:
                        break;
                }
            }

            foreach (var user in users)
            {
                Console.WriteLine($"{user.Key} => {user.Value}");
            }
        }
    }
}
