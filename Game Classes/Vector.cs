using System;
using System.Collections.Generic;
using System.Text;
using rpg_game;

namespace rpg_game.Game_Classes
{
    class Vector
    {
        public int x = 0;
        public int y = 0;

        public Vector(int vectorX, int vectorY)
        {
            x = vectorX;
            y = vectorY;
        }

        public static double distance(Vector pos1, Vector pos2)
        {
            return MathF.Sqrt(MathF.Pow(pos2.x - pos1.x, 2) + MathF.Pow(pos2.y - pos1.y, 2));
        }
    }
}
