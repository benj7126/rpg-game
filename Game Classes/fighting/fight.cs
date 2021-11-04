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
            HBColor[] playerHBCol = {
                new HBColor(15, ConsoleColor.Red),
                new HBColor(30, ConsoleColor.Yellow),
                new HBColor(80, ConsoleColor.Green),
            };

            HBColor[] enemyHBCol = {
                new HBColor(80, ConsoleColor.Red),
            };

            string WrittenText = "";

            while(true) {
                Console.Clear();
                game.DrawBorder();
                FightHelpers.DrawHealthBar(hp, 305, 10, 20, ref game, playerHBCol, true);
                FightHelpers.DrawHealthBar(hp, 305, 2, 10, ref game, enemyHBCol);

                hp = hp < 0 ? 305 : hp-1;

                game.DrawText(enemy.enemys[1].Introduction, 5, 25, 20, true);
                game.DrawText("testing", 5, 15, box:true);

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    WrittenText += key.KeyChar;
                }

                game.DrawText(WrittenText, 2, 2, 20, true);

                game.SwapBuffers();
                game.DrawScreen();
                Thread.Sleep(16);
            }
        }
    }
}
