using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public sealed class Player : Character
    {
        //Fields

        //Properties

        public Type CharacterType { get; set; }
        public Weapon EquippedWeapon { get; set; }

        //Constructors

        public Player(string name, int hitChance, int block, int life, int maxLife, Type characterType, Weapon equippedWeapon)

        {
            MaxLife = life;
            Name = name;
            HitChance = hitChance;
            Block = block;
            Life = life;
            CharacterType = characterType;
            EquippedWeapon = equippedWeapon;

            switch (CharacterType)
            {
                case Type.MartyMcFly:
                    HitChance -= 1;
                    Block -= 1;
                    break;
                case Type.HanSolo:
                    HitChance += 5;
                    Block += 2;
                    break;
                case Type.FerriusBueller:
                    HitChance -= 1;
                    Block += 1;
                    break;
                case Type.SamanthaBarker:
                    break;
                case Type.LloydDobler:
                    Block += 2;
                    break;
                case Type.DanielLaRusso:
                    HitChance += 5;
                    Block += 4;
                    break;
                case Type.AndieWalsh:
                    block += 1;
                    break;
                case Type.ClarkGriswold:
                    HitChance -= 3;
                    Block -= 3;
                    break;
                case Type.Baby:
                    HitChance -= 2;
                    Block -= 2;
                    break;
                case Type.RogerRabbit:
                    HitChance += 4;
                    Block += 3;
                    break;
                case Type.Maverick:
                    HitChance += 3;
                    break;
            }


        }


        //Methods

        public override string ToString()
        {
            string description = "";

            switch (CharacterType)
            {
                case Type.MartyMcFly:
                    description = "Young Time Traveler that wears a red puffer vest.";
                    break;
                case Type.HanSolo:
                    description = "A reckless smuggler with a sarcastic wit";
                    break;
                case Type.FerriusBueller:
                    description = "Young high school guy that wants to enjoy life.";
                    break;
                case Type.SamanthaBarker:
                    description = "Coming of age girl with unexpected sixteenth birthday.";
                    break;
                case Type.LloydDobler:
                    description = "Young man in love, with a beat-box";
                    break;
                case Type.DanielLaRusso:
                    description = "Young man defending himself and love.";
                    break;
                case Type.AndieWalsh:
                    description = "A young female that has to choose between two suiters.";
                    break;
                case Type.ClarkGriswold:
                    description = "A father trying to give his family a worthwhile vacation";
                    break;
                case Type.Baby:
                    description = "A young lady that wants to dance dirty.";
                    break;
                case Type.RogerRabbit:
                    description = "A rabbit trying to clear his name.";
                    break;
                case Type.Maverick:
                    description = "A hot-shot jet pilot";
                    break;
            }

            return string.Format($"----{Name}----\n" +
                $"Life:{Life} of {MaxLife}\n" +
                $"Hit Chance: {CalcHitChance()}%\n" +
                $"Weapon:\n{EquippedWeapon}\n" +
                $"Block: {Block}\n" +
                $"Description:\n{description}");
        }

        public override int CalcDamage()
        {
            Random rand = new Random();

            int damage = rand.Next(EquippedWeapon.MinDamage, EquippedWeapon.MaxDamage + 1);

            return damage;
        }

        public override int CalcHitChance()
        {
            return base.CalcHitChance() + EquippedWeapon.BounusHitChance;
        }
    }//end class

}//end namespace
