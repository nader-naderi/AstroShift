using UnityEngine;

namespace AstroShift
{
    [CreateAssetMenu(fileName = "TileData", menuName = "ScriptableObjects/TileData", order = 1)]
    public class TileData : ScriptableObject
    {
        public string tileName;
        public Sprite tileSprite;
        public TileType tileType;
    }
}
