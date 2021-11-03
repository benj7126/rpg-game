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
        public gameStates gameState = gameStates.other;
        public Player player = new Player();
        public List<Location> places = new List<Location>();
        public ChoiceSelector Choice = new ChoiceSelector();

        public void updateWorld()
        {
            if (gameState == gameStates.Fighting)
            {

            }
            else if (gameState == gameStates.Traveling)
            {

            }
            else if (gameState == gameStates.Labyrinth)
            {

            }
            else if (gameState == gameStates.other)
            {
                Choice.update();
            }
        }
    }
}
