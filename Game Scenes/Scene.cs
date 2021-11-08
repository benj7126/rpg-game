using System;
using System.Collections.Generic;
using System.Text;
using rpg_game.Game_Classes;

namespace rpg_game.Game_Scenes
{
    abstract class Scene
    {
        public abstract void Start(ref Player plr);
    }
}
