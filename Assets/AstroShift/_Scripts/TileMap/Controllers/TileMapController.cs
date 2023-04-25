using UnityEngine;

namespace AstroShift
{
    internal class TileMapController : MonoBehaviour
    {

        [SerializeField] private GameObject tilePrefab;
        public TileData[] tilePrefabs;

        private TileMap tileMap;

        public void Initialize(TileMap tileMap)
        {
            this.tileMap = tileMap;

            for (int x = 0; x < tileMap.tiles.GetLength(0); x++)
                for (int y = 0; y < tileMap.tiles.GetLength(1); y++)
                {
                    Tile tile = tileMap.GetTile(x, y);
                    if (tile != null)
                        CreateTile(x, y, tile);
                }
        }

        private void CreateTile(int x, int y, Tile tile)
        {
            GameObject tileGameObject = Instantiate(tilePrefab, new Vector3(x, y, 0), Quaternion.identity);

            SpriteRenderer renderer = tileGameObject.GetComponent<SpriteRenderer>();

            tileGameObject.transform.SetParent(transform);
        }
    }
}