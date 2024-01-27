using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ShooterGame
{
    public enum WeaponType
    {
        AK47,
        M4A1
    }
    public class Weapon
    {
        public WeaponType type;
        public float dame;
        public float bulletSpeed;
        public int   bulletperShot;
        public double DelayShot;
        public float Speed;
        public int magazine;
        public double ReloadSpeed;
        public int currentMagazine;

        public Weapon()
        {

        }

        public Weapon(WeaponType type)
        {
            dame = GameHelper.GetRandomValue(30, 70);
            this.type = type;
            bulletSpeed = GameHelper.GetRandomValue(1, 5);
            bulletperShot = GameHelper.GetRandomValue(1, 6);
            DelayShot = GameHelper.GetRandomvalue(0.1,0.5);
            Speed = GameHelper.GetRandomValue(30, 101);
            magazine = GameHelper.GetRandomValue(20, 31);
            ReloadSpeed = GameHelper.GetRandomvalue(0.1, 1.0);
            currentMagazine = magazine;
        }

        public void WeaponInformation()
        {
            Console.WriteLine("=======Thong tin vu khi =======");
            Console.WriteLine("Weapon Type: " + type.ToString());
            Console.WriteLine("Damge: " + dame);
            Console.WriteLine("Bullet Speed: " + bulletSpeed);
            Console.WriteLine("Bullet per shot: " + bulletperShot);
            Console.WriteLine("Delay shot: " + DelayShot);
            Console.WriteLine("Speed: " + Speed);
            Console.WriteLine("Magazine: " + magazine);
            Console.WriteLine("ReloadSpeed: " + ReloadSpeed);
            Console.WriteLine("=============================");
            Console.ReadKey();

            //int key = int.Parse(Console.ReadLine());
            //if (key == 2)
            //{
            //    Program.GameMenu();
            //}
            //else
            //{
            //    int enemyindexWeapon = GameHelper.GetRandomValue(0,Program.weapons.Length);
            //    int playerindexWeapon = GameHelper.GetRandomValue(0, Program.weapons.Length);
            //    while (enemyindexWeapon != playerindexWeapon)
            //    {
            //        Program.character[0].UseWeapon(Program.weapons[playerindexWeapon]);
            //        Program.character[1].UseWeapon(Program.weapons[enemyindexWeapon]);
            //    }
            //    Console.WriteLine("Use item on enemy and player success");
            //}
        }

        public void Reaload()
        {
            Console.WriteLine("Reloading......");
            Thread.Sleep((int)(ReloadSpeed * 1000));
            currentMagazine = magazine;
            Console.WriteLine($"Bullet: {currentMagazine}/{magazine}");
        }

        public void Shot()
        {
            if (currentMagazine > 0)
            {
                currentMagazine -= bulletperShot;
                Console.WriteLine($"{currentMagazine}/{magazine}");
            }
            else
            {
                Reaload();
            }
        }
    }
}
