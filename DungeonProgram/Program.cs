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


            Console.Beep(587, 100);
            Console.Beep(1174, 100);
            Console.Beep(880, 100);
            Console.Beep(784, 100);
            Console.Beep(1568, 100);
            Console.Beep(880, 100);
            Console.Beep(1480, 100);
            Console.Beep(880, 100);
            Console.Beep(587, 100);
            Console.Beep(1174, 100);
            Console.Beep(880, 100);
            Console.Beep(784, 100);
            Console.Beep(1568, 100);
            Console.Beep(880, 100);
            Console.Beep(1480, 100);
            Console.Beep(880, 100);
            Console.Beep(587, 100);
            Console.Beep(1174, 100);
            Console.Beep(880, 100);
            Console.Beep(784, 100);
            Console.Beep(1568, 100);
            Console.Beep(880, 100);
            Console.Beep(1480, 100);
            Console.Beep(880, 100);



            Console.Title = "Detention in a Library";


            Console.WriteLine("The 80's\n");

            int score = 0;

            //TODO 1. Create a weapon for player

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

            Weapon[] reaps = {wp1, wp2, wp3, wp4, wp5, wp6, wp7, wp8, wp9, wp10, wp11};

            Random rando = new Random();
            int randomWpn = rando.Next(reaps.Length);
            Weapon reap = reaps[randomWpn];


            //TODO 2. Create a player



            Player player = new Player("You", 100, 0, 90, 100, Type.MartyMcFly, reap);
         
            //TODO 3. Add customization based on player race

            //TODO 4. Create a loop for the Room

            bool exit = false;

            do
            {
                //TODO 5. Get a room description from a method that generates

                Console.WriteLine(GetRoom());

                //TODO 6. Create a monster in the room for the player

                Guys bg1 = new Guys();
                Guys bg2 = new Guys("Chucky", 40, 50, 40, 20, 1, 10, "Possessed Good Guy Doll", false);
                Guys bg3 = new Guys("Predator", 70, 80, 70, 35, 1, 20, "Space Explorer", true);
                Guys bg4 = new Guys("Hans Gruber", 20, 30, 15, 15, 1, 5, "German Terrorist", true);
                Guys bg5 = new Guys("Jason Voorhes", 60, 70, 60, 30, 1, 20, "Camp Cook", false);
                Guys bg6 = new Guys("Freddy Krueger", 60, 70, 60, 30, 1, 20, "Spirit of a Serial Killer", false);
                Guys bg7 = new Guys("Lo Pan", 50, 60, 50, 25, 1, 18, "Oriental Sorcerer", true);
                Guys bg8 = new Guys("The Fratellis", 30, 40, 30, 15, 1, 10, "The outlaw family of the Boondocks", true);
                Guys bg9 = new Guys("Darth Vader", 80, 100, 80, 40, 1, 25, "Cyborg chief enforcer of the Galactic Empire", false);
               
                //Store them in a collection

                Guys[] badGuys = { bg1, bg2, bg3, bg4, bg5, bg6, bg7, bg8, bg9 };

                //randomly selecting a monster for the room

                Random rand = new Random();
                int randomNbr = rand.Next(badGuys.Length);
                Guys badGuy = badGuys[randomNbr];

                Console.WriteLine("\nIn this room: \n\n" + badGuy.Name);

                //TODO 7. Create a loop for the user choice menu
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

                    //TODO 16. Check the players life
                    if (player.Life <= 0)
                    {
                        Console.WriteLine("\nYou are Awesome!\n Psych Dude you Died!");
                        exit = true;
                    }

                } while (!exit && !reload);
                //}while (exit == false && reload == false)


            } while (!exit);
            //}while(exit == false)     

            //TODO 17. Show Player how many monsters they defeated
            Console.WriteLine("You defeated " + score + "\n 80's BadGuys" + (score == 1 ? "." : "s."));


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
