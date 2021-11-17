using System;
using System.Collections.Generic;
using System.Text;

namespace rpg_game.Game_Classes.Dungeon.AllSenarios
{
    class Chest : senario
    {
        public override int onEnter(ref Player plr, int layer)
        {
            drop[] drops;
            Item item;
            if (layer < 4)
            {
                Random r = new Random();
                if (r.Next(2) == 0)
                    item = Item.getItemByID(30);
                else
                    item = Item.getItemByID(31);
                drops = new drop[] { new drop(Item.getItemByID(10), 0.5f), new drop(Item.getItemByID(11), 0.3f), new drop(Item.getItemByID(30), 0.2f), new drop(Item.getItemByID(31), 0.2f), new drop(Item.getItemByID(32), 0.2f) };
            }
            else if(layer < 8)
            {
                Random r = new Random();
                if (r.Next(2) == 0)
                    item = Item.getItemByID(31);
                else
                    item = Item.getItemByID(32);
                drops = new drop[] { new drop(Item.getItemByID(10), 0.7f), new drop(Item.getItemByID(11), 0.4f), new drop(Item.getItemByID(30), 0.6f), new drop(Item.getItemByID(31), 0.6f), new drop(Item.getItemByID(32), 0.6f) };
            }
            else
            {
                Random r = new Random();
                if (r.Next(2) == 0)
                    item = Item.getItemByID(32);
                else
                    item = Item.getItemByID(34);
                drops = new drop[] { new drop(Item.getItemByID(10), 1f), new drop(Item.getItemByID(11), 0.6f), new drop(Item.getItemByID(30), 0.6f), new drop(Item.getItemByID(31), 0.6f), new drop(Item.getItemByID(32), 0.6f), , new drop(Item.getItemByID(34), 0.3f) };
            }

            Program.print("You walk into the room to confirm you suspitions, and you are confronted with a chest, nothing else. The chest is standing in the middle of the room.");
            ChoiceSelector CS = new ChoiceSelector();
            if (CS.update(ref plr, new List<string>() { "Yes", "No" }, "Wanna try to open it?") == 0)
            {
                Random r = new Random();
                int rNr = r.Next(3);
                if (rNr == 0)
                {
                    Program.print("You step closer to the chest, and reach your hand for it...");
                    Program.print("The chest is shut tight, and you cant get it open, you therefore leave it behind.");

                }
                else if (rNr == 1)
                {
                    Program.print("You step closer to the chest, and reach your hand for it...");
                    Program.print("You drag your hand away, IT BITES!");
                    Fight.StartFight(ref plr, new Enemy("Mimic", "*Chomp* *Chomp*", 50 + layer, 10 + layer * 2, 0, "*Wood Cracking*", drops));
                }
                else
                {
                    Program.print("You step closer to the chest, and reach your hand for it...");
                    Program.print("The chesst opens smoothly.");
                    plr.pickupItem(item);

                }
                return 0;
            }
            else
            {
                Program.print("Better not take the chance, you tell yourself.");
                return -1;
            }
        }

        public override int onLook(ref Player plr, int layer)
        {
            Program.print("You look into the room, there dosen't seem to be any sort of movement, but there is a chest conspicuously placed in the middle of the room.");
            return 0;
        }
    }
}
