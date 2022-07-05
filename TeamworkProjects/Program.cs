using System;
using System.Collections.Generic;
using System.Linq;

namespace TeamworkProjects
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Team> teams = new List<Team>();

            for (int i = 0; i < n; i++)
            {
                string[] userAndTeam = Console.ReadLine().Split('-');
                string user = userAndTeam[0];
                string teamName = userAndTeam[1];

                Team team = new Team()
                {
                    Name = teamName,
                    Creator = user,
                    Members = new List<string>()
                };

                bool teamExists = false;
                bool creatorExists = false;
                foreach (var currTeam in teams)
                {
                    if (currTeam.Name == teamName)
                    {
                        teamExists = true;
                    }

                    if (currTeam.Creator == user)
                    {
                        creatorExists = true;
                    }
                }

                if (creatorExists || teamExists)
                {
                    if (teamExists)
                    {
                        Console.WriteLine($"Team {teamName} was already created!");
                    }
                    else
                    {
                        Console.WriteLine($"{user} cannot create another team!");
                    }
                }
                else
                {
                    teams.Add(team);
                    Console.WriteLine($"Team {teamName} has been created by {user}!");
                }
            }

            string command;
            while ((command = Console.ReadLine()) != "end of assignment")
            {
                string[] newMembers = command.Split("->");
                string user = newMembers[0];
                string teamName = newMembers[1];

                bool teamExists = false;
                bool memberExists = false;
                foreach (var currTeam in teams)
                {
                    if (currTeam.Name == teamName)
                    {
                        teamExists = true;
                    }

                    if (currTeam.Creator == user || currTeam.Members.Contains(user))
                    {
                        memberExists = true;
                    }
                }

                if (teamExists && !memberExists)
                {
                    foreach (var currTeam in teams)
                    {
                        if (currTeam.Name == teamName)
                        {
                            currTeam.Members.Add(user);
                        }
                    }
                }
                else
                {
                    if (!teamExists)
                    {
                        Console.WriteLine($"Team {teamName} does not exist!");
                    }
                    else
                    {
                        Console.WriteLine($"Member {user} cannot join team {teamName}!");
                    }
                }
            }

            List<Team> teamsToDisband = new List<Team>();
            bool zeroMembers = false;

            foreach (var currTeam in teams)
            {
                if (currTeam.Members.Count == 0)
                {
                    zeroMembers = true;
                    teamsToDisband.Add(currTeam);
                }
            }


            // sort the teams
            List<Team> sorted = new List<Team>();
            sorted = teams.OrderByDescending(x => x.Members.Count).ThenBy(x => x.Name).ToList();

            foreach (var team in sorted)
            {
                team.Members.Sort();
            }

            // print
            foreach (var currTeam in sorted)
            {
                if (currTeam.Members.Count != 0)
                {
                    Console.WriteLine(currTeam.Name);
                    Console.WriteLine($"- {currTeam.Creator}");
                    foreach (var member in currTeam.Members)
                    {
                        Console.WriteLine($"-- {member}");
                    }
                }
            }
            
            Console.WriteLine("Teams to disband:");

            if (zeroMembers)
            {
                foreach (var team in teamsToDisband)
                {
                    Console.WriteLine(team.Name);
                }
            }
        }
    }

    class Team
    {
        public string Name { get; set; }
        public string Creator { get; set; }
        public List<string> Members { get; set; }
    }
}
