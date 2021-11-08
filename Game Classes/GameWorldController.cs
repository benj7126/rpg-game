using System;
using System.Collections.Generic;
using System.Text;
using rpg_game;

namespace rpg_game.Game_Classes
{
    public enum gameStates
    {
        Fighting,
        Traveling,
        Labyrinth,
        Other,
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
                                Choices.Add(player.possibleLocations[i].name);
                            }
                        }
                        else
                        {
                            usableLocations.Add(player.possibleLocations[i]);
                            Choices.Add(player.possibleLocations[i].name);
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
                    Choices.Add("Options");

                    chosen = Choice.update(ref player, ref gameState, Choices, "What to do now?");

                    switch (chosen)
                    {
                        case 0:
                            gameState = gameStates.Traveling;
                            break;
                        case 1:
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


                            Console.Write("Select - ");
                            player.select = Console.ReadKey(true).Key;
                            Console.WriteLine(player.select);

                            break;
                        case 1:
                            gameState = gameStates.Other;
                            break;
                    }
                    break;
            }
            Console.WriteLine("");
        }
    }
}
