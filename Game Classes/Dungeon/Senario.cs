using System;
using System.Collections.Generic;
using System.Text;
using rpg_game.Game_Classes.Dungeon.AllSenarios;

namespace rpg_game.Game_Classes.Dungeon
{
    class senario
    {
        public virtual void onEnter(ref Player plr)
        {

        }

        public virtual void onLook(ref Player plr)
        {

        }

        public static List<senario> senarioList = new List<senario>()
        {
            new AlreadyBeenThere(),
            new Empty(),
            new Enemy1(),
        };
    }
}
