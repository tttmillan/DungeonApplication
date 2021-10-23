using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonLibrary;
using BadGuysLibrary;
using Type = DungeonLibrary.Type;


namespace DungeonProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            Music.IntroMusic();

            Console.Title = "The 80's";

            Console.WriteLine("\nYou have Detention in the Library\n\nGood luck!\n\n");

            int score = 0;

            Weapon reap = Weapon.StartWeapon();


            //TODO 2. Create a player

            Console.WriteLine("What would you like your name to be?");
            string name = Console.ReadLine();

            Console.WriteLine(MenuSelection.PlayerTypeString(name));

            ConsoleKey userType = Console.ReadKey(true).Key;

            Console.Clear();

            DungeonLibrary.Type typeCh = new DungeonLibrary.Type();

            typeCh = Player.PlayerType(userType);

            Player player = new Player(name, 100, 0, 90, 100, typeCh, reap);                 

            bool exit = false;

            do
            {
       
                Console.WriteLine(GetRoom());
                             
                Guys badGuy = Guys.getEnemy();

                Console.WriteLine("\nIn this room: \n\n" + badGuy.Name);
                          
                bool reload = false;

                do
                {

                    //TODO 8. Create a menu of Options
                    Console.WriteLine("\nPlease choose an action:\n" +
                        "A) Attack\n" +
                        "R) Run Away\n" +
                        "P) Player Info\n" +
                        "B) BadGuy Info\n" +
                        "X) Exit\n");

                    //TODO 9. Capture user choice
                    ConsoleKey userChoice = Console.ReadKey(true).Key;

                    Console.Clear();

                    //TODO 10. Perform an action based on users input(attack, runaway)
                    switch (userChoice)
                    {
                        case ConsoleKey.A:
                            //TODO 11. Create attack/battle
                            //TODO 12. Handle if user wins
                            Combat.DoBattle(player, badGuy);
                            if (badGuy.Life <= 0)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("\nYou killed {0}!\n", badGuy.Name);
                                Console.ResetColor();
                                reload = true;
                                score++;

                            }
                            break;

                        case ConsoleKey.R:
                            //TODO 13. Handle the monster killing you for leaving
                            Console.WriteLine($"{badGuy.Name} \nLike, Totally attacks you as you flee!\n");
                            Combat.DoAttack(badGuy, player);//free attack
                            Console.WriteLine();
                            reload = true; //load a new room
                            break;
                        case ConsoleKey.P:
                            Console.WriteLine("Player Info\n");
                            ////TODO 14. Write out player info to screen
                            Console.WriteLine(player);
                            break;
                        case ConsoleKey.B:
                            Console.WriteLine("\nBadGuy Info\n");
                            ////TODO 15. Write out Monster info to screen
                            Console.WriteLine(badGuy);
                            break;
                        case ConsoleKey.X:
                        case ConsoleKey.E:
                            Console.WriteLine("\nBogus, Hey Spaz go take a chill pill.....\n");
                            exit = true;
                            break;
                        default:
                            Console.WriteLine("\nFor Sure you choose a wrong action.\n Don't be a Dweeb and take it To The Max.....\n");
                            break;

                    }
                    Console.ResetColor();

                    //TODO 16. Check the players life
                    if (player.Life <= 0)
                    {
                        Console.WriteLine("\nYou are Awesome!\n\n Psych Dude you Died!\n");
                        exit = true;
                    }

                } while (!exit && !reload);
                //}while (exit == false && reload == false)


            } while (!exit);
            //}while(exit == false)     

            //TODO 17. Show Player how many monsters they defeated
            Console.WriteLine("\nYou defeated\n " + score + "\n 80's Bad Guy" + (score == 1 ? "." : "s.") + "\n");

            if (score >= 5)
            {
                Console.WriteLine("\nYou made it out of Detention! \nKey The Music!!!\n" +
                    "\nDon't you forget about me\n" +
                    "\nDon't Don't Don't Don't\n" +
                    "\nDon't you forget about me!\n");
            }


        }//end Main()

        private static string GetRoom()
        {
            string[] rooms =
            {
                "You skipped out of school all day and the Principle knows that you did and is trying to catch you out and about.\n Your parents think you are in bed sick. You have to make it home before your parents get home.\n",

                "You moved to a small town where they believe that any dancing is bad for the community.\n The Preacher of the town is trying to get you into trouble.\n You have to prove that dancing is part of life and to enjoy and show that it is not a bad thing.\n",

                "You have to find an religious artifact before the Nazi's do\n and if you don't it can mean the end of the western civilization.\n",

                "You move to a new town where you meet a girl\n and her ex-boyfriend is a karate bully and\nyou have to learn how to defend yourself with Karate\n learned from the maintenance man in your apartment complex.\n",

                "You are a private detective that has had better days.\n You have to overcome your past by working with a cartoon character to clear his name of murder.\n",

                "You have traveled back and forth through time learning that changing details\n about the past or future could have dire consequences.\n Having a scientist as a friend helps and learning to choose your reactions\n can make all the difference.\n"
            };

            Random rand = new Random();
            int indexNbr = rand.Next(rooms.Length);

            string room = rooms[indexNbr];

            return room;
        }


    }//end class

}//end namespace
