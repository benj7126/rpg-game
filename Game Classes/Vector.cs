using System;
using System.Collections.Generic;
using System.Text;
using rpg_game;

namespace rpg_game.Game_Classes
{
    class Vector
    {
        public float x = 0;
        public float y = 0;

        public Vector(float vectorX, float vectorY)
        {
            x = vectorX;
            y = vectorY;
        }

        public static float distance(Vector pos1, Vector pos2)
        {
            return MathF.Sqrt(MathF.Pow(pos2.x - pos1.x, 2) + MathF.Pow(pos2.y - pos1.y, 2));
        }

        public void moveTowards(Vector moveTowardsPos, float dist)
        {
            float distBetween = distance(moveTowardsPos, new Vector(x, y));

            x -= (x - moveTowardsPos.x) / distBetween * dist;
            y -= (y - moveTowardsPos.y) / distBetween * dist;
        }
    }
}
