using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace HelloDungeon
{
    struct Weapon
    {
        public string Name;
        public float Damage;
    }
    class Game
    {
        bool gameOver;
        int CurrentScene = 0;

        Weapon Alfred;
        Character JoePable;
        Character LucyJill;
        Character JohnCena;
        Character Player;
        Character[] Enemies;
        Character LucyLucy;
        int currentEnemyIndex = 0;

        Player PlayerCharacter;


        float Heal(Character character2, float healAmount)
        {
            float newHealth = character2.GetHealth() + healAmount;
            return newHealth;
        }

        void Fight(ref Character character2)
        {


            Player.PrintStats();
            character2.PrintStats();

            bool isDefending = false;
            string battleChoice = PlayerCharacter.GetInput("Choose an action", "Attack", "Defend", "Run");

            if (battleChoice == "1")
            {
                character2.TakeDamage(Player.GetDamage());

                Console.WriteLine("You used " + Player.GetWeapon().Name + " !");
                if (character2.GetHealth() <= 0)
                {
                    return;
                }
            }
            else if (battleChoice == "2")
            {
                isDefending = true;
                Player.RaiseDefense();
                Console.WriteLine("You grit your teeth.");
            }
            else if (battleChoice == "3")
            {
                Console.WriteLine("You fled from the battle as fast as you could!");
                CurrentScene = 2;
                return;
            }
            Console.WriteLine(character2.GetName() + " punches " + Player.GetName() + "!");
            Player.TakeDamage(character2.GetDamage());

        }

        public void Start()
        {

            Alfred.Name = "Alfred";
            Alfred.Damage = 100f;

            JoePable = new Character("Joe Pable,", 2119f, 246.90f, 0.9f, Alfred);

            JohnCena = new Character("JOHN.......cena", 2120, 246.91f, 1f, Alfred);

            LucyJill = new Character("Lucy Jill DirtBag Biden", 2118, 246.89f, 0.8f, Alfred);

            LucyLucy = new Character("Lucy Lucy", 2117, 256.89f, 0.6f, Alfred);

            Enemies = new Character[4] { JoePable, JohnCena, LucyJill, LucyLucy };
            

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
            PlayerCharacter = new Player();
            string characterChoice = PlayerCharacter.GetInput("Choose your character", JoePable.GetName(), JohnCena.GetName(), LucyJill.GetName());

            if (characterChoice == "1")
            {
                PlayerCharacter = new Player (JoePable.GetName(), JoePable.GetHealth(), JoePable.GetDamage(), JoePable.GetDefence(), JoePable.GetWeapon());
            }
            else if (characterChoice == "2")
            {
                PlayerCharacter = new Player (JohnCena.GetName(), JohnCena.GetHealth(), JohnCena.GetDamage(), JohnCena.GetDefence(), JohnCena.GetWeapon());
            }
            else if (characterChoice == "3")
            {
                PlayerCharacter = new Player (LucyJill.GetName(), LucyJill.GetHealth(), LucyJill.GetDamage(), LucyJill.GetDefence(), LucyJill.GetWeapon());
            }
            else if (characterChoice == "4")
            {
                PlayerCharacter = new Player(LucyLucy.GetName(), LucyJill.GetHealth(), LucyJill.GetDamage(), LucyJill.GetDefence(), LucyJill.GetWeapon());
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
            Console.Clear();
            Fight( ref Enemies[currentEnemyIndex]);

            Console.Clear();
            if (Player.GetHealth() <= 0 || Enemies[currentEnemyIndex].GetHealth() <= 0)
            {
                CurrentScene = 2;
            }
        }

        void EndGameScene()
        {
            string playerChoice = PlayerCharacter.GetInput("You Died. Play Again?", "Yes", "No", "");

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
        {
            if (Player.GetHealth() > 0 && Enemies[currentEnemyIndex].GetHealth() <= 0)
            {
                Console.WriteLine("The winner is: " + Player.GetName());
                CurrentScene = 1;
                currentEnemyIndex++;

                if (currentEnemyIndex>= Enemies.Length)
                {
                    gameOver = true;
                }
            }
            else if (Enemies[currentEnemyIndex].GetHealth() > 0 && Player.GetHealth() <= 0)
            {
                Console.WriteLine("The winner is: " + Enemies[currentEnemyIndex].GetName());
                CurrentScene = 3;
            }
            Console.ReadKey(true);
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
