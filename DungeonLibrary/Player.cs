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

        public static Type PlayerType(ConsoleKey userType)
        {
            DungeonLibrary.Type typeCh = new DungeonLibrary.Type();
            switch (userType)
            {
                case ConsoleKey.A:
                    Console.WriteLine("\nWait a minute doc. Wait a minute Doc,\n are you telling me you built a time machine out of a DeLorean?\n");
                    typeCh = Type.MartyMcFly;
                    break;
                case ConsoleKey.B:
                    Console.WriteLine("\nYou like me because I'm a scoundrel.\n There aren't enough scoundrels in your life\n");
                    typeCh = Type.HanSolo;
                    break;
                case ConsoleKey.C:
                    Console.WriteLine("\nLife moves pretty fast. If you don't stop and look around once in a while,\n you could miss it.\n");
                    typeCh = Type.FerriusBueller;
                    break;
                case ConsoleKey.D:
                    Console.WriteLine("\nI can't believe my Grandmother actually felt me up.\n");
                    typeCh = Type.SamanthaBarker;
                    break;
                case ConsoleKey.E:
                    Console.WriteLine("\nYou must chill. You must chill. Wigging out has never accomplished anything,\n plus it's really obnoxious. Don't be a spaz. Breathe deep, stay calm, ...\n");
                    typeCh = Type.LloydDobler;
                    break;
                case ConsoleKey.F:
                    Console.WriteLine("\nBanzai!\n");
                    typeCh = Type.DanielLaRusso;
                    break;
                case ConsoleKey.G:
                    Console.WriteLine("\nIf somebody doesn't believe in me, I can't believe in them.\n");
                    typeCh = Type.AndieWalsh;
                    break;
                case ConsoleKey.H:
                    Console.WriteLine("\nWould you rather I slipped her in the night deposit box\n at the funeral home?\n");
                    typeCh = Type.ClarkGriswold;
                    break;
                case ConsoleKey.I:
                    Console.WriteLine("\nI carried a watermelon.\n");
                    typeCh = Type.Baby;
                    break;
                case ConsoleKey.J:
                    Console.WriteLine("\nP-p-please, Eddie! Don't throw me out.\n Don't you realize you're making a big mistake?\n I didn't kill anybody. I swear!");
                    typeCh = Type.RogerRabbit;
                    break;
                case ConsoleKey.K:
                    Console.WriteLine("\nI feel the need....\n....The need for Speed!\n");
                    typeCh = Type.Maverick;
                    break;
                default:
                    Console.WriteLine("\nYou choose a wrong action, For Sure.\n Don't be a Dweeb and take it To The Max.....\n");
                    break;
            }
            return typeCh;
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
