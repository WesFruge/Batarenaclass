using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace HelloDungeon
{
    class Game
    {
        struct Character
        {
            public string Name;
            public float Health;
            public float Damage;
            public float Defence;
            public float Stamina;
            public Weapon CurrentWeapon;
        }

        struct Weapon
        {
            public string Name;
            public float Damage;
        }

        bool gameOver;
        int CurrentScene = 0;

        Weapon Alfred;
        Character JoePable;
        Character LucyJill;
        Character JohnCena;
        Character Player;
        Character[] Enemies;
        int currentEnemyIndex = 0;

        void PrintStats(Character character)
        {
            Console.WriteLine("Name: " + character.Name);
            Console.WriteLine("Health: " + character.Health);
            Console.WriteLine("Damage: " + character.Damage);
            Console.WriteLine("Defence: " + character.Defence);
            Console.WriteLine("Stamina: " + character.Stamina);

        }



        float Attack(Character attacker, Character defender)
        {
            float totalDamage = attacker.Damage - defender.Defence;

            return defender.Health - totalDamage;
        }



        float Heal(Character attacker, Character defender)
        {
            float totalDamage = attacker.Damage - defender.Defence;
            float totalHeal = totalDamage;
            return attacker.Health + totalHeal;

        }

        void Fight(ref Character character2)
        {


            PrintStats(Player);
            PrintStats(character2);


            string battleChoice = GetInput("Choose an action", "Attack","Defend", "Run");

            if (battleChoice == "1")
            {
                character2.Health = Attack(Player, character2);
                Console.WriteLine("You used " + Player.CurrentWeapon.Name + " !");
            }
            else if (battleChoice == "2")
            {
                Console.WriteLine("You grit your teeth.");
            }
            else if (battleChoice == "3")
            {
                Console.WriteLine("You fled the battle field");
            }


        }

        public void Start()
        {

            Alfred.Name = "Alfred";
            Alfred.Damage = 100f;


            JoePable.Name = "JoePable";
            JoePable.Health = 2119f;
            JoePable.Damage = 246.90f;
            JoePable.Defence = 0.9f;
            JoePable.Stamina = 3f;
            JoePable.CurrentWeapon = Alfred;



            JohnCena.Name = "JOHN.......cena";
            JohnCena.Health = 2120;
            JohnCena.Damage = 246.91f;
            JoePable.Defence = 1f;
            JohnCena.Stamina = 4f;


            LucyJill.Name = "Lucy Jill DirtBag Biden";
            LucyJill.Health = 2118;
            LucyJill.Damage = 246.89f;
            LucyJill.Defence = 0.8f;
            LucyJill.Stamina = 0f;

            Enemies = new Character[3] { JoePable, JohnCena, LucyJill };
            

        }

        string GetInput(string prompt, string option1, string option2, string option3)
        {
            string playerChoice = "";

            Console.WriteLine(option1);
            Console.WriteLine("1." + option1);
            Console.WriteLine("1." + option2);
            Console.WriteLine("1." + option3);
            Console.Write(">");

            playerChoice = Console.ReadLine();

            return playerChoice;
        }

        void PrintSum(int[] numbers)
        {
            int sum = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                sum += numbers[i];
            }
            Console.WriteLine(sum);
        }


        void PrintLargest(int[] numbers)
        {
            int currentNumber = 0;
            int biggestNumber = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                currentNumber = numbers[i];

                if (currentNumber > biggestNumber)
                {
                    biggestNumber = currentNumber;
                }
            }
            Console.WriteLine(biggestNumber);
        }

        void CharacterSelection()
        {
            string characterChoice = GetInput("Choose your character", JoePable.Name, JohnCena.Name, LucyJill.Name);

            if (characterChoice == "1")
            {
                Player = JoePable;
            }
            else if (characterChoice == "2")
            {
                Player = JohnCena;
            }
            else if (characterChoice == "3")
            {
                Player = LucyJill;
            }
            else
            {
                Console.WriteLine("Invalid input");
                Console.WriteLine("Press any key to continue");
                Console.ReadKey(true);
                Console.Clear();
                return;
            }
        }


        void BattleScene()
        {
            Fight( ref Enemies[currentEnemyIndex]);

            Console.Clear();

            if (JoePable.Health <= 0 || LucyJill.Health <= 0)
            {
                CurrentScene = 1;
            }

        }

        void EndGameScene()
        {
            string playerChoice = GetInput("You Died. Play Again?", "Yes", "No", "");

            if(playerChoice == "1")
            {
                CurrentScene = 0;
            }
            else if (playerChoice == "2")
            {
                gameOver = true;
            }
        }


        void WinResultScene()
        {Player.Health > 0 && Enemies[currentEnemyIndex].Health >= 0)
            {
                Console.WriteLine("The winner is: " + JoePable.Name);
                CurrentScene = 1;
                currentEnemyIndex++;
            }
            else if (Enemies[currentEnemyIndex].Health > 0 && JoePable.Health <= 0)
            {
                Console.WriteLine("The winner is: " + Enemies[currentEnemyIndex].Name);
                CurrentScene = 3;
            }
            Console.ReadKey(true);
            Console.Clear();
        }


        void Update()
        {
            if (CurrentScene == 0)
            {
                CharacterSelection();
            }
            else if (CurrentScene == 1)
            {
                BattleScene();
            }
            else if (CurrentScene == 2)
            {
                WinResultScene();
            }
            else if (CurrentScene == 1)
            {
                EndGameScene();
            }
        }

        void End()
        {
            Console.WriteLine("Thanks For Playing");
        }


        public void Run()
        {
            int[] numbers = new int[3] { 1, 2, 4 };
            PrintLargest(numbers);
            Start();

            CharacterSelection();



            while (gameOver == false)
            {
                Update();
            }

            End();
        }
    }
}
