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
            Fight_Engine.Engine game = new Fight_Engine.Engine(80, 40, "Fight");
            int hp = 305;
            while(true) {
                Console.Clear();
                game.SetLineColor(10, ConsoleColor.Red);
                Fight_Engine.FightHelpers.DrawHealthBar(hp, 305, 2, 10, ref game);
                game.SetLineColor(20, ConsoleColor.Green);
                Fight_Engine.FightHelpers.DrawHealthBar(hp, 305, 10, 20, ref game);
                hp = hp < 0 ? 0 : hp-1;
                game.SwapBuffers();
                game.DrawScreen();
                Thread.Sleep(16);
            }
        }
    }
}
