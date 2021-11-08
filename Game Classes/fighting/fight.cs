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
            }*/

            var player = new Player();
            StartFight(ref player, Enemy.enemies[1]);
        }

        public static bool StartFight(ref Player player, Enemy enemy) {
            Engine game = new Fight_Engine.Engine(80, 40, "Fighting " + enemy.Name);
            HBColor[] playerHBCol = {
                new HBColor(15, ConsoleColor.Red),
                new HBColor(30, ConsoleColor.Yellow),
                new HBColor(100, ConsoleColor.Green),
            };

            HBColor[] enemyHBCol = {
                new HBColor(100, ConsoleColor.Red),
            };

            Console.Clear();

            //FightBeginning(ref game, enemy);
            HandleFight(ref game, ref player, enemy, playerHBCol, enemyHBCol);
            FightEnding(ref game, enemy);

            return false;
        }

        private static void FightBeginning(ref Engine game, Enemy enemy, int tickSpeed = 50) {
            string intro = "";
            int WrapLength = 40;
            for(int i = 0; i < enemy.Introduction.Length; i++) {
                intro += enemy.Introduction[i];
                game.DrawText(intro, (game.GetWinWidth()-WrapLength)/2, (game.GetWinHeight() - intro.Length / WrapLength)/2, WrapLength, true);
                game.SwapBuffers();
                game.DrawScreen();
                Thread.Sleep(tickSpeed);
            }

            bool blink = false;
            while(true) {
                game.DrawText(intro, (game.GetWinWidth()-WrapLength)/2, (game.GetWinHeight() - intro.Length / WrapLength)/2, WrapLength, true);

                blink = !blink;

                if(blink) {
                    string pressKey = "Press any key to continue!";
                    game.DrawText(pressKey, (game.GetWinWidth() - pressKey.Length) / 2, 30);
                    Thread.Sleep(400);
                } else {
                    Thread.Sleep(500);
                }

                if(Console.KeyAvailable) {
                    break;
                }

                game.SwapBuffers();
                game.DrawScreen();
            }
        }

        private static void HandleFight(ref Engine game, ref Player player, Enemy enemy, HBColor[] playerHB, HBColor[] enemyHB) {
            int enemyHP = enemy.Health;

            ListItem[] controlList = {
                new ListItem("Head"),
                new ListItem("Torso"),
                new ListItem("Legs"),
            };
            MenuList menu = new MenuList(controlList);

            while(true) {
                game.DrawText("playername", 2, 1);
                game.DrawText(enemy.Name, game.GetWinWidth() - enemy.Name.Length - 2, 3);

                FightHelpers.DrawHealthBar(player.health, player.maxHealth, 2, 2, ref game, playerHB);
                FightHelpers.DrawHealthBar(enemyHP, enemy.Health, game.GetWinWidth()-9, 4, ref game, enemyHB);

                game.DrawText("Where do you want to attack?", 2, 6);
                menu.DrawList(ref game, 2, 7);

                game.SwapBuffers();
                game.DrawScreen();

                HandleInput(ref menu, player);
            }
        }

        private static void FightEnding(ref Engine game, Enemy enemy, int tickSpeed = 50) {
            string lastWords = "";
            int WrapLength = 40;
            for(int i = 0; i < enemy.Last_words.Length; i++) {
                lastWords += enemy.Last_words[i];
                game.DrawText(lastWords, (game.GetWinWidth()-WrapLength)/2, (game.GetWinHeight() - lastWords.Length / WrapLength)/2, WrapLength, true);
                game.SwapBuffers();
                game.DrawScreen();
                Thread.Sleep(tickSpeed);
            }

            Thread.Sleep(1000);
        }

        private static void HandleInput(ref MenuList menu, Player player) {
            // The following line stops blocking the executing thread, if no key
            // has been pressed.
            //if (!Console.KeyAvailable) return;

            // Reads and saves pressed key
            ConsoleKeyInfo key = Console.ReadKey();
            // Checks the pressed key. Sends press to menu.
            if(key.Key == player.up) {
                menu.HandleInput(MenuList.InputType.Up);
            } else if(key.Key == player.down) {
                menu.HandleInput(MenuList.InputType.Down);
            } else if(key.Key == player.select) {
                menu.HandleInput(MenuList.InputType.Ok);
            }
        }
    }
}
