using System;
using System.Collections.Generic;
using System.Text;
using rpg_game;
using System.Threading;
using System.Linq;
using Pastel;
using System.Drawing;

namespace rpg_game.Game_Classes.maze
{
    class MazeEngine {
        GameParams parameters = new GameParams();

        List<string> buffer1;
        List<string> buffer2;

        bool firstBuffer = true;

        public MazeEngine(int win_width, int win_height, string game_name) {
            string[] tmp = new string[win_width * win_height];
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
                DrawToFramebuffer(ch.ToString(), x, y, ref buffer1);
            } else {
                DrawToFramebuffer(ch.ToString(), x, y, ref buffer2);
            }
        }

        public void DrawChar(string ch, int x, int y) {
            if (x < 0 || x > GetWinWidth() || y < 0 || y > GetWinHeight()) {
                throw new ArgumentOutOfRangeException();
            }

            if(!firstBuffer) {
                DrawToFramebuffer(ch, x, y, ref buffer1);
            } else {
                DrawToFramebuffer(ch, x, y, ref buffer2);
            }
        }

        public void DrawVerLine(int x, int height, Color color) {
            height = height > GetWinHeight() ? GetWinHeight() : height;
            if (x < 0 || x > GetWinWidth()) {
                throw new ArgumentOutOfRangeException();
            }

            int startY = GetWinHeight()/2 - height/2;
            for(int i = 0; i < height; i++) {
                DrawChar("█".Pastel(color), x, startY+i);
            }
        }

        public void DrawBackground(Color groundCol, Color skyCol, int visRange) {
            //DrawGround(groundCol, visRange);
            DrawSky(skyCol, visRange);
        }

        private void DrawGround(Color col, int visRange) {
            for(int x = 0; x < GetWinWidth(); x++) {
                for(int y = GetWinHeight()-1; y > GetWinHeight()/2; y--) {
                    col = Color.FromArgb(
                        (int)(Math.Max(0, col.R - y*visRange/2 )),
                        (int)(Math.Max(0, col.G - y*visRange/2 )),
                        (int)(Math.Max(0, col.B - y*visRange/2 )));
                    DrawChar("█".Pastel(col), x, y);
                }
            }
        }

        private void DrawSky(Color col, int visRange) {
            for(int x = 0; x < GetWinWidth(); x++) {
                for(int y = 0; y < GetWinHeight()/2; y++) {
                    DrawChar("█".Pastel(col), x, y);
                }
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

        private void DrawToFramebuffer(string ch, int x, int y, ref List<string> buffer) {
            buffer[x + y*GetWinWidth()] = ch;
        }

        public void SwapBuffers() {
            string[] tmp = new string[GetWinWidth() * GetWinHeight()];
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

        private void DrawBuffer(List<string> buffer) {
            int winWidth = GetWinWidth();
            int winHeight = GetWinHeight();

            Console.CursorTop = 0;
            for(int y = 0; y <  winHeight; y++) {
                string line = "";
                for(int x = 0; x < winWidth; x++) {
                    line += buffer[x + y*winWidth];
                    if(buffer[x + y*winWidth] == null) {
                        line += " ";
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
