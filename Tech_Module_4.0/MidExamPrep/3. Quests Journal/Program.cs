using System;
using System.Collections.Generic;
using System.Linq;

namespace _3._Quests_Journal
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] separators = { ", "," - ",":" };
            List<string> questList = Console.ReadLine()
                .Split(separators,StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string command = Console.ReadLine();


            while (command!= "Retire!")
            {
                string[] action = command.Split(separators,StringSplitOptions.None).ToArray();
                string typeOfCommand = action[0];
                string quest = action[1];
                switch (typeOfCommand)
                {
                    case "Start":
                        if (!questList.Contains(quest))
                        {
                            questList.Add(quest);
                        }
                        break;
                    case "Complete":
                        if (questList.Contains(quest))
                        {
                            questList.Remove(quest);
                        }
                        break;
                    case "Side Quest":
                        string sideQuest = action[2];
                        if (questList.Contains(quest) && !questList.Contains(sideQuest))
                        {
                            int positionOfQuest = questList.IndexOf(quest);
                            questList.Insert(positionOfQuest + 1, sideQuest);
                        }
                        break;
                    case "Renew":
                        if (questList.Contains(quest))
                        {
                            questList.Remove(quest);
                            questList.Add(quest);
                        }
                        break;
                    default:
                        break;
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(string.Join(", ",questList));
        }
    }
}
