﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloDungeon
{
    internal class Player : Character
    {
        private string _playerchoice;
        private int _lives = 3;

        public override void PrintStats()
        {
            Console.WriteLine("Name: " + GetName());
            Console.WriteLine("Health: " + GetHealth());
            Console.WriteLine("Damage: " + GetDamage());
            Console.WriteLine("Defense: " + GetDefence());
            Console.WriteLine("Lives: " + _lives);
        }


        public Player()
        {
            _playerchoice = "";
        }

        public Player(string name, float health, float damage, float defense, Weapon weapon) : base(name, health, damage, defense, weapon)
        {
            _playerchoice = "";

        }
        public string GetInput(string prompt, string option1, string option2, string option3)
        {
            _playerchoice = "";

            Console.WriteLine(option1);
            Console.WriteLine("1." + option1);
            Console.WriteLine("2." + option2);
            Console.WriteLine("3." + option3);  
            Console.Write(">");

            _playerchoice = Console.ReadLine();

            return _playerchoice;
        }
        public string GetInput(string prompt, string option1, string option2, string option3, string option4)
        {
            _playerchoice = "";

            Console.WriteLine(option1);
            Console.WriteLine("1." + option1);
            Console.WriteLine("1." + option2);
            Console.WriteLine("1." + option3);
            Console.WriteLine("4." + option4);
            Console.Write(">");

            _playerchoice = Console.ReadLine();

            return _playerchoice;
        }
        public string GetInput(string prompt, string option1, string option2)
        {
            _playerchoice = "";

            Console.WriteLine(option1);
            Console.WriteLine("1." + option1);
            Console.WriteLine("2." + option2);
            Console.Write(">"); 

            _playerchoice = Console.ReadLine();

            return _playerchoice;
        }
        
    }
}
