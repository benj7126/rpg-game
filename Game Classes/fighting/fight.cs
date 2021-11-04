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
                game.DrawBorder();
                game.SetLineColor(10, ConsoleColor.Red);
                Fight_Engine.FightHelpers.DrawHealthBar(hp, 305, 2, 10, ref game);
                game.SetLineColor(20, ConsoleColor.Green);
                Fight_Engine.FightHelpers.DrawHealthBar(hp, 305, 10, 20, ref game);
                game.DrawBox(9, 19, 20, 21, false);

                hp = hp < 0 ? 305 : hp-1;

                game.DrawBox(4, 24, 26, 30, true);
                game.DrawText(enemy.enemys[1].Introduction, 5, 25, 20);
                game.SwapBuffers();
                game.DrawScreen();
                Thread.Sleep(16);
            }
        }
    }
}
