using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShooterGame
{
    public class Character
    {
        public string name;
        public float Health;
        public float amor;
        public Weapon weaponUse;
        public bool Alive => Health > 0;

        public Character()
        {

        }

        public Character(string name)
        {
            this.name = name;
            this.Health = GameHelper.GetRandomValue(100,200);
            this.amor = GameHelper.GetRandomValue(50, 151);
            weaponUse = new Weapon();
        }

        public void ShowCharacterInfo()
        {
            Console.WriteLine("=======Character information===========");
            Console.WriteLine($"Name: {name}");
            Console.WriteLine($"Health: {Health}");
            Console.WriteLine($"Amor: {amor}");
            Console.ReadKey();
        }

        public void TakeDame()
        {
            if (!Alive)
            {
                return;
            }
            Health -= weaponUse.dame;
        }

        public void UseWeapon(Weapon weapon)
        {
            if (weaponUse != null)
            {
                weaponUse = weapon;
                Console.WriteLine(name + "Equip " + (WeaponType)weapon.type);
            }
            else
            {
                Console.WriteLine("Character already have" + (WeaponType)weapon.type);
            }
            Console.ReadKey();
        }

        public void RemoveWeapon()
        {
            if (weaponUse != null)
            {
                weaponUse = null;
                Console.WriteLine("Remove weapon succes");
            }
            else
            {
                Console.WriteLine("Character do not have any waepon");
            }
        }
    }
}
