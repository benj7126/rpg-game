using System;
using System.Collections.Generic;
using System.Text;
using rpg_game;
using System.Threading;
using System.Linq;
using System.Drawing;

namespace rpg_game.Game_Classes.maze
{
    class Maze {
        static Dictionary<int, Color> colors = new Dictionary<int, Color>() {
            {1, Color.FromArgb(255, 255, 255)},
            {2, Color.FromArgb(0,   255, 0  )},
            {3, Color.FromArgb(255, 0,   0  )},
            {101, Color.FromArgb(0,   255, 0  )}, // Also used as collision box for winning.
            {102, Color.FromArgb(255, 0,   0  )}, // Also used for leaving the maze
        };
        public static bool StartMaze(Map map) {
            return Start(map);
        }

        public static bool Start(Map map) {
            Console.Clear();
            MazeEngine game = new MazeEngine(80, 40, "maze");

            double posX = 5.5, posY = 7.5;
            double dirX = 0, dirY = -1;
            double planeX = -0.33, planeY = 0;
            int winCX = -1, winCY = -1;
            int extCX = -1, extCY = -1;

            int visRange = 25;

            for(int x = 0; x < map.Width; x++) {
                for(int y = 0; y < map.Height-1; y++) {
                    int cell = map.GetCell(x, y);
                    if(cell >= 100) {
                        switch(cell) {
                            case 100: // SpawnPoint
                                map.SetCellRel(x, y, 0);
                                posX = 0.5 + x;
                                posY = 0.5 + y;
                                break;
                            case 101: // WinPoint
                                winCX = x;
                                winCY = y;
                                break;
                            case 102: // ExitPoint
                                extCX = x;
                                extCY = y;
                                break;
                        }
                    }
                }
            }

            while(true) {

                // game.DrawBackground(Color.FromArgb(255, 255, 0), Color.Blue, visRange);

                for(int x = 0; x < game.GetWinWidth(); x++) {
                    double cameraX = 2 * x / (double)game.GetWinWidth() - 1;
                    double rayDirX = dirX + planeX * cameraX;
                    double rayDirY = dirY + planeY * cameraX;

                    int mapX = (int)Math.Floor(posX);
                    int mapY = (int)Math.Floor(posY);

                    double sideDistX;
                    double sideDistY;

                    double deltaDistX = rayDirX == 0 ? 100000000 : Math.Abs(1 / rayDirX);
                    double deltaDistY = rayDirY == 0 ? 100000000 : Math.Abs(1 / rayDirY);
                    double perpWallDist;

                    int stepX;
                    int stepY;

                    bool hit = false;
                    int hitNum = 0;
                    int side = 0;

                    if(rayDirX < 0) {
                        stepX = -1;
                        sideDistX = (posX - mapX) * deltaDistX;
                    } else {
                        stepX = 1;
                        sideDistX = (mapX + 1 - posX) * deltaDistX;
                    }

                    if(rayDirY < 0) {
                        stepY = -1;
                        sideDistY = (posY - mapY) * deltaDistY;
                    } else {
                        stepY = 1;
                        sideDistY = (mapY + 1 - posY) * deltaDistY;
                    }

                    while(!hit) {
                        if(sideDistX < sideDistY) {
                            sideDistX += deltaDistX;
                            mapX += stepX;
                            side = 0;
                        } else {
                            sideDistY += deltaDistY;
                            mapY += stepY;
                            side = 1;
                        }

                        if(map.GetCell(mapX, mapY) > 0) {
                            hit = true;
                            hitNum = map.GetCell(mapX, mapY);
                        }

                    }

                    if(side == 0)
                        perpWallDist = (sideDistX - deltaDistX);
                    else
                        perpWallDist = (sideDistY - deltaDistY);

                    // lineHeight stores the height needed to draw the ray in
                    // screen coordinates.
                    // It is calculated in a try-catch block, to catch a
                    // division by zero and in that case, make it a very large
                    // number.
                    int lineHeight;
                    try {
                        lineHeight = Convert.ToInt32(game.GetWinHeight() / perpWallDist);
                    } catch (Exception e) {
                        lineHeight = 1000;
                    }

                    // Get the ray color.
                    Color col = colors[hitNum];
                    // Actually draw the raycast line. Darken color depending on
                    // facing side, simulating lighting,
                    if(side == 0) {
                        // Construct darker color
                        col = Color.FromArgb(
                            (int)(col.R * 0.8),
                            (int)(col.G * 0.8),
                            (int)(col.B * 0.8));
                    }

                    col = Color.FromArgb(
                        (int)(Math.Max(0, col.R - perpWallDist*visRange )),
                        (int)(Math.Max(0, col.G - perpWallDist*visRange )),
                        (int)(Math.Max(0, col.B - perpWallDist*visRange )));
                    game.DrawVerLine(x, lineHeight, col);
                }

                // Handle movement
                double rotSpeed = 0.2;
                double movSpeed = 0.1;
                if (Console.KeyAvailable) {
                    // Reads and saves pressed key
                    ConsoleKeyInfo key = Console.ReadKey();
                    // Checks the pressed key. Sends press to menu.
                    if(key.Key == Player.up) {
                        int cellX = map.GetCell((int)(posX + dirX * movSpeed), (int)(posY));
                        int cellY = map.GetCell((int)(posX), (int)(posY + dirY * movSpeed));
                        if(cellX == 0 || cellX >= 100) posX += dirX * movSpeed;
                        if(cellY == 0 || cellY >= 100) posY += dirY * 0.1;
                    } else if(key.Key == Player.down) {
                        int cellX = map.GetCell((int)(posX - dirX * movSpeed), (int)(posY));
                        int cellY = map.GetCell((int)(posX), (int)(posY - dirY * movSpeed));
                        if(cellX == 0 || cellX >= 100) posX -= dirX * movSpeed;
                        if(cellY == 0 || cellY >= 100) posY -= dirY * 0.1;
                    } else if(key.Key == Player.right) {
                        double oldDirX = dirX;
                        dirX = dirX * Math.Cos(-rotSpeed) - dirY * Math.Sin(-rotSpeed);
                        dirY = oldDirX * Math.Sin(-rotSpeed) + dirY * Math.Cos(-rotSpeed);
                        double oldPlaneX = planeX;
                        planeX = planeX * Math.Cos(-rotSpeed) - planeY * Math.Sin(-rotSpeed);
                        planeY = oldPlaneX * Math.Sin(-rotSpeed) + planeY * Math.Cos(-rotSpeed);
                    } else if(key.Key == Player.left) {
                        double oldDirX = dirX;
                        dirX = dirX * Math.Cos(rotSpeed) - dirY * Math.Sin(rotSpeed);
                        dirY = oldDirX * Math.Sin(rotSpeed) + dirY * Math.Cos(rotSpeed);
                        double oldPlaneX = planeX;
                        planeX = planeX * Math.Cos(rotSpeed) - planeY * Math.Sin(rotSpeed);
                        planeY = oldPlaneX * Math.Sin(rotSpeed) + planeY * Math.Cos(rotSpeed);
                    }
                }

                // Check for win/exit
                if((int)posX == winCX && (int)posY == winCY) {
                    // Winner!
                    return true;
                }
                if((int)posX == extCX && (int)posY == extCY) {
                    // Loser!
                    return false;
                }

                game.DrawBorder();
                game.SwapBuffers();
                game.DrawScreen();

                Console.WriteLine(posX + " : " + posY);
            }
        }
    }
}
