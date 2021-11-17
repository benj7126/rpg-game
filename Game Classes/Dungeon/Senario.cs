using System;
using System.Collections.Generic;
using System.Text;
using rpg_game.Game_Classes.Dungeon.AllSenarios;

namespace rpg_game.Game_Classes.Dungeon
{
    class senario
    {
        public virtual int onEnter(ref Player plr, int layer)
        {
            return 0;
        }

        public virtual int onLook(ref Player plr, int layer)
        {
            return 0;
        }

        public static List<senario> senarioList = new List<senario>()
        {
            new AlreadyBeenThere(),
            new Exit(),
            new Empty(),
            new Enemy1(),
            new Enemy2(),
            new Chest(),
        };
    }
}
