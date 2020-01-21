using System;
using System.Collections.Generic;
using System.Linq;
using MilitaryElite.Classes;
using MilitaryElite.Interfaces;

namespace MilitaryElite
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            
            string command = Console.ReadLine();
            List<Private> allPrivates = new List<Private>();

            while (command != "End")
            {
                string[] tokens = command.Split();
                string typeOfSoldier = tokens[0];
                int id = int.Parse(tokens[1]);
                string firstName = tokens[2];
                string lastName = tokens[3];

                switch (typeOfSoldier)
                {
                    case "Private":
                        decimal salary = decimal.Parse(tokens[4]);

                        CreatePrivate(allPrivates, id, firstName, lastName, salary);

                        break;

                    case "LieutenantGeneral":
                        salary = decimal.Parse(tokens[4]);

                        CreateLeutenantGeneral(allPrivates, tokens, id, firstName, lastName, salary);

                        break;

                    case "Engineer":
                        salary = decimal.Parse(tokens[4]);
                        string corp = tokens[5];

                        CreateEngeneer(tokens, id, firstName, lastName, salary, corp);

                        break;

                    case "Commando":
                        salary = decimal.Parse(tokens[4]);
                        corp = tokens[5];

                        CreateCommando(tokens, id, firstName, lastName, salary, corp);

                        break;
                    case "Spy":
                        int codeNumber = int.Parse(tokens[4]);

                        CreateSpy(id, firstName, lastName, codeNumber);

                        break;
                    default:
                        break;
                }

                command = Console.ReadLine();
            }
        }

        private static void CreateSpy(int id, string firstName, string lastName, int codeNumber)
        {
            Spy spy = new Spy(id, firstName, lastName, codeNumber);

            Console.WriteLine(spy.ToString());
        }

        private static void CreateCommando(string[] tokens, int id, string firstName, string lastName, decimal salary, string corp)
        {
            if (IsValidCorp(corp))
            {
                List<IMission> missions = new List<IMission>();
                for (int i = 6; i < tokens.Length; i+=2)
                {

                    string missionName = tokens[i];
                    string missionState = tokens[i + 1];

                    if (IsValidMission(missionState))
                    {
                        Mission mission = new Mission(missionName, missionState);
                        missions.Add(mission);
                    }

                }
                Commando commando = new Commando(id, firstName, lastName, salary, corp, missions);
                Console.WriteLine(commando.ToString());
            }
        }

        private static void CreateEngeneer(string[] tokens, int id, string firstName, string lastName, decimal salary, string corp)
        {
            List<IRepair> repairs = new List<IRepair>();

            if (IsValidCorp(corp))
            {
                for (int i = 6; i < tokens.Length; i += 2)
                {
                    string repairPart = tokens[i];
                    int repairHours = int.Parse(tokens[i + 1]);

                    Repair repair = new Repair(repairPart, repairHours);
                    repairs.Add(repair);

                }
                Engineer engineer = new Engineer(id, firstName, lastName, salary, corp, repairs);
                Console.WriteLine(engineer.ToString());
            }
        }

        private static void CreateLeutenantGeneral(List<Private> allPrivates, string[] tokens, int id, string firstName, string lastName, decimal salary)
        {
            List<IPrivate> currentLeutenantPrivatesLIst = new List<IPrivate>();

            for (int i = 5; i < tokens.Length; i++)
            {
                int currentId = int.Parse(tokens[i]);
                Private currentPrivate = allPrivates.FirstOrDefault(p => p.ID == currentId);
                currentLeutenantPrivatesLIst.Add(currentPrivate);
            }
            LieutenantGeneral lieutenantGeneral = new LieutenantGeneral(id, firstName, lastName, salary, currentLeutenantPrivatesLIst);

            Console.WriteLine(lieutenantGeneral.ToString());
        }

        private static void CreatePrivate(List<Private> allPrivates, int id, string firstName, string lastName, decimal salary)
        {
            Private privateSoldier = new Private(id, firstName, lastName, salary);
            Console.WriteLine(privateSoldier.ToString());

            allPrivates.Add(privateSoldier);
        }

        private static bool IsValidMission(string missionState)
        {
            if (missionState== "inProgress" || missionState== "Finished")
            {
                return true;
            }
            return false;
        }

        private static bool IsValidCorp(string corp)
        {
            if (corp== "Airforces" || corp== "Marines")
            {
                return true;
            }
            return false;
        }
    }
}
