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









    }//end class

}//end namespace