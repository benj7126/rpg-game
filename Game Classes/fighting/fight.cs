using System;
using System.Collections.Generic;
using System.Text;
using rpg_game;
using System.Threading;
using Fight_Engine;

namespace rpg_game.Game_Classes
{
    class Fight
    {
        public static void update() {
            Engine game = new Fight_Engine.Engine(80, 40, "Fight");
            int hp = 305;
            while(true) {
                Console.Clear();
                game.DrawBorder();
                HBColor[] enemyHBCol = {
                    new HBColor(80, ConsoleColor.Red),
                };
                FightHelpers.DrawHealthBar(hp, 305, 2, 10, ref game, enemyHBCol);

                HBColor[] playerHBCol = {
                    new HBColor(15, ConsoleColor.Red),
                    new HBColor(30, ConsoleColor.Yellow),
                    new HBColor(80, ConsoleColor.Green),
                };
                FightHelpers.DrawHealthBar(hp, 305, 10, 20, ref game, playerHBCol, true);

                hp = hp < 0 ? 305 : hp-1;

                game.DrawText(enemy.enemys[1].Introduction, 5, 25, 20, true);
                game.DrawText("testing", 5, 15, box:true);

                game.SwapBuffers();
                game.DrawScreen();
                Thread.Sleep(16);
            }
        }
    }
}
