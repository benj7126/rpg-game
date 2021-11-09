using System;
using System.Collections.Generic;
using System.Text;

namespace rpg_game.Game_Classes
{
    class InvScreen
    {
        public List<string> options = new List<string>();
        public int optionSelected = 0;
        public Dictionary<int, Player.itemPlace> convert = new Dictionary<int, Player.itemPlace>();
        public InvScreen()
        {
            convert.Add(-1, Player.itemPlace.Ring);
            convert.Add(-2, Player.itemPlace.Amulet);
            convert.Add(-3, Player.itemPlace.Armor);
            convert.Add(-4, Player.itemPlace.OffHand);
            convert.Add(-5, Player.itemPlace.MainHand);
        }
        public void inv(ref Player player)
        {
            Console.Clear();
            bool inInv = true;
            int selected = 0; // where the cursor is
            while (inInv)
            {
                Console.CursorTop = 0;
                Console.CursorLeft = 0;

                if (selected == -5)
                    Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("Main hand > ");
                Console.Write(player.equipped[Player.itemPlace.MainHand] != null ? player.equipped[Player.itemPlace.MainHand].name : "                                                                ");
                Console.ForegroundColor = ConsoleColor.White;
                if (selected == -4)
                    Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("\nOff hand > ");
                Console.Write(player.equipped[Player.itemPlace.OffHand] != null ? player.equipped[Player.itemPlace.OffHand].name : "                                                                ");
                Console.ForegroundColor = ConsoleColor.White;
                if (selected == -3)
                    Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("\nArmor > ");
                Console.Write(player.equipped[Player.itemPlace.Armor] != null ? player.equipped[Player.itemPlace.Armor].name : "                                                                ");
                Console.ForegroundColor = ConsoleColor.White;
                if (selected == -2)
                    Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("\nAmulet > ");
                Console.Write(player.equipped[Player.itemPlace.Amulet] != null ? player.equipped[Player.itemPlace.Amulet].name : "                                                                ");
                Console.ForegroundColor = ConsoleColor.White;
                if (selected == -1)
                    Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("\nRing > ");
                Console.Write(player.equipped[Player.itemPlace.Ring] != null ? player.equipped[Player.itemPlace.Ring].name : "                                                                ");
                Console.ForegroundColor = ConsoleColor.White;

                Console.Write("\n\n");

                int wrap = 0;
                for (int i = 0; i<12; i++)
                {
                    if (wrap == 4)
                    {
                        wrap = 0;
                        Console.Write("                                                                \n");
                    }
                    string str = "";
                    if (player.inventory[i] != null)
                    {
                        string addStr = "";
                        if (player.inventory[i].name.Length < 20)
                        {
                            for (int i2 = 0; i2< 20-player.inventory[i].name.Length; i2+=2)
                            {
                                addStr += " ";
                            }
                        }

                        str = "  [" + addStr + player.inventory[i].name + addStr + "] ";
                    }
                    else
                    {
                        str = "  [                    ] ";
                    }
                    if (selected == i)
                    {
                        str = "> " + str.Substring(2, str.Length-2);
                        Console.ForegroundColor = ConsoleColor.Cyan;
                    }
                    Console.Write(str);
                    Console.ForegroundColor = ConsoleColor.White;
                    wrap += 1;
                }

                Console.Write("                                                                \n\n");
                if (selected == 12)
                    Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write(selected == 12 ? "> Back    " : "  Back    ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("                                                                \n\n");

                Item item = null;

                if (selected >= 0)
                {
                    if (selected != 12)
                        item = player.inventory[selected];
                }
                else
                {
                    item = player.equipped[convert[selected]];
                }

                if (item != null)
                {
                    Console.WriteLine(item.name + "                                                                ");
                    Console.WriteLine(Program.convertToLen(item.description, 60) + "                                                                ");

                    Console.WriteLine("Damage: " + item.damage + "                                                                ");
                    Console.WriteLine("Defence: " + item.defence + "                                                                ");
                    if (selected >= 0)
                        if (selected != 12)
                            Console.WriteLine("\nPress [" + Player.del + "] to throw away");
                }



                // make sure that the text dose not linger
                for (int i = 0; i < 20; i++)
                    Console.Write("                                                                           ");

                ConsoleKey ck = Console.ReadKey(true).Key;
                if (Player.up == ck)
                {
                    if (selected < 1)
                    {
                        selected = Math.Max(-5, selected - 1);
                    }
                    else
                    {
                        selected = Math.Max(-5, selected - 4);
                    }
                }
                else if (Player.down == ck)
                {
                    if (selected < 0)
                    {
                        selected = Math.Min(12, selected + 1);
                    }
                    else
                    {
                        selected = Math.Min(12, selected + 4);
                    }
                }
                else if (Player.left == ck)
                {
                    if (selected > -1)
                        selected = Math.Max(0, selected - 1);
                }
                else if (Player.right == ck)
                {
                    selected = Math.Min(12, selected + 1);
                }
                else if (Player.select == ck)
                {

                    if (selected >= 0)
                    {
                        if (selected == 12)
                        {
                            inInv = false;
                        }
                        else
                        {
                            if (player.inventory[selected] != null)
                                player.inventory[selected].equip(ref player, selected);
                        }
                    }
                    else
                    {
                        if (player.equipped[convert[selected]] != null)
                            player.equipped[convert[selected]].unequip(ref player);
                    }
                }
                else if (Player.del == ck)
                {
                    if (selected != 12)
                    {
                        if (player.inventory[selected] != null)
                            player.inventory[selected].remove(ref player, selected);
                    }
                }
            }
        }
    }
}
