using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

namespace NDRGameTemplate
{
    public class LevelManager : MonoBehaviour
    {
        #region Singleton
        private static LevelManager _instance;
        public static LevelManager instance
        {
            get
            {
                if (_instance == null)
                    _instance = GameObject.FindObjectOfType<LevelManager>();

                return _instance;
            }
        }

        #endregion

        [SerializeField] Player player;
        [SerializeField] Goal goal;
        [SerializeField] Transform obstacleFolder;
        [SerializeField] Transform obstaclePrefab;
        [SerializeField] Text levelName;
        [SerializeField] Text coinTxt;

        public static System.Action<LevelData> OnLevelStart;
        public static System.Action<bool> OnLevelEnd;

        private void Awake()
        {
            OnLevelStart += SetupLevel;
            Goal.OnGoalReached += EndLevel;
            
        }

        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                OnLevelStart -= SetupLevel;
                Goal.OnGoalReached -= EndLevel;

                SceneLoader.LoadScene(SceneName.MainMenu);
            }
        }

        public static void StartLevel(LevelData levelData)
        {
            if (OnLevelStart != null)
                OnLevelStart(levelData);
        }

        private void SetupLevel(LevelData levelData)
        {
            if (!levelData) return;
            
            levelName.text = levelData.name;

            ClearObstacle();
            player.transform.position = new Vector3(levelData.playerPosition.x,
                player.transform.position.y, levelData.playerPosition.z);

            goal.transform.position = new Vector3(levelData.goalPosition.x,
                goal.transform.position.y, levelData.goalPosition.z);

            for (int i = 0; i < levelData.obstaclePositions.Length; i++)
            {
                Transform newObstacle = Instantiate(obstaclePrefab);
                newObstacle.position = new Vector3(levelData.obstaclePositions[i].x, obstaclePrefab.transform.position.y,
                    levelData.obstaclePositions[i].z);
                newObstacle.parent = obstacleFolder;
            }
        }

        private void ClearObstacle()
        {
            foreach (Transform child in obstacleFolder)
            {
                Destroy(child.gameObject);
            }
        }

        private void EndLevel()
        {
            OnLevelStart -= SetupLevel;
            Goal.OnGoalReached -= EndLevel;

            if (OnLevelEnd == null) return;
            
            OnLevelEnd(true);
        }

        public void UpdateCoinUI(int coinAmount)
        {
            coinTxt.text = coinAmount.ToString();
        }
    }
}