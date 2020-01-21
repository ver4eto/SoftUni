using System;
using System.Collections.Generic;
using System.Linq;
using FootballTeamGenerator.Models;
using FootballTeamGenerator.Exceptions;

namespace FootballTeamGenerator
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            List<Team> teams = new List<Team>();

            while (command != "END")
            {
                try
                {
                    string[] tokens = command.Split(";");

                    string action = tokens[0];
                    string teamName = tokens[1];

                   

                    if (action == "Team")
                    {
                        Team currentTeam = new Team(teamName);
                        teams.Add(currentTeam);
                    }
                    else if (action == "Add")
                    {
                        Team currentTeam = teams.FirstOrDefault(t => t.Name == teamName);

                        if (teams.Contains(currentTeam))
                        {
                            string player = tokens[2];
                            int endurance = int.Parse(tokens[3]);
                            int sprint = int.Parse(tokens[4]);
                            int dribble = int.Parse(tokens[5]);
                            int passing = int.Parse(tokens[6]);
                            int shooting = int.Parse(tokens[7]);

                            Stat currentStat = new Stat(endurance, sprint, dribble, passing, shooting);
                            Player newPlayer = new Player(player, currentStat);
                            if (teams.Contains(currentTeam))
                            {
                                currentTeam.AddPlayer(newPlayer);
                            }
                            //else if (!teams.Contains(currentTeam))
                            //{
                            //    teams.Add(currentTeam);
                            //    currentTeam.AddPlayer(newPlayer);
                            //}
                            else
                            {
                                throw new InvalidOperationException(string.Format(ExceptionMessages.MissingTeam, teamName));
                            }
                        }
                        else
                        {
                            throw new ArgumentException(string.Format(ExceptionMessages.MissingTeam, teamName));
                        }
                        
                    }
                    else if (action == "Remove")
                    {
                        string playerName = tokens[2];
                                                

                        Team teamForPlayerToRemove = teams.FirstOrDefault(t => t.Name == teamName);

                        if (teamForPlayerToRemove==null)
                        {
                            throw new InvalidOperationException(string.Format(ExceptionMessages.MissingTeam, teamName));
                        }
                        else
                        {
                        teamForPlayerToRemove.RemovePlayer(playerName);

                        }
                    }
                    else if (action == "Rating")
                    {
                        Team teamForRating = teams.FirstOrDefault(t => t.Name == teamName);

                        if (teamForRating != null)
                        {

                            Console.WriteLine($"{teamForRating.Name} - {teamForRating.Rating}");
                        }
                        else
                        {
                            throw new InvalidOperationException(string.Format(ExceptionMessages.MissingTeam, teamName));
                        }
                    }

                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine(ioe.Message);
                }


                command = Console.ReadLine();
            }


        }

       
    }
}
