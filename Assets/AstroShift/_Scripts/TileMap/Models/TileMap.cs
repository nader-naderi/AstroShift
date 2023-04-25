using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace AstroShift
{
    public class TileMap : MonoBehaviour
    {
        public Tile[,] tiles;

        public TileMap(int width, int height)
        {
            tiles = new Tile[width, height];
        }

        public void SetTile(Tile tile)
        {
            tiles[tile.x, tile.y] = tile;
        }

        public Tile GetTile(int x, int y)
        {
            return tiles[x, y];
        }
    }
}