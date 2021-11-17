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

        public MonsterArea(Vector p, int rad, float eRate, int[] fightables) // all the areas for monsters/travel encounters
        {
            pos = p;
            radius = rad;
            encounterRate = eRate;
            enemies = fightables;
        }

        public static MonsterArea[] areas =
        { // 0.0003f = 0,3% chance pr monster
            new MonsterArea(new Vector(0, 0), 100, 0.0005f, new int[] {7, 8}), // around spawn
            new MonsterArea(new Vector(30, 50), 80, 0.0009f, new int[] {11, 12}),
            new MonsterArea(new Vector(30, 50), 80, 0.00009f, new int[] {13}),
        };
    }
}
