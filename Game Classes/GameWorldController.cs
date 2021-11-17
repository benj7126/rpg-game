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
        // the core of the game
        public gameStates gameState = gameStates.StartScreen; // this discripes where the game is at...
        public Player player = new Player();
        public List<Location> knownPlaces = new List<Location>();
        public Travel curTravel = new Travel();


        public bool updateWorld() // this is looped while the game is active, kinda feel like it makes fine sence...
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
                        usableLocations.Add(player.possibleLocations[i]);
                        Choices.Add(player.possibleLocations[i].name + " - " + MathF.Floor(Vector.distance(player.possibleLocations[i].pos, player.pos)) + "m");
                    }
                    Choices.Add("Back");

                    chosen = Choice.update(ref player, Choices, "Where to go next?");

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

                    chosen = Choice.update(ref player, Choices, "What to do now?");

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
                    Choices.Add("Text speed");
                    Choices.Add("Back");

                    chosen = Choice.update(ref player, Choices, "Options:");

                    switch (chosen)
                    {
                        case 0:
                            controls();
                            break;
                        case 1:
                            speed();
                            break;
                        case 2:
                            gameState = gameStates.Other;
                            break;
                    }
                    break;
                case gameStates.StartScreen: // where the game starts
                    Program.print("What is your name player?");
                    Console.Write("My name is ");
                    player.name = Console.ReadLine();

                    bool doContinue = true;

                    Choices.Add("Controls");
                    Choices.Add("Text speed");
                    Choices.Add("Start");

                    while (doContinue)
                    {
                        chosen = Choice.update(ref player, Choices, "Options:");
                        switch (chosen)
                        {
                            case 0:
                                controls();
                                break;
                            case 1:
                                speed();
                                break;
                            case 2: // del
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
            return player.win;
        }
        public void controls() // edid player controls
        {
            Console.Write("Up - ");
            Player.up = Console.ReadKey(true).Key;
            Console.WriteLine(Player.up);


            Console.Write("Down - ");
            Player.down = Console.ReadKey(true).Key;
            Console.WriteLine(Player.down);

            Console.Write("Left - ");
            Player.left = Console.ReadKey(true).Key;
            Console.WriteLine(Player.left);


            Console.Write("Right - ");
            Player.right = Console.ReadKey(true).Key;
            Console.WriteLine(Player.right);


            Console.Write("Select - ");
            Player.select = Console.ReadKey(true).Key;
            Console.WriteLine(Player.select);


            Console.Write("Delete - ");
            Player.del = Console.ReadKey(true).Key;
            Console.WriteLine(Player.del);
        }
        public void speed() // edit speed of game text
        {
            Console.WriteLine("Lower procent = faster text, 0 is the same as instant but not recomended\nsince you might come to regret half skipping some of the story and therefore missing some items\n");
            bool changing = true;
            while (changing)
            {
                Console.WriteLine("Text speed is currently at " + MathF.Round(Player.textSpeedMulti * 100) + "%    ");
                ConsoleKey ck = Console.ReadKey(true).Key; // B - wait for the next key and do stuff based on what was pressed
                if (Player.up == ck)
                {
                    Player.textSpeedMulti = MathF.Min(Player.textSpeedMulti + 0.01f, 2f);
                }
                else if (Player.down == ck)
                {
                    Player.textSpeedMulti = MathF.Max(Player.textSpeedMulti-0.01f, 0f);
                }
                else if (Player.select == ck)
                {
                    changing = false;
                }
                Console.CursorTop = Console.CursorTop - 1;
            }
            Console.CursorTop = Console.CursorTop + 1;
        }
    }
}