using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;

namespace Guild
{
    public class Guild
    {
        private List<Player> roster;

        public Guild(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.Roster = new List<Player>();
        }
        public List<Player> Roster { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }

        public int Count => this.Roster.Count;

        public void AddPlayer(Player player)
        {
            if (this.Roster.Count < this.Capacity)
            {
                this.Roster.Add(player);
            }
        }

        public bool RemovePlayer(string name)
        {
            bool isExisting = false;

            if (this.Roster.Any(p => p.Name == name))
            {
                Player playerToRemove = this.Roster.Where(p => p.Name == name).First();
                this.Roster.Remove(playerToRemove);
                isExisting = true;
            }
            return isExisting;
        }

        public void PromotePlayer(string name)
        {
            for (int i = 0; i < this.Roster.Count; i++)
            {
                if (this.Roster[i].Name == name)
                {
                    if (this.Roster[i].Rank != "Member")
                    {
                        this.Roster[i].Rank = "Member";
                    }
                }
            }
        }

        public void DemotePlayer(string name)
        {
            for (int i = 0; i < this.Roster.Count; i++)
            {
                if (this.Roster[i].Name == name)
                {
                    if (this.Roster[i].Rank != "Trial")
                    {
                        this.Roster[i].Rank = "Trial";
                    }
                }
            }
        }

        public Player[] KickPlayersByClass(string @class)
        {
            List<Player> playersToRemove = new List<Player>();

            while (this.Roster.Any(p => p.Class == @class))
            {
                Player playerToRemove = this.Roster.Where(p => p.Class == @class).First();

                this.Roster.Remove(playerToRemove);
                playersToRemove.Add(playerToRemove);
            }

            return playersToRemove.ToArray();
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Players in the guild: {this.Name}");
            foreach (var player in this.Roster)
            {
                sb.AppendLine($"Player {player.Name}: {player.Class}");
                sb.AppendLine($"Rank: {player.Rank}");
                sb.AppendLine($"Description: {player.Description}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
