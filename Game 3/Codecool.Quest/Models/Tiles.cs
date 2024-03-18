using System;
using System.Collections.Generic;
using System.Drawing;

namespace Codecool.Quest.Models
{

    public static class Tiles
    {
        public const int TILE_WIDTH = 16;
        public const int DRAW_SCALE = 2;

        private static Bitmap tileSet;
        public static Dictionary<string, Tile> tileMap;

        static Tiles()
        {
            tileSet = new Bitmap("Resources/roguelikeDungeon_transparent.png");
            tileMap = new Dictionary<string, Tile>();

            tileMap.Add("empty", new Tile(0, 0));
            tileMap.Add("wall", new Tile(10, 18));
            tileMap.Add("floor", new Tile(2, 0));
            tileMap.Add("player", new Tile(25, 0));
            tileMap.Add("key", new Tile(16, 23));
            tileMap.Add("door", new Tile(3, 3));
            tileMap.Add("boss", new Tile(25, 8));
            tileMap.Add("hit", new Tile(26, 11));
            tileMap.Add("level2", new Tile(0, 3));
            tileMap.Add("stairs", new Tile(3, 6));
            tileMap.Add("tree", new Tile(3, 1));
            tileMap.Add("plant", new Tile(15, 6));
            tileMap.Add("water", new Tile(8, 4));
            tileMap.Add("bridge", new Tile(17, 5));
            tileMap.Add("wood", new Tile(6, 2));
            tileMap.Add("roof1", new Tile(5, 12));
            tileMap.Add("roof2", new Tile(6, 12));
            tileMap.Add("roof3", new Tile(7, 12));
            tileMap.Add("castle1", new Tile(5, 13));
            tileMap.Add("castle2", new Tile(6, 13));
            tileMap.Add("castle3", new Tile(7, 13));
            tileMap.Add("castleDoor", new Tile(11, 16));
            tileMap.Add("castleFloor", new Tile(19, 1));
            tileMap.Add("castle", new Tile(19, 1));
            tileMap.Add("castleWall", new Tile(10, 17));
            tileMap.Add("candelabr", new Tile(4, 15));
            tileMap.Add("king", new Tile(28, 3));

            //UEH
            //DSA
            tileMap.Add("DSA-D", new Tile(22, 30));
            tileMap.Add("DSA-S", new Tile(24, 31));
            tileMap.Add("DSA-A", new Tile(19, 30));
            //Thang máy
            tileMap.Add("elevator1", new Tile(9, 17));
            tileMap.Add("elevator2", new Tile(9, 18));
            //Bàn lễ tân
            tileMap.Add("letan1", new Tile(16, 20));
            tileMap.Add("letan2", new Tile(17, 20));
            tileMap.Add("letan3", new Tile(18, 20));
            tileMap.Add("letan4", new Tile(16, 21));
            tileMap.Add("letan5", new Tile(17, 21));
            tileMap.Add("letan6", new Tile(18, 21));
            //Trụ sảnh B1
            tileMap.Add("tru1", new Tile(16, 19));
            tileMap.Add("tru2", new Tile(18, 19));
            //English Zone
            tileMap.Add("ez1", new Tile(16, 13));
            tileMap.Add("ez2", new Tile(17, 13));
            tileMap.Add("ez3", new Tile(18, 13));
            tileMap.Add("ez4", new Tile(16, 14));
            tileMap.Add("ez5", new Tile(18, 14));
            tileMap.Add("ez6", new Tile(16, 15));
            tileMap.Add("ez7", new Tile(17, 15));
            tileMap.Add("ez8", new Tile(18, 15));
            //EnglishZone-Char
            tileMap.Add("E", new Tile(23, 30));
            tileMap.Add("N", new Tile(19, 31));
            tileMap.Add("G", new Tile(25, 30));
            tileMap.Add("L", new Tile(30, 30));
            tileMap.Add("I", new Tile(27, 30));
            tileMap.Add("S", new Tile(24, 31));
            tileMap.Add("H", new Tile(26, 30));
            tileMap.Add("Z", new Tile(31, 31));
            tileMap.Add("O", new Tile(20, 31));
            tileMap.Add("U", new Tile(26, 31));
            //UEH-Cơ sở N
            tileMap.Add("n1", new Tile(3, 17));
            //csN - hồ nước
            tileMap.Add("n2", new Tile(8, 4));
            tileMap.Add("n3", new Tile(6, 4));
            //csN - khuôn viên N2
            //cs - A
            tileMap.Add("car", new Tile(13, 23));
        }

        public class Tile
        {
            public int x, y, w, h;
            public Bitmap bitmap;
            public Tile(int i, int j)
            {
                x = i * (TILE_WIDTH + 1);
                y = j * (TILE_WIDTH + 1);
                w = TILE_WIDTH;
                h = TILE_WIDTH;
                bitmap = tileSet.Clone(new Rectangle(x, y, w, h), System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            }
        }


        public static void DrawTile(Graphics graphics, IDrawable d, int x, int y)
        {
            Tile tile = tileMap[d.TileName];
            graphics.DrawImage(tile.bitmap, x * TILE_WIDTH * DRAW_SCALE, y * TILE_WIDTH * DRAW_SCALE, tile.w * DRAW_SCALE, tile.h * DRAW_SCALE);
        }

        public static void DeleteActor(Cell neighborCell)
        {

            neighborCell.Actor.TileName = "floor";
            neighborCell.CellType = CellType.FLOOR;
            neighborCell.Actor.isAlive = false;
            neighborCell.Actor.canMove = false;
        }
    }
}
