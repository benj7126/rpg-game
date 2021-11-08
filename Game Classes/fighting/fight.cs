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
            /*
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

            ListItem[] controlList = {
                new ListItem("Fight"),
                new ListItem("Defend"),
                new ListItem("Run Away (coward)"),
            };

            MenuList menu = new MenuList(controlList);

            while(true) {
                HandleInput(ref menu);
                game.DrawBorder();
                FightHelpers.DrawHealthBar(hp, 305, 10, 20, ref game, playerHBCol, true);
                FightHelpers.DrawHealthBar(hp, 305, 2, 10, ref game, enemyHBCol);

                hp = hp < 0 ? 305 : hp-1;

                game.DrawText(Enemy.enemies[1].Introduction, 5, 25, 20, true);
                game.DrawText("testing", 5, 15, box:true);

                menu.DrawList(ref game, 3, 32);

                game.SwapBuffers();
                Console.Clear();
                game.DrawScreen();
                Thread.Sleep(16);
            }
            */

            var player = new Player();
            StartFight(ref player, Enemy.enemies[1]);
        }

        public static bool StartFight(ref Player player, Enemy enemy) {
            Engine game = new Fight_Engine.Engine(80, 40, "Fighting " + enemy.Name);
            HBColor[] playerHBCol = {
                new HBColor(15, ConsoleColor.Red),
                new HBColor(30, ConsoleColor.Yellow),
                new HBColor(80, ConsoleColor.Green),
            };

            HBColor[] enemyHBCol = {
                new HBColor(80, ConsoleColor.Red),
            };

            ListItem[] controlList = {
                new ListItem("Fight"),
                new ListItem("Defend"),
                new ListItem("Run Away (coward)"),
            };

            MenuList menu = new MenuList(controlList);

            FightBeginning(ref game, enemy);

            return false;
        }

        private static void FightBeginning(ref Engine game, Enemy enemy) {
            string intro = "";
            int WrapLength = 40;
            for(int i = 0; i < enemy.Introduction.Length; i++) {
                intro += enemy.Introduction[i];
                game.DrawText(intro, (game.GetWinWidth()-WrapLength)/2, (game.GetWinHeight() - intro.Length / WrapLength)/2, WrapLength, true);
                game.SwapBuffers();
                Console.Clear();
                game.DrawScreen();
                Thread.Sleep(50);
            }
        }

        private static void HandleInput(ref MenuList menu) {
            // The following line stops blocking the executing thread, if no key
            // has been pressed.
            if (!Console.KeyAvailable) return;

            // Reads and saves pressed key
            ConsoleKeyInfo key = Console.ReadKey(true);
            // Checks the pressed key. Sends press to menu.
            switch(key.Key) {
                // Handle arrow keys + enter & escape
                case ConsoleKey.UpArrow:
                    menu.HandleInput(MenuList.InputType.Up);
                    break;
                case ConsoleKey.DownArrow:
                    menu.HandleInput(MenuList.InputType.Down);
                    break;
                case ConsoleKey.Enter:
                    menu.HandleInput(MenuList.InputType.Ok);
                    break;
                case ConsoleKey.Escape:
                    menu.HandleInput(MenuList.InputType.Cancel);
                    break;
                // Also handle vim-keys
                case ConsoleKey.J:
                    menu.HandleInput(MenuList.InputType.Down);
                    break;
                case ConsoleKey.K:
                    menu.HandleInput(MenuList.InputType.Up);
                    break;
                case ConsoleKey.L:
                    menu.HandleInput(MenuList.InputType.Ok);
                    break;
                case ConsoleKey.H:
                    menu.HandleInput(MenuList.InputType.Cancel);
                    break;
            }
        }
    }
}
