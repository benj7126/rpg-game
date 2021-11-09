using System;
using System.Collections.Generic;
using System.Text;
using rpg_game;
using System.Threading;
using System.Linq;

namespace rpg_game.Game_Classes.maze
{
    class MazeEngine {
        GameParams parameters = new GameParams();

        List<char> buffer1;
        List<char> buffer2;

        bool firstBuffer = true;

        public MazeEngine(int win_width, int win_height, string game_name) {
            char[] tmp = new char[win_width * win_height];
            buffer1 = tmp.ToList();
            buffer2 = tmp.ToList();
            parameters.winWidth = win_width;
            parameters.winHeight = win_height;
            parameters.name = game_name;

            Console.Title = game_name;
        }

        public int GetWinWidth() { return parameters.winWidth; }
        public int GetWinHeight() { return parameters.winHeight; }

        public void DrawChar(char ch, int x, int y) {
            if (x < 0 || x > GetWinWidth() || y < 0 || y > GetWinHeight()) {
                throw new ArgumentOutOfRangeException();
            }

            if(!firstBuffer) {
                DrawToFramebuffer(ch, x, y, ref buffer1);
            } else {
                DrawToFramebuffer(ch, x, y, ref buffer2);
            }
        }

        public void DrawVerLine(int x, int height) {
            height = height > GetWinHeight() ? GetWinHeight() : height;
            if (x < 0 || x > GetWinWidth()) {
                throw new ArgumentOutOfRangeException();
            }

            int startY = GetWinHeight()/2 - height/2;
            for(int i = 0; i < height; i++) {
                DrawChar('█', x, startY+i);
            }
        }

        public void DrawBorder() {
            int winWidth = GetWinWidth();
            int winHeight = GetWinHeight();
            for(int y = 0; y <  winHeight; y++) {
                DrawChar('█', 0, y);
                DrawChar('█', winWidth-1, y);
            }
            for(int x = 0; x < winWidth; x++) {
                DrawChar('█', x, 0);
                DrawChar('█', x, winHeight-1);
            }
        }

        private void DrawToFramebuffer(char ch, int x, int y, ref List<char> buffer) {
            buffer[x + y*GetWinWidth()] = ch;
        }

        public void SwapBuffers() {
            char[] tmp = new char[GetWinWidth() * GetWinHeight()];
            if(firstBuffer) {
                buffer1 = tmp.ToList();
            } else {
                buffer2 = tmp.ToList();
            }
            firstBuffer = !firstBuffer;
        }

        public void DrawScreen() {
            if(firstBuffer) {
                DrawBuffer(buffer1);
            } else {
                DrawBuffer(buffer2);
            }
        }

        private void DrawBuffer(List<char> buffer) {
            int winWidth = GetWinWidth();
            int winHeight = GetWinHeight();

            Console.CursorTop = 0;
            for(int y = 0; y <  winHeight; y++) {
                string line = "";
                for(int x = 0; x < winWidth; x++) {
                    line += buffer[x + y*winWidth];
                    if(buffer[x + y*winWidth] == '\0') {
                        line += ' ';
                    }
                }
                Console.WriteLine(line);
            }
        }
    }
    class GameParams {
        public int winWidth, winHeight;
        public string name;
    }
}
