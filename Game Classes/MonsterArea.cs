using System;
using System.Collections.Generic;
using System.Text;
using rpg_game.Game_Classes;

namespace rpg_game.Game_Classes
{
    class MonsterArea
    {
        public Vector pos;
        public int radius;
        public float encounterRate;
        public int[] enemies;

        public MonsterArea(Vector p, int rad, float eRate, int[] fightables)
        {
            pos = p;
            radius = rad;
            encounterRate = eRate;
            enemies = fightables;
        }

        public static MonsterArea[] areas =
        {
            new MonsterArea(new Vector(0, 0), 100, 0.0003f, new int[] {1, 2, 3}),
        };
    }
}
