using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace PersonsInfo
{
    public class Team
    {
        private string name;
        private List<Person> firstTeam;
        private List<Person> reserveTeam;

        public string Name { get; set; }
        public IReadOnlyCollection<Person> FirstTeam
        {
            get { return this.firstTeam.AsReadOnly(); }
        }
        public IReadOnlyCollection<Person> ReserveTeam
        {
            get
            { return this.reserveTeam.AsReadOnly(); }
        }

        public Team(string name)
        {
            this.Name = name;
            this.firstTeam = new List<Person>();
            this.reserveTeam = new List<Person>();            
        }  

        public void AddPlayer(Person player)
        {
            if (player.Age<40)
            {
                firstTeam.Add(player);
            }
            else
            {
                reserveTeam.Add(player);
            }
        }       
    }
}
