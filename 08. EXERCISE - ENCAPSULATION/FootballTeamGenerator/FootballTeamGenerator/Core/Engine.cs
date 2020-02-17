using FootballTeamGenerator.Exceptions;
using FootballTeamGenerator.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FootballTeamGenerator.Core
{
    public class Engine
    {
        private readonly List<Team> teams;
        public Engine()
        {
            teams = new List<Team>();
        }

        public void Run()
        {
            var command = Console.ReadLine();

            while (command != "END")
            {
                try
                {
                    var commandsToken = command.Split(';').ToArray();

                    var cmdType = commandsToken[0];
                    var teamName = commandsToken[1];

                    if (cmdType == "Team")
                    {
                        AddTeam(teamName);
                    }
                    else if (cmdType == "Add")
                    {
                        AddPlayerToATeam(commandsToken, teamName);
                    }
                    else if (cmdType == "Remove")
                    {
                        RemovePlayerFromATeam(commandsToken, teamName);
                    }
                    else if (cmdType == "Rating")
                    {
                        RatingTeam(teamName);
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine(ex.Message);
                }

                command = Console.ReadLine();
            }
        }

        private void RatingTeam(string teamName)
        {
            ValidateTeamName(teamName);

            var team = teams.First(x => x.Name == teamName);

            Console.WriteLine(team.ToString());
        }

        private void RemovePlayerFromATeam(string[] commandsToken, string teamName)
        {
            ValidateTeamName(teamName);
            var playerName = commandsToken[2];

            var team = teams.First(x => x.Name == teamName);

            team.RemovePlayer(playerName);
        }

        private void AddPlayerToATeam(string[] commandsToken, string teamName)
        {
            ValidateTeamName(teamName);
            var playerName = commandsToken[2];

            var stat = CreateStat(commandsToken);

            var player = new Player(playerName, stat);
            var team = teams.First(x => x.Name == teamName);

            team.AddPlayer(player);
        }

        private void AddTeam(string teamName)
        {
            var team = new Team(teamName);

            teams.Add(team);
        }

        private static Stat CreateStat(string[] commandsToken)
        {
            var endurance = int.Parse(commandsToken[3]);
            var sprint = int.Parse(commandsToken[4]);
            var dribble = int.Parse(commandsToken[5]);
            var passing = int.Parse(commandsToken[6]);
            var shooting = int.Parse(commandsToken[7]);

            var stat = new Stat(endurance, sprint, dribble, passing, shooting);

            return stat;
        }

        private void ValidateTeamName(string name)
        {
            var team = teams.FirstOrDefault(x => x.Name == name);

            if(team==null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.MissingTeamException, name));
            }
        }
    }

}
