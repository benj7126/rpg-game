using System;
using System.Collections.Generic;
using System.Text;
using rpg_game;

namespace rpg_game.Game_Classes
{
    public enum gameStates
    {
        Fighting,
        StartScreen,
        Traveling,
        Labyrinth,
        Other,
        Inv,
        Options
    }

    class GameWorldController
    {
        public gameStates gameState = gameStates.Other;
        public Player player = new Player();
        public List<Location> knownPlaces = new List<Location>();
        public Travel curTravel = new Travel();


        public void updateWorld()
        {
            int chosen = 0;
            ChoiceSelector Choice = new ChoiceSelector();
            List<string> Choices = new List<string>();
            switch (gameState)
            {
                case gameStates.Fighting:
                    break;
                case gameStates.Traveling:
                    List<Location> usableLocations = new List<Location>();
                    for (int i = 0; i < player.possibleLocations.Count; i++)
                    {
                        if (player.playerLocation != null)
                        {
                            if (player.possibleLocations[i].name != player.playerLocation.name)
                            {
                                usableLocations.Add(player.possibleLocations[i]);
                                Choices.Add(player.possibleLocations[i].name + " - " + MathF.Floor(Vector.distance(player.possibleLocations[i].pos, player.pos)) + "m");
                            }
                        }
                        else
                        {
                            usableLocations.Add(player.possibleLocations[i]);
                            Choices.Add(player.possibleLocations[i].name + " - " + MathF.Floor(Vector.distance(player.possibleLocations[i].pos, player.pos)) + "m");
                        }
                    }
                    Choices.Add("Back");

                    chosen = Choice.update(ref player, ref gameState, Choices, "Where to go next?");

                    if (chosen != usableLocations.Count)
                    {
                        Travel curTravel = new Travel();
                        curTravel.run(ref player, usableLocations[chosen]);
                        gameState = gameStates.Other;
                    }
                    else
                    {
                        gameState = gameStates.Other;
                    }
                    break;
                case gameStates.Labyrinth:
                    break;
                case gameStates.Other:
                    Choices.Add("Travel");
                    Choices.Add("Manage inventory");
                    Choices.Add("Options");

                    chosen = Choice.update(ref player, ref gameState, Choices, "What to do now?");

                    switch (chosen)
                    {
                        case 0:
                            gameState = gameStates.Traveling;
                            break;
                        case 1:
                            gameState = gameStates.Inv;
                            break;
                        case 2:
                            gameState = gameStates.Options;
                            break;
                    }
                    break;
                case gameStates.Options:
                    Choices.Add("Controls");
                    Choices.Add("Back");

                    chosen = Choice.update(ref player, ref gameState, Choices, "Options:");

                    switch (chosen)
                    {
                        case 0:

                            Console.Write("Up - ");
                            player.up = Console.ReadKey(true).Key;
                            Console.WriteLine(player.up);


                            Console.Write("Down - ");
                            player.down = Console.ReadKey(true).Key;
                            Console.WriteLine(player.down);

                            Console.Write("Left - ");
                            player.left = Console.ReadKey(true).Key;
                            Console.WriteLine(player.left);


                            Console.Write("Right - ");
                            player.right = Console.ReadKey(true).Key;
                            Console.WriteLine(player.right);


                            Console.Write("Select - ");
                            player.select = Console.ReadKey(true).Key;
                            Console.WriteLine(player.select);

                            break;
                        case 1:
                            gameState = gameStates.Other;
                            break;
                    }
                    break;
                case gameStates.StartScreen:
                    Program.print("What is your name player?");
                    Console.Write("My name is ");
                    player.name = Console.ReadLine();

                    bool doContinue = true;

                    Choices.Add("Controls");
                    Choices.Add("Start");

                    while (doContinue)
                    {
                        chosen = Choice.update(ref player, ref gameState, Choices, "Options:");
                        switch (chosen)
                        {
                            case 0:

                                Console.Write("Up - ");
                                player.up = Console.ReadKey(true).Key;
                                Console.WriteLine(player.up);


                                Console.Write("Down - ");
                                player.down = Console.ReadKey(true).Key;
                                Console.WriteLine(player.down);

                                Console.Write("Left - ");
                                player.left = Console.ReadKey(true).Key;
                                Console.WriteLine(player.left);


                                Console.Write("Right - ");
                                player.right = Console.ReadKey(true).Key;
                                Console.WriteLine(player.right);


                                Console.Write("Select - ");
                                player.select = Console.ReadKey(true).Key;
                                Console.WriteLine(player.select);

                                break;
                            case 1:
                                doContinue = false;
                                break;
                        }
                    }

                    Game_Scenes.Beginning scene = new Game_Scenes.Beginning();
                    scene.Start(ref player);
                    gameState = gameStates.Other;
                    break;
                case gameStates.Inv:
                    InvScreen invS = new InvScreen();
                    invS.inv(ref player);
                    Console.Clear();
                    gameState = gameStates.Other;
                    break;
            }
            Console.WriteLine("");
        }
    }
}
