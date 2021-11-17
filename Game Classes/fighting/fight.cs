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

        // This function starts a fight between the player and an enemy.
        public static bool StartFight(ref Player player, Enemy enemy) {
            // Give player a warning, since fight clears screen.
            Console.WriteLine("A fight is beginning, make sure you've read what you must.\nPress any key to continue");
            Console.ReadKey(true);

            // Create an instance of the fight engine.
            Engine game = new Fight_Engine.Engine(80, 40, "Fighting " + enemy.Name);

            // Holds color of player healthbar, depending on health percentage.
            HBColor[] playerHBCol = {
                new HBColor(15, ConsoleColor.Red),
                new HBColor(30, ConsoleColor.Yellow),
                new HBColor(100, ConsoleColor.Green),
            };

            // Holds color of enemy healthbar, depending on health percentage.
            HBColor[] enemyHBCol = {
                new HBColor(100, ConsoleColor.Red),
            };

            // Clear console in advance.
            Console.Clear();

            // FightBeginning runs before fight, showing the enemy introduction text.
            FightBeginning(ref game, enemy);
            // HandleFight runs the actual fight.
            HandleFight(ref game, ref player, enemy, playerHBCol, enemyHBCol);
            // FightEnding runs after the fight, showing the enemy's last words.
            FightEnding(ref game, ref player, enemy);

            return false;
        }

        // FightBeginning runs before fight, showing the enemy introduction text.
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

            // Shows blinking text, saying "Press any key to continue!".
            bool blink = false;
            while(true) {
                // Draws enemy introduction text, every frame.
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

                // Remove queued keypresses.
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

        // HandleFight runs the actual fight.
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

        // FightEnding runs after the fight, showing the enemy's last words.
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
