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
