using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Weapon
    {
        //Field

        private int _minDamage;

        //Prop

        public int MaxDamage { get; set; }
        public string Name { get; set; }
        public int BounusHitChance { get; set; }
        public bool IsTwoHanded { get; set; }

        public int MinDamage
        {
            get { return _minDamage; }
            set
            {
                if (value > 0 && value <= MaxDamage)
                {
                    _minDamage = value;
                }
                else
                {
                    _minDamage = 1;
                }
            }
        }//end of property

        public static Weapon StartWeapon()
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

            Weapon[] reaps = { wp1, wp2, wp3, wp4, wp5, wp6, wp7, wp8, wp9, wp10, wp11 };

            Random rando = new Random();
            int randomWpn = rando.Next(reaps.Length);
            Weapon reap = reaps[randomWpn];
            return reap;
        }




        //ctor
        //only creating the FQ ctor because we don't want to allow for creating a weapon with empty values (default ctor)

        public Weapon(int maxDamage, string name, int bounusHitChance, bool isTwoHanded, int minDamage)
        {
            //**************NOTE***************
            //The order in which you do the assignments below doesn't matter unless you have a biz rule that compares one prop to another (minDamage)
            //You have to assign a value to the prop used in the comparison (maxDamage) first so that you are not comparing against a null value
            //*********************************
            MaxDamage = maxDamage;
            Name = name;
            BounusHitChance = bounusHitChance;
            IsTwoHanded = isTwoHanded;
            MinDamage = minDamage;
        }
        
        //Methods
        
        public override string ToString()
        {
            return string.Format($"{Name}\t{MinDamage} to {MaxDamage}\nBonus Hit: {BounusHitChance}%\nIs Two Handed? {(IsTwoHanded ? "Yes" : "No")}");
        }

   


    }//end class

}//end namespace
