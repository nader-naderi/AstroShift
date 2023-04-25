using UnityEngine;

namespace NDRGameTemplate
{
    [CreateAssetMenu(menuName = "Data File/Level Data")]
    public class LevelData : ScriptableObject
    {
        public Vector3 playerPosition;
        public Vector3 goalPosition;
        public Vector3[] obstaclePositions;
        public Vector3[] coinPositions;
    }
}
