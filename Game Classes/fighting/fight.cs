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

        private static ListItem[] HitLocations = {
            new ListItem("Head"),
            new ListItem("Torso"),
            new ListItem("Legs"),
        };

        private static MenuList menu = new MenuList(HitLocations);


        enum AttackableLocations {
            Head,
            Torso,
            Legs,
            Null
        };
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
                Program.sleep(16);
            }*/

            var player = new Player();
            StartFight(ref player, Enemy.enemies[6]);
        }

        public static bool StartFight(ref Player player, Enemy enemy) {
            Console.WriteLine("A fight is beginning, make sure you've read what you must.\nPress any key to continue");
            Console.ReadKey(true);
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

            FightBeginning(ref game, enemy);
            HandleFight(ref game, ref player, enemy, playerHBCol, enemyHBCol);
            FightEnding(ref game, ref player, enemy);

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
                Program.sleep(tickSpeed);
            }

            bool blink = false;
            while(true) {
                game.DrawText(intro, (game.GetWinWidth()-WrapLength)/2, (game.GetWinHeight() - intro.Length / WrapLength)/2, WrapLength, true);

                blink = !blink;

                if(blink) {
                    string pressKey = "Press any key to continue!";
                    game.DrawText(pressKey, (game.GetWinWidth() - pressKey.Length) / 2, 30);
                    Program.sleep(400);
                } else {
                    Program.sleep(500);
                }

                game.SwapBuffers();
                game.DrawScreen();


                if (Console.KeyAvailable)
                {
                    while (Console.KeyAvailable)
                    {
                        Console.ReadKey();
                    }
                    break;
                }
            }
        }

        private static void HandleFight(ref Engine game, ref Player player, Enemy enemy, HBColor[] playerHB, HBColor[] enemyHB) {
            int enemyHP = enemy.Health;

            bool attacking = true;
            AttackableLocations attackLoc = AttackableLocations.Null;
            AttackableLocations defLoc = AttackableLocations.Null;

            string InfoBox = "";
            while(true) {

                game.DrawText(player.name, 2, 1);
                game.DrawText(enemy.Name, game.GetWinWidth() - enemy.Name.Length - 2, 3);

                FightHelpers.DrawHealthBar(player.health, player.maxHealth, 2, 2, ref game, playerHB);
                FightHelpers.DrawHealthBar(enemyHP, enemy.Health, game.GetWinWidth()-9, 4, ref game, enemyHB);

                game.DrawText(InfoBox, 5, 16, 70);

                if(attacking) {
                    if(attackLoc == AttackableLocations.Null) {
                        attackLoc = PlayerAttack(ref game, player);
                    } else {
                        AttackableLocations def;
                        Random rng = new Random();

                        if(rng.Next(2) == 0) {
                            // Defend head
                            def = AttackableLocations.Head;
                        } else {
                            if (rng.Next(2) == 0) {
                                // Defend torso
                                def = AttackableLocations.Torso;
                            } else {
                                // Defend Legs
                                def = AttackableLocations.Legs;
                            }
                        }

                        bool defended = false;
                        int defaultAtk = player.getAttack();
                        switch(attackLoc) {
                            case AttackableLocations.Head:
                                defaultAtk+=2;
                                break;
                            case AttackableLocations.Torso:
                                defaultAtk+=1;
                                break;
                        }


                        while(Console.KeyAvailable) {
                            Console.ReadKey();
                        }

                        if(attackLoc == def) {
                            defended = true;
                            defaultAtk = 0;
                        }

                        InfoBox = $"You attacked {enemy.Name}'s {attackLoc}. It defended {def}. You therefore dealt {defaultAtk} damage.";

                        //Deal damage to enemy
                        enemyHP -= defaultAtk;

                        menu.Reset();
                        attackLoc = AttackableLocations.Null;
                        attacking = false;
                    }
                } else {
                    if(defLoc == AttackableLocations.Null) {
                        defLoc = PlayerAttack(ref game, player, false);
                    } else {
                        AttackableLocations atk;
                        Random rng = new Random();

                        if(rng.Next(2) == 0) {
                            // Defend head
                            atk = AttackableLocations.Head;
                        } else {
                            if (rng.Next(2) == 0) {
                                // Defend torso
                                atk = AttackableLocations.Torso;
                            } else {
                                // Defend Legs
                                atk = AttackableLocations.Legs;
                            }
                        }

                        bool defended = false;
                        int defaultAtk = enemy.Damage;
                        switch(atk) {
                            case AttackableLocations.Head:
                                defaultAtk+=2;
                                break;
                            case AttackableLocations.Torso:
                                defaultAtk+=1;
                                break;
                        }


                        while(Console.KeyAvailable) {
                            Console.ReadKey();
                        }

                        if(defLoc == atk) {
                            defended = true;
                            defaultAtk = 0;
                        }

                        InfoBox = $"{enemy.Name} attacked your {atk}. You defended {defLoc}. {enemy.Name} therefore dealt {defaultAtk} damage.";
                        //Deal damage to player
                        player.health -= Math.Max(0, defaultAtk - player.getDefence());

                        if (player.health <= 0)
                            player.dead();

                        menu.Reset();
                        defLoc = AttackableLocations.Null;
                        attacking = true;
                    }
                }
                game.SwapBuffers();
                game.DrawScreen();

                if(enemyHP <= 0) {
                    return;
                }
            }
        }

        private static void FightEnding(ref Engine game, ref Player plr, Enemy enemy, int tickSpeed = 50) {
            string lastWords = "";
            int WrapLength = 40;
            for(int i = 0; i < enemy.Last_words.Length; i++) {
                lastWords += enemy.Last_words[i];
                game.DrawText(lastWords, (game.GetWinWidth()-WrapLength)/2, (game.GetWinHeight() - lastWords.Length / WrapLength)/2, WrapLength, true);
                game.SwapBuffers();
                game.DrawScreen();
                Program.sleep(tickSpeed);
            }

            Program.sleep(1000);

            while(Console.KeyAvailable) {
                Console.ReadKey();
            }

            Console.Clear();
            enemy.Drop(ref plr);
        }

        private static AttackableLocations PlayerAttack(ref Engine game, Player player, bool attack = true) {
            string attackText = attack ? "attack" : "defend";
            game.DrawText($"Where do you want to {attackText}?", 2, 6);
            menu.DrawList(ref game, 2, 7);

            game.SwapBuffers();
            game.DrawScreen();

            ListItem attackLoc = HandleInput(ref menu, player);
            AttackableLocations attacked;
            if(attackLoc != null) {
                Enum.TryParse(attackLoc.name, true, out attacked);
                return attacked;
            }

            return AttackableLocations.Null;
        }

        private static ListItem HandleInput(ref MenuList menu, Player player) {
            // The following line stops blocking the executing thread, if no key
            // has been pressed. It has been commented out, since it is no
            // longer useful, but might be later.
            //if (!Console.KeyAvailable) return null;

            ListItem selectedItem = null;

            // Reads and saves pressed key
            ConsoleKeyInfo key = Console.ReadKey();
            // Checks the pressed key. Sends press to menu.
            if(key.Key == Player.up) {
                selectedItem = menu.HandleInput(MenuList.InputType.Up);
            } else if(key.Key == Player.down) {
                selectedItem = menu.HandleInput(MenuList.InputType.Down);
            } else if(key.Key == Player.select) {
                selectedItem = menu.HandleInput(MenuList.InputType.Ok);
            }

            return selectedItem;
        }
    }
}
