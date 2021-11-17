using System;
using System.Threading;
using System.Collections.Generic;
using rpg_game;
using rpg_game.Game_Classes;
using rpg_game.Game_Classes.maze;

namespace rpg_game.Game_Scenes
{
    class maze2 : Scene
    {
        public override bool Start(ref Player plr)
        {
            int[] mapArr = {
                1, 1,   1,   1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
                1, 1,   0,   0, 0, 1, 0, 1, 0, 1, 1, 1, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 1,
                1, 1,   0,   1, 0, 1, 0, 1, 0, 0, 0, 0, 0, 1, 0, 1, 0, 1, 0, 1, 0, 0, 1, 1, 1, 0, 0, 1, 1,
                1, 102, 100, 1, 0, 1, 0, 0, 0, 1, 1, 1, 0, 0, 0, 1, 0, 1, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 101,
                1, 1,   0,   0, 0, 1, 0, 1, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 0, 1, 0, 0, 1, 1, 1, 0, 0, 1, 1,
                1, 1,   0,   0, 0, 0, 0, 1, 0, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1, 1,
                1, 1,   1,   1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
            };
            Map map = new Map(29, 7, mapArr);
            if (Maze.StartMaze(map))
            {
                plr.possibleLocations.Add(Location.getLocationByName("Multi dimensional maze - layer 3"));
                plr.pickupItem(Item.getItemByID(28));
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
