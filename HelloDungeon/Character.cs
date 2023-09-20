using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HelloDungeon
{
    internal class Character
    {
        
        
        private string _Name;
        private float _Health;
        private float _Damage;
        private float _Defense;
        private Weapon _CurrentWeapon;
        private float _DefenseBoost = 5;

        public Character()
        {
            _Name = "";
            _Health = 0;
            _Damage = 0;
            _Defense = 0;
        }


        public Character(string name, float health, float damage, float defense, Weapon weapon)
        {
            _Name = name;
            _Health = health;
            _Damage = damage;
            _Defense = defense;
            _CurrentWeapon = weapon;
        }

        public float GetDamage()
        {
            return _Damage;
        }
        public float GetHealth()
        {
            return _Health;
        }
        public Weapon GetWeapon()
        {
            return _CurrentWeapon;
        }
        public string GetName()
        {
            return _Name;
        }

        public void RaiseDefense()
        {
            _Defense += _DefenseBoost;
        }
        public void ResetDefense()
        {
            _Defense -= _DefenseBoost;
        }
        public void PrintStats()
        {
            Console.WriteLine("Name: " + _Name);
            Console.WriteLine("Health: " + _Health);
            Console.WriteLine("Damage: " + _Damage);
            Console.WriteLine("Defence: " + _Defense);

        }
        public float GetDefence()
        {
            return _Defense;
        }


        public void TakeDamage(float damage)
        {
            _Health -= damage - _Defense;
        }
    }
}
