using PlayersAndMonsters.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlayersAndMonsters.Core
{
    public class Engine : IEngine
    {
        private ManagerController manager;
        public Engine()
        {
            this.manager = new ManagerController();
        }
        public void Run()
        {
            string input = Console.ReadLine();

            while (input != "Exit")
            {
                string[] commands = input.Split().ToArray();
                string action = commands[0];
                try
                {
                    switch (action)
                    {
                        case "AddPlayer":
                            string playerType = commands[1];
                            string playerUsername = commands[2];

                            Console.WriteLine(manager.AddPlayer(playerType, playerUsername));
                            break;

                        case "AddCard":
                            string type = commands[1];
                            string name = commands[2];

                            Console.WriteLine(manager.AddCard(type, name));
                            break;

                        case "AddPlayerCard":
                            string userName = commands[1];
                            string cardName = commands[2];

                            Console.WriteLine(manager.AddPlayerCard(userName, cardName));

                            break;

                        case "Fight":
                            string attacker = commands[1];
                            string enemy = commands[2];

                            Console.WriteLine(manager.Fight(attacker, enemy));

                            break;

                        case "Report":
                            Console.WriteLine(manager.Report());
                            break;

                        default:
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
               


                input = Console.ReadLine();
            }
        }
    }
}
