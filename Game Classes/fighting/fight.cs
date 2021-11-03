using System;
using System.Collections.Generic;
using System.Text;
using rpg_game;
using System.Threading;

namespace rpg_game.Game_Classes
{
    class Fight
    {
        public static void update() {
            Fight_Engine.Engine game = new Fight_Engine.Engine(40, 20, "Fight");
            while(true) {
                Console.Clear();
                game.DrawBorder();
                Fight_Engine.FightHelpers.DrawHealthBar(90, 100, 2, 10, ref game);
                game.SwapBuffers();
                game.DrawScreen();
                Thread.Sleep(16);
            }
        }
    }
}
