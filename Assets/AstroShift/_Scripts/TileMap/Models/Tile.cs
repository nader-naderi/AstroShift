namespace AstroShift
{
    public class Tile
    {
        public TileType type;
        public int x;
        public int y;

        public Tile(TileType type, int x, int y)
        {
            this.type = type;
            this.x = x;
            this.y = y;
        }
    }
}