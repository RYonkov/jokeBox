using System;
using System.Text;                          //For StringBuilder
using System.Text.RegularExpressions;       //For Regex
using System.Linq;                          //For lambda expressions
using System.Collections.Generic;           //For Dictionaries
using System.Numerics;                      //For BigInteger
using System.Diagnostics;                   //For clock, stopwatch
using System.Globalization;                 //For regional specifics


namespace TeamworkProjects
{
    class Team
    {
        public Team(string Creator, string Name)
        {
            this.Creator = Creator;
            this.Name = Name;
            this.Members = new List<string>();
        }
        public string Creator { get; set; }
        public string Name { get; set; }
        public List<string> Members { get; set; }

        public void AddMember (string member)
        {
            this.Members.Add (member);
        }

    }

    class Program
	{
        static void Main(string[] args)
        {
           
            List<Team> teams = new List<Team>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {

                string input = Console.ReadLine();
                string[] inputArgs = input.Split('-', StringSplitOptions.RemoveEmptyEntries).ToArray();
                string creator = inputArgs[0];
                string teamName = inputArgs[1];

                  if (teams.Any(x => x.Name == teamName))
                {
                    Console.WriteLine($"Team {teamName} was already created!");
                    continue;
                }
                
                if (teams.Any(x => x.Creator == creator))
                {
                    Console.WriteLine($"{creator} cannot create another team!");
                    continue;
                }

                Team current = new Team(creator, teamName);
                teams.Add(current);
                Console.WriteLine($"Team {teamName} has been created by {creator}!");
            }

            string command = Console.ReadLine ();
            while (command!= "end of assignment")
            {
                string[] cmdArgs = command.Split("->", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string user = cmdArgs[0];
                string team = cmdArgs[1];

                if (!teams.Any(x => x.Name == team))
                {
                    Console.WriteLine($"Team {team} does not exist!");
                }
                else if (teams.Any(x => x.Members.Contains(user)) || teams.Any(x=>x.Creator==user))
                {
                    Console.WriteLine($"Member {user} cannot join team {team}!");
                    command = Console.ReadLine();
                    continue;
                }
              
                else
                {
                    foreach (Team element in teams)
                    {
                        if (element.Name == team)
                        {
                            element.Members.Add(user);
                        }
                    }
                }

                command = Console.ReadLine();
            }

            List<Team> validTeams = teams.Where(x=>x.Members.Count() > 0)
                                         .OrderByDescending(x=>x.Members.Count)
                                         .ThenBy(x=>x.Name)
                                         .ThenBy(x=>x.Members)
                                         .ToList();


            List<Team> teamsToDisband = teams.Where(x=>x.Members.Count()==0)
                                             .OrderBy(x=>x.Name)
                                             .ToList();

            foreach (Team element in validTeams)
            {
                Console.WriteLine(element.Name);
                Console.WriteLine($"- {element.Creator}");

                foreach (var item in element.Members.OrderBy(x=>x))
                {
                    Console.WriteLine($"-- {item}");
                }                
            }

            Console.WriteLine("Teams to disband:");
            foreach (Team element in teamsToDisband)
            {
                Console.WriteLine(element.Name);
            }


        }         
                
    }
}