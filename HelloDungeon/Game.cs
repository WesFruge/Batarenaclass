using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloDungeon
{
    class Game
    {
        struct Monster
        {
            public string Name;
            public float Health;
            public float Damage;
            public float Defence;
            public float Stamina;
        }

        void PrintStats(Monster monster)
        {
            Console.WriteLine("Monster Name: " + monster.Name);
            Console.WriteLine("Monster Health: " + monster.Health);
            Console.WriteLine("Monster Damage: " + monster.Damage);
            Console.WriteLine("Monster Defence: " + monster.Defence);
            Console.WriteLine("Monster Stamina: " + monster.Stamina);

        }

        float Attack(Monster attacker, Monster defender)
        {
            float totalDamage = attacker.Damage - defender.Defence;

            return defender.Health - totalDamage;
        }

        float Heal(Monster attacker, Monster defender)
        {
            float totalDamage = attacker.Damage - defender.Defence;
            float totalHeal = totalDamage;
            return attacker.Health + totalHeal;

        }

        void Fight(Monster monster1, Monster monster2)
        {
                Console.WriteLine(monster1.Name + " punches " + monster2.Name + "!");
            monster2.Health = Attack(monster1, monster2);
            Console.ReadKey (true);


            PrintStats(monster1);
            PrintStats(monster2);


            Console.WriteLine(monster2.Name + " punches " + monster1.Name + "!");
            monster2.Health = Attack(monster2, monster1);
            Console.ReadKey(true);


            PrintStats(monster1);
            PrintStats(monster2);

            Console.WriteLine(monster1.Name + " Syphons the blood from " + monster2.Name + "!");
            monster2.Health = Attack(monster1, monster2);
            monster1.Health = Heal(monster1, monster2);
            Console.ReadKey(true);

            PrintStats(monster1);
            PrintStats(monster2);
        }


        public void Run()
        {
            Monster JoePable;
            JoePable.Name = "JoePable";
            JoePable.Health = 2119f;
            JoePable.Damage = 246.90f;
            JoePable.Defence = 0.9f;
            JoePable.Stamina = 3;

            Monster JohnCena;
            JohnCena.Name = "JOHN.......cena";
            JohnCena.Health = 2120;
            JohnCena.Damage = 246.91f;
            JoePable.Defence = 1f;
            JohnCena.Stamina = 4f;

            Monster LucyJill;
            LucyJill.Name = "Lucy Jill DirtBag Biden";
            LucyJill.Health = 2118;
            LucyJill.Damage = 246.89f;
            LucyJill.Defence = 0.8f;
            LucyJill.Stamina = 0f;

            PrintStats(JoePable);
            PrintStats(LucyJill);

            Fight(JoePable, LucyJill);

            Console.Clear();

            Fight(JoePable, LucyJill);

            Console.Clear();

        }
    }
}
