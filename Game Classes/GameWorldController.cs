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
        Optoions
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
                    for (int i = 0; i < player.possibleLocations.Count; i++)
                    {
                        Choices.Add(player.possibleLocations[i].name);
                    }
                    Choices.Add("Back");

                    chosen = Choice.update(ref player, ref gameState, Choices, "Where to go next?");

                    if (chosen != player.possibleLocations.Count)
                    {
                        Travel curTravel = new Travel();
                        curTravel.run(ref player, Location.locations[1]);
                    }
                    else
                    {
                        Console.Clear();
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
                            gameState = gameStates.Optoions;
                            break;
                    }
                    Console.Clear();
                    break;
                case gameStates.Optoions:
                    break;
            }
        }
    }
}
