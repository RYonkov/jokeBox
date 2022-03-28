using System;
using System.Text;                          //For StringBuilder
using System.Text.RegularExpressions;       //For Regex
using System.Linq;                          //For lambda expressions
using System.Collections.Generic;           //For Dictionaries
using System.Numerics;                      //For BigInteger
using System.Diagnostics;                   //For clock, stopwatch
using System.Globalization;                 //For regional specifics


namespace HeroesOfCodeAndLogicVII

{
    class Hero
    {
        public Hero(string name, int hp, int mp)
        {
            this.Name=name;
            this.MP = mp;
            this.HP = hp;
        }
        public string Name { get; set; }
        public int HP { get; set; }
        public int MP { get; set; }

    }

    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Hero> heroes = new List<Hero>();

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                PopulateList(input, heroes);
            }

            string command = Console.ReadLine();
            while (command != "End")
            {
                string[] cmdArgs = command.Split('-', StringSplitOptions.RemoveEmptyEntries);
                string action = cmdArgs[0].Trim();
                string name = cmdArgs[1].Trim();

                if (action == "CastSpell")
                {
                    int MPneeded = int.Parse(cmdArgs[2].Trim());
                    string spellName = cmdArgs[3].Trim();

                    foreach (Hero element in heroes)
                    {
                        if (element.Name == name && element.MP >= MPneeded)
                        {
                            element.MP -= MPneeded;
                            Console.WriteLine($"{element.Name} has successfully cast {spellName} and now has {element.MP} MP!");
                        }
                        else if (element.Name == name && element.MP < MPneeded)
                        {
                            Console.WriteLine($"{element.Name} does not have enough MP to cast {spellName}!");
                        }
                    }
                }
                else if (action == "TakeDamage")
                {
                    int damage = int.Parse(cmdArgs[2].Trim());
                    string attacker = cmdArgs[3].Trim();

                    foreach (Hero element in heroes)
                    {
                        if (element.Name == name && element.HP > damage)
                        {
                            element.HP -= damage;
                            Console.WriteLine($"{element.Name} was hit for {damage} HP by {attacker} and now has {element.HP} HP left!");
                            break;
                        }
                        else if (element.Name == name && element.HP <= damage)
                        {
                            Console.WriteLine($"{element.Name} has been killed by {attacker}!");
                            heroes.Remove(element);
                            break;
                        }
                    }
                }
                else if (action == "Recharge")
                {
                    int recharge = int.Parse(cmdArgs[2]);

                    foreach (Hero element in heroes)
                    {
                        if (element.Name == name)
                        {
                            element.MP+=recharge;
                            int correction = 0;
                            if (element.MP > 200)
                            {
                                correction = element.MP - 200;
                                element.MP = 200;
                            }                           
                            Console.WriteLine($"{element.Name} recharged for {recharge - correction} MP!");
                        }
                    }
                }
                else if (action == "Heal")
                {
                    int heal = int.Parse(cmdArgs[2]);

                    foreach (Hero element in heroes)
                    {
                        if (element.Name == name)
                        {
                            element.HP += heal;
                            int correction = 0;
                            if (element.HP>100)
                            {
                                correction = element.HP - 100;
                                element.HP = 100;
                            }                            
                            
                            Console.WriteLine($"{element.Name} healed for {heal - correction} HP!");
                        }
                    }
                }
                command = Console.ReadLine();
            }

            foreach (Hero element in heroes)
            {
                Console.WriteLine($"{element.Name}");
                Console.WriteLine($"  HP: {element.HP}");
                Console.WriteLine($"  MP: {element.MP}");
            }
        }
    
            private static List<Hero> PopulateList(string input, List<Hero> heroes)
        {
            string[] cmdArg = input.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
            string name = cmdArg[0].Trim();
            int HP = int.Parse(cmdArg[1].Trim());
            int MP = int.Parse(cmdArg[2].Trim());
            Hero current = new Hero(name, HP, MP);
            heroes.Add(current);
            return heroes;
        }

    }
}
