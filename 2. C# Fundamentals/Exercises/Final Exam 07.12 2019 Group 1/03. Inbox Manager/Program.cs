using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;

namespace _03._Inbox_Manager
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] commands = Console.ReadLine().Split("->");

            var inboxManager = new Dictionary<string, List<string>>();

            while (!commands.Contains("Statistics"))
            {
                switch (commands[0])
                {
                    case "Add":
                        string username = commands[1];
                        if (inboxManager.ContainsKey(username))
                        {
                            Console.WriteLine($"{username} is already registered");
                        }
                        else
                        {
                            inboxManager.Add(username, new List<string>());
                        }
                        break;
                    case "Send":
                        username = commands[1];
                        string email = commands[2];
                        inboxManager[username].Add(email);
                        break;
                    case "Delete":
                        username = commands[1];
                        if (!inboxManager.ContainsKey(username))
                        {
                            Console.WriteLine($"{username} not found!");
                        }
                        else
                        {
                            inboxManager.Remove(username);
                        }
                        break;
                }

                commands = Console.ReadLine().Split("->");
            }

            Console.WriteLine($"Users count: {inboxManager.Keys.Count}");
            foreach (var user in inboxManager
                .OrderByDescending(x => x.Value.Count)
                .ThenBy(x => x.Key))
            {
                Console.WriteLine($"{user.Key}");
                foreach (var email in user.Value)
                {
                    Console.WriteLine($" - {email}");
                }
            }
        }
    }
}
