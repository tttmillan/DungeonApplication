using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonLibrary;

namespace BadGuysLibrary
{
    public class Guys : BadGuy

    {

        //Prop
        public bool IsAlive { get; set; }

        //Ctor
        //FQ Ctor
        public Guys(string name, int life, int maxLife, int hitChance, int block, int minDamage, int maxDamage, string description, bool isalive) : base(name, life, maxLife, hitChance, block, maxDamage, description, minDamage)
        {
            IsAlive = isalive;
        }

        //we will make a custom default ctor - it will accept NO parameters but it will set some default values in the body of the method
        public Guys()
        {
            //default values
            MaxLife = 6;
            MaxDamage = 3;
            Life = 6;
            HitChance = 20;
            Name = "Typical Bad Guy";
            Block = 20;
            MinDamage = 1;
            Description = "Just a Low Level Bad Guy you are not a Hero!";
            IsAlive = false;
        }


        //Methods


        public override string ToString()
        {
            return base.ToString() + (IsAlive ? "Is Alive" : "A Spirit of Some Kind");
        }

        public override int CalcBlock()
        {
            //We will use IsFluffy to determine if the monster gets a boost to their block ability
            int calculatedBlock = Block;

            if (!IsAlive)
            {
                calculatedBlock += calculatedBlock / 2;//this gives the monster a 50% boost if they are not
            }
            return calculatedBlock;
        }

        public static Guys getEnemy()
        {
            Guys bg1 = new Guys();
            Guys bg2 = new Guys("Chucky", 40, 50, 40, 20, 1, 10, "Possessed Good Guy Doll", false);
            Guys bg3 = new Guys("Predator", 70, 80, 70, 35, 1, 20, "Space Explorer", true);
            Guys bg4 = new Guys("Hans Gruber", 20, 30, 15, 15, 1, 5, "German Terrorist", true);
            Guys bg5 = new Guys("Jason Voorhes", 60, 70, 60, 30, 1, 20, "Camp Cook", false);
            Guys bg6 = new Guys("Freddy Krueger", 60, 70, 60, 30, 1, 20, "Spirit of a Serial Killer", false);
            Guys bg7 = new Guys("Lo Pan", 50, 60, 50, 25, 1, 18, "Oriental Sorcerer", true);
            Guys bg8 = new Guys("The Fratellis", 30, 40, 30, 15, 1, 10, "The outlaw family of the Boondocks", true);
            Guys bg9 = new Guys("Darth Vader", 80, 100, 80, 40, 1, 25, "Cyborg chief enforcer of the Galactic Empire", true);
            
            Guys[] badGuys = { bg1, bg2, bg3, bg4, bg5, bg6, bg7, bg8, bg9 };
                      
            Random rand = new Random();
            int randomNbr = rand.Next(badGuys.Length);
            Guys badGuy = badGuys[randomNbr];

            return badGuy;
        }
    }//end class

}//end namespace