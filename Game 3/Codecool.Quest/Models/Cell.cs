using Codecool.Quest.Models.Actors;
using System.Collections.Generic;
using Codecool.Quest.Models;
using System;

namespace Codecool.Quest.Models
{

    public class Cell : IDrawable
    {
        public Actor Actor { get; set; }
        public CellType CellType { get; set; }
        public int X { get; private set; }
        public int Y { get; private set; }

        public string TileName => CellType.ToString("g").ToLowerInvariant();

        GameMap gameMap;
        public Cell(GameMap gameMap, int x, int y, CellType cellType)
        {
            this.gameMap = gameMap;
            this.X = x;
            this.Y = y;
            this.CellType = cellType;
        }

        public Cell GetNeighbor(int dx, int dy)
        {
            if (this.Actor == null)
            {
                return gameMap.GetCell(X, Y);
            }
            if (this.Actor.TileName == "player")
            {
                return GetPlayerNeighbourCell(dx, dy);
            }
            else if (gameMap.mobTypes.Contains(this.Actor.TileName))
            {
                return GetMobNeighbourCell(dx, dy);
            }
            else
            {
                return gameMap.GetCell(X, Y);
            }

        }

        public Cell GetMobNeighbourCell(int dx, int dy)
        {
            Cell neighborCell;
            neighborCell = gameMap.GetCell(X + dx, Y + dy);
            if (neighborCell.CellType == CellType.FLOOR)
            {
                return neighborCell;
            }
            else
            {
                return gameMap.GetCell(X, Y);
            }
        }

        public Cell GetPlayerNeighbourCell(int dx, int dy)
        {
            Cell neighborCell;
            neighborCell = gameMap.GetCell(X + dx, Y + dy);
            //Các vật phẩm xuất hiện trong MAP
            if (neighborCell.CellType == CellType.ITEM)
            {
                string item = neighborCell.Actor.TileName;
                gameMap.inventory.addToInventory(item);
                neighborCell.CellType = CellType.FLOOR;
                return neighborCell;

            }
            else if (neighborCell.CellType == CellType.WALL)
            {
                return gameMap.GetCell(X, Y);
            }
            else if (neighborCell.CellType == CellType.DOOR)
            {

                if (gameMap.inventory.playerInventory.ContainsKey("key"))
                {
                    Tiles.tileMap["door"] = new Tiles.Tile(4, 3);
                    neighborCell.CellType = CellType.FLOOR;
                    return neighborCell;
                }

                else
                {
                    return gameMap.GetCell(X, Y);
                }

            }
            else if (neighborCell.Actor != null && neighborCell.Actor.isAlive)
            {

                return gameMap.GetCell(X, Y);
                // Attack
            }
            else if (neighborCell.CellType == CellType.LEVEL2 )
            {
                Tiles.tileMap["door"] = new Tiles.Tile(6, 3);
                gameMap.num = 2;
                gameMap.mapChanging = true;
                return neighborCell;
            }
            else if (neighborCell.CellType == CellType.LEVEL3 )
            {
                gameMap.num = 3;
                Tiles.tileMap["floor"] = new Tiles.Tile(19, 1);
                gameMap.mapChanging = true;
                return neighborCell;
            }
            else if (neighborCell.CellType == CellType.WIN )
            {
                gameMap.Player.gameWin = true;
                return neighborCell;
            }
            else
            {
                return neighborCell;
            }
        }
    }
}

