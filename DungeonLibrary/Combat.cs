using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Combat
    {
        public static void DoAttack(Character attacker, Character defender)
        {
            Random rand = new Random();
            int diceRoll = rand.Next(1, 101);
            System.Threading.Thread.Sleep(30);
            if (diceRoll <= (attacker.CalcHitChance() - defender.CalcBlock()))//you can use a different method
            {
                int damageDealt = attacker.CalcDamage();

                defender.Life -= damageDealt;

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{attacker.Name} hit {defender.Name} for {damageDealt} damage!");
                Console.ResetColor();
            }//end if
            else
            {
                Console.WriteLine($"{attacker.Name} missed!");
            }


        }

        public static void DroppedWeapon(Player player)
        {

            Weapon wp1 = new Weapon(6, "Black Sunglasses", 1, false, 3);
            Weapon wp2 = new Weapon(20, "Colt Peacemaker", 10, false, 10);
            Weapon wp3 = new Weapon(20, "Blaster Pistol", 16, true, 10);
            Weapon wp4 = new Weapon(10, "Birthday Cake", 4, true, 5);
            Weapon wp5 = new Weapon(6, "BeatBox", 18, true, 3);
            Weapon wp6 = new Weapon(12, "Karate", 14, true, 6);
            Weapon wp7 = new Weapon(8, "Pink Dress", 2, false, 4);
            Weapon wp8 = new Weapon(2, "Bologna Sandwich", 1, false, 1);
            Weapon wp9 = new Weapon(4, "Watermelon", 2, true, 2);
            Weapon wp10 = new Weapon(16, "Toon Revolver", 6, true, 8);
            Weapon wp11 = new Weapon(4, "G-1 Flight Jacket", 12, false, 2);

            Weapon[] weaps = { wp1, wp2, wp3, wp4, wp5, wp6, wp7, wp8, wp9, wp10, wp11 };

            Random rand = new Random();
            int randomWpn = rand.Next(weaps.Length);
            Weapon weap = weaps[randomWpn];



            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\nThey dropped {0}!\n", weap);
            Console.ResetColor();

            Console.WriteLine("\nWould you like this weapon? Y or N\n");
            ConsoleKey userChoice = Console.ReadKey(true).Key;
            Console.Clear();

            switch (userChoice)
            {
                case ConsoleKey.Y:
                    Console.WriteLine("\nYou picked up! {0}", weap);
                    player.EquippedWeapon = weap;
                    break;
                case ConsoleKey.N:
                    Console.WriteLine("\nYou missed out!\n");
                    break;
                default:
                    Console.WriteLine("\nYou choose a wrong action, For Sure.\n Don't be a Dweeb and take it To The Max.....\n");
                    break;
            }
        }

        public static void DroppedHealth(Player player)
        {

            int h1 = 70;
            int h2 = 60;
            int h3 = 50;
            int h4 = 40;
            int h5 = 30;
            int h6 = 20;
            int h7 = 10;

            int[] heals = { h1, h2, h3, h4, h5, h6, h7 };



            Random rand = new Random();
            int randomHlth = rand.Next(heals.Length);
            int heal = heals[randomHlth];

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\nThey dropped {0}!\n", heal);
            Console.ResetColor();

            Console.WriteLine("\nWould you like this Health? Y or N\n");
            ConsoleKey userChoice = Console.ReadKey(true).Key;
            Console.Clear();

            //Would they like health
            switch (userChoice)
            {
                case ConsoleKey.Y:
                    Console.WriteLine("\nYou picked up {0} amount of health.\n", heal);
                    player.Life += heal;
                    break;
                case ConsoleKey.N:
                    Console.WriteLine("\nYou missed out!\n");
                    break;
                default:
                    Console.WriteLine("\nYou choose a wrong action, For Sure.\n Don't be a Dweeb and take it To The Max.....\n");
                    break;
            }
        }




        public static void DoBattle(Player player, BadGuy badGuy)
        {
            DoAttack(player, badGuy);
            if (badGuy.Life > 0)
            {
                DoAttack(badGuy, player);
            }
            else
            {
                DroppedWeapon(player);
                DroppedHealth(player);

            }
        }

    }//end class

}//end namespace
