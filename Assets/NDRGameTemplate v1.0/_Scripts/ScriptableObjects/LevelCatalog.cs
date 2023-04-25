using UnityEngine;

namespace NDRGameTemplate
{
    [CreateAssetMenu(menuName = "Data File/Level Catalog")]
    public class LevelCatalog : ScriptableObject
    {
        [SerializeField] private LevelData[] levelDatas;

        public int Length { get => levelDatas.Length; }

        public LevelData GetLevel(int index)
        {
            if (index >= levelDatas.Length || index < 0) return null;
            return levelDatas[index];
        }

        public int GetIndexOfLevel(LevelData data) => System.Array.IndexOf(levelDatas, data);
    }
}
