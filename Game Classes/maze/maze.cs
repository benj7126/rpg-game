using System;
using System.Collections.Generic;
using System.Text;
using rpg_game;
using System.Threading;
using System.Linq;

namespace rpg_game.Game_Classes.maze
{
    class Maze {
        public static void Start() {
            MazeEngine game = new MazeEngine(80, 40, "maze");
            int[] mapArr = {
                1, 1, 1, 1, 1, 1, 1, 1, 1,
                1, 0, 0, 0, 0, 0, 0, 0, 1,
                1, 0, 1, 0, 0, 0, 0, 0, 1,
                1, 0, 0, 1, 0, 0, 0, 0, 1,
                1, 1, 1, 0, 0, 1, 1, 1, 1,
                1, 0, 0, 0, 0, 0, 0, 0, 1,
                1, 0, 0, 0, 0, 0, 0, 0, 1,
                1, 0, 0, 0, 0, 0, 0, 0, 1,
                1, 0, 0, 0, 0, 0, 0, 0, 1,
                1, 1, 1, 1, 1, 1, 1, 1, 1,
            };

            Map map = new Map(9, 10, mapArr);

            double posX = 6, posY = 8;
            double dirX = -1, dirY = 0;
            double planeX = 0, planeY = 0.66;

            while(true) {
                game.DrawVerLine(2, 6);

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

                        if(map.GetCell(mapX, mapY) > 0)
                            hit = true;
                    }

                    if(side == 0)
                        perpWallDist = (sideDistX - deltaDistX);
                    else
                        perpWallDist = (sideDistY - deltaDistY);
                    int lineHeight = Convert.ToInt32(game.GetWinHeight() / perpWallDist);
                    game.DrawVerLine(x, lineHeight);
                }

                double rotSpeed = 0.2;
                if (Console.KeyAvailable) {
                    // Reads and saves pressed key
                    ConsoleKeyInfo key = Console.ReadKey();
                    // Checks the pressed key. Sends press to menu.
                    if(key.Key == ConsoleKey.UpArrow) {
                        posX += dirX * 0.1;
                        posY += dirY * 0.1;
                    } else if(key.Key == ConsoleKey.DownArrow) {
                        posX -= dirX * 0.1;
                        posY -= dirY * 0.1;
                    } else if(key.Key == ConsoleKey.RightArrow) {
                        double oldDirX = dirX;
                        dirX = dirX * Math.Cos(-rotSpeed) - dirY * Math.Sin(-rotSpeed);
                        dirY = oldDirX * Math.Sin(-rotSpeed) + dirY * Math.Cos(-rotSpeed);
                        double oldPlaneX = planeX;
                        planeX = planeX * Math.Cos(-rotSpeed) - planeY * Math.Sin(-rotSpeed);
                        planeY = oldPlaneX * Math.Sin(-rotSpeed) + planeY * Math.Cos(-rotSpeed);
                    } else if(key.Key == ConsoleKey.LeftArrow) {
                        double oldDirX = dirX;
                        dirX = dirX * Math.Cos(rotSpeed) - dirY * Math.Sin(rotSpeed);
                        dirY = oldDirX * Math.Sin(rotSpeed) + dirY * Math.Cos(rotSpeed);
                        double oldPlaneX = planeX;
                        planeX = planeX * Math.Cos(rotSpeed) - planeY * Math.Sin(rotSpeed);
                        planeY = oldPlaneX * Math.Sin(rotSpeed) + planeY * Math.Cos(rotSpeed);
                    }
            }

                game.DrawBorder();
                game.SwapBuffers();
                game.DrawScreen();
            }
        }
    }
}
