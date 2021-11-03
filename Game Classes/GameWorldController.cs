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
        other
    }

    class GameWorldController
    {
        public gameStates gameState = gameStates.Traveling;
        public Player player = new Player();
        public List<Location> knownPlaces = new List<Location>();
        public ChoiceSelector Choice = new ChoiceSelector();
        public Travel curTravel = new Travel();


        public void updateWorld()
        {
            if (gameState == gameStates.Fighting)
            {

            }
            else if (gameState == gameStates.Traveling)
            {
                Travel curTravel = new Travel();
                curTravel.run(ref player, Location.locations[1]);
            }
            else if (gameState == gameStates.Labyrinth)
            {

            }
            else if (gameState == gameStates.other)
            {
                Choice.update(ref player, ref gameState);
            }
        }
    }
}
