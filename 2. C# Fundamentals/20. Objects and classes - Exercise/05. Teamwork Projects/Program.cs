using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _05._Teamwork_Projects
{
    class Program
    {
        static void Main(string[] args)
        {
            int countOfTeams = int.Parse(Console.ReadLine());

            var teams = new List<Team>();

            for (int i = 0; i < countOfTeams; i++)
            {
                string[] currentTeam = Console.ReadLine().Split("-").ToArray();

                string creator = currentTeam[0];
                string teamName = currentTeam[1];

                if (teams.Any(x => x.TeamName == teamName))
                {
                    Console.WriteLine($"Team {teamName} was already created!");
                    continue;
                }
                if (teams.Any(x => x.Creator == creator))
                {
                    Console.WriteLine($"{creator} cannot create another team!");
                    continue;
                }

                Team team = new Team(teamName, creator);
                teams.Add(team);

                Console.WriteLine($"Team {teamName} has been created by {creator}!");
            }

            string[] userRequeast = Console.ReadLine().Split("->").ToArray();

            while (!userRequeast.Contains("end of assignment"))
            {
                string userRequesting = userRequeast[0];
                string teamToJoin = userRequeast[1];

                if (!teams.Any(x => x.TeamName == teamToJoin))
                {
                    Console.WriteLine($"Team {teamToJoin} does not exist!");
                    userRequeast = Console.ReadLine().Split("->").ToArray();
                    continue;
                }
                if (teams.Any(x => x.peopleJoined.Contains(userRequesting)) || teams.Any(x => x.Creator == userRequesting && x.TeamName == teamToJoin))
                {
                    Console.WriteLine($"Member {userRequesting} cannot join team {teamToJoin}!");
                    userRequeast = Console.ReadLine().Split("->").ToArray();
                    continue;
                }

                int index = teams.FindIndex(x => x.TeamName == teamToJoin);
                teams[index].peopleJoined.Add(userRequesting);
                
                userRequeast = Console.ReadLine().Split("->").ToArray();
            }

            var teamsToBeDisbanded = teams
                .FindAll(x => x.peopleJoined.Count == 0)
                .OrderBy(x => x.TeamName)
                .ToList();
            var validTeams = teams
                .FindAll(x => x.peopleJoined.Count > 0)
                .OrderBy(x => x.TeamName)
                .ToList();

            foreach (var team in teams.Where(x => x.peopleJoined.Count > 0)
            .OrderByDescending(x => x.peopleJoined.Count)
            .ThenBy(x => x.TeamName))
            {
                Console.WriteLine(team.ToString());
            }

            Console.WriteLine("Teams to disband:");
            foreach (var team in teamsToBeDisbanded)
            {
                Console.WriteLine(team.TeamName);
            }
        }
    }

    class Team
    {
        public string TeamName { get; set; }
        public string Creator { get; set; }
        public object StrinfBuilder { get; private set; }

        public List<string> peopleJoined;

        public Team(string teamName, string creator)
        {
            peopleJoined = new List<string>();
            this.TeamName = teamName;
            this.Creator = creator;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(TeamName + Environment.NewLine);
            sb.Append("- " + Creator + Environment.NewLine);


            foreach (var member in peopleJoined.OrderBy(x => x))
            {
                sb.AppendLine("-- " + member);
            }
            return sb.ToString().TrimEnd();
        }
    }
}
