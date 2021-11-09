using System;
using System.Collections.Generic;
using System.Text;
using rpg_game;
using System.Threading;
using System.Linq;

namespace rpg_game.Game_Classes.maze
{
    class Map {
        int width, height;
        public int Width{get => width;}
        public int Height{get => height;}
        List<int> map = new List<int>();

        public Map(int sizeX, int sizeY) {
            width = sizeX;
            height = sizeY;

            map = new int[width * height].ToList();
        }

        public Map(int sizeX, int sizeY, int[] map) {
            width = sizeX;
            height = sizeY;

            this.map = map.ToList();
        }

        public int GetCell(int x, int y) {
            return map[x + y * width];
        }

        public void SetCell(int x, int y, int cell) {
            map[x + y * width] = cell;
        }
    }
}
