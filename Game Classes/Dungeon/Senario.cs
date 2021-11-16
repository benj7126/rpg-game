using System;
using System.Collections.Generic;
using System.Text;

namespace rpg_game.Game_Classes.Dungeon
{
    class senario
    {
        public virtual void onEnter()
        {

        }

        public virtual void onLook()
        {

        }

        public static List<senario> senarioList = new List<senario>()
        {

        };
    }
}
