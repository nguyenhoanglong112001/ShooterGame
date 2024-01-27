using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ShooterGame
{
    internal class Program
    {
        public static Weapon[] weapons = null;
        public static Character[] characters = null;
        static void Main(string[] args)
        {
            Player player = new Player("Player");
            Enemy enemy = new Enemy("Enemy");
            characters = new Character[] {player,enemy};
            weapons = new Weapon[2];
            while (true)
            {
                int key = GameMenu();
                switch(key)
                {
                    case 1:
                        {
                            ShowCharacter();
                            break;
                        }
                    case 2:
                        {
                            CreateWeapon();
                            break;
                        }
                    case 3:
                        {
                            ShowWeapon();
                            break;
                        }
                    case 4:
                        {
                            UseItem(player);
                            Thread.Sleep(1000);
                            UseItem(enemy);
                            break;
                        }
                    case 5:
                        {
                            GameStart(player, enemy, 100);
                            break;
                        }
                }
            }
        }

        public static int GameMenu()
        {
            Console.Clear();
            Console.WriteLine("======== Welcome to shooter game ===========");
            Console.WriteLine("1. Show character information");
            Console.WriteLine("2. Create weapon");
            Console.WriteLine("3. Show weapon information");
            Console.WriteLine("4. Equip Weapon");
            Console.WriteLine("5. Start game");
            Console.WriteLine("6. Exit");
            Console.WriteLine("Please choose 1 function: ");

            int key = int.Parse(Console.ReadLine());
            return key;
        }

        public static void ShowCharacter()
        {
            Console.Clear();
            for (int i = 0;i<characters.Length;i++)
            {
                Console.WriteLine($"{i + 1}. {characters[i].name}");
            }
            Console.WriteLine("Choose charater too see detail");
            int key = int.Parse(Console.ReadLine());
            if (key == 0)
                GameMenu();
            else
                characters[key - 1].ShowCharacterInfo();
        }

        public static void CreateWeapon()
        {
            for (int i = 0; i < weapons.Length; i++)
            {
                WeaponType weaponType = (WeaponType)GameHelper.GetRandomValue(0, 2);
                Weapon newweapon = null;
                switch (weaponType)
                {
                    case WeaponType.AK47:
                        newweapon = new Weapon(weaponType);
                        break;
                    case WeaponType.M4A1:
                        newweapon = new Weapon(weaponType);
                        break;
                }
                weapons[i] = newweapon;
                Thread.Sleep(100);
            }
            Console.WriteLine("Tao trang bi thanh cong");
            Console.ReadKey();
            GameMenu();
        }

        public static void ShowWeapon()
        {
            for (int i =0;i<weapons.Length;i++)
            {
                Console.WriteLine($"{i + 1}. {weapons[i].type.ToString()}");
            }
            Console.WriteLine("Chose weapon to see detail");
            int key = int.Parse(Console.ReadLine());
            if (key == 0) {
                GameMenu();
            }
            else
            {
                weapons[key-1].WeaponInformation();
            }
        }

        public static void UseItem(Character charater)
        {
            List<Weapon> avalibleWeapon = new List<Weapon>(weapons);
            foreach (var hero in characters)
            {
                if (avalibleWeapon.Count > 0 )
                {
                    int weaponIndex = GameHelper.GetRandomValue(0, avalibleWeapon.Count);
                    hero.UseWeapon(avalibleWeapon[weaponIndex]);
                    avalibleWeapon.RemoveAt(weaponIndex);
                }
            }
        }

        public static void GameStart(Player player, Enemy enemy, int distance)
        {
            double enemyTime = Math.Round(distance / enemy.weaponUse.Speed,2);
            double playerTime = Math.Round(distance / player.weaponUse.Speed, 2);
            Console.WriteLine($"{enemyTime} , {playerTime}");
            double Timecount = 0.0;
            double Timecountr = Math.Round(Timecount, 2);
            while (player.Alive && enemy.Alive)
            {
                //player.weaponUse.Shot();
                //enemy.weaponUse.Shot();
                Console.WriteLine($"Time: {Timecountr}");
                if (Math.Abs(Timecountr - enemyTime) < 0.01)
                {
                    player.TakeDame();
                    Console.WriteLine($"{enemy.name} deal {enemy.weaponUse.dame * enemy.weaponUse.bulletperShot} to {player.name}");
                    Console.WriteLine($"{player.name}'s Health : {player.Health}");
                }
                else if (Math.Abs(Timecountr - playerTime) < 0.01)
                {
                    enemy.TakeDame();
                    Console.WriteLine($"{player.name} deal {player.weaponUse.dame * player.weaponUse.bulletperShot} to {enemy.name}");
                    Console.WriteLine($"{enemy.name}'s Health : {enemy.Health}");
                }
                if (enemyTime - playerTime <0.01)
                {
                    if (Math.Abs(Timecountr - playerTime) < 0.01)
                    {
                        Timecountr = 0.0;
                    }
                }
                else if (enemyTime - playerTime > 0.01)
                {
                    if (Math.Abs(Timecountr - enemyTime) < 0.01)
                    {
                        Timecountr = 0.0;
                    }
                }
                Timecountr += 0.01;
                Thread.Sleep(100);
            }

            Console.ReadKey();
        }
    }
}
