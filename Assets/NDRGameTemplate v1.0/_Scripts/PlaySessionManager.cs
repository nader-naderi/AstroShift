using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;

namespace NDRGameTemplate
{
    public class PlaySessionManager : MonoBehaviour
    {
        #region Singleton
        public static PlaySessionManager instance;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else if (instance != this)
            {
                Destroy(gameObject);
                return;
            }

            SceneManager.sceneLoaded += OnSceneLoad;
            LevelManager.OnLevelEnd += HandleLevelEnd;

            SaveManager.LoadGameData();
        }

        #endregion

        [SerializeField] LevelCatalog levelCatalog;

        private int currentLevel = 0;
        private int furthestLevel = 0;

        public bool PreviousLevelEndSuccess { get; private set; } = false;
        public bool IsGameCompleted { get; set; }
        public int CurrentLevel { get => currentLevel; set => currentLevel = value; }
        public LevelCatalog LevelCatalog { get => levelCatalog; }
        public int FurthestLevel { get => furthestLevel; set => furthestLevel = value; }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Equals)) 
                SaveManager.ClearSaves();
        }

        private void OnSceneLoad(Scene scene, LoadSceneMode loadSceneMode)
        {
            if (instance != this) return;

            if (scene.name == "Level")
            {
                LevelManager.StartLevel(levelCatalog.GetLevel(currentLevel));
                PresistentAudioPlayer.instance.ChangeMusic(1);
            }
            else
                PresistentAudioPlayer.instance.ChangeMusic(0);
        }

        private void HandleLevelEnd(bool isLevelCompleted)
        {
            if (instance != this) return;

            PreviousLevelEndSuccess = isLevelCompleted;

            if (isLevelCompleted)
            {
                // Fancy.
                //currentLevel = (currentLevel + 1) % levelCatalog.Length;
                currentLevel++;
                if (currentLevel >= levelCatalog.Length)
                {
                    currentLevel = 0;
                    IsGameCompleted = true;
                }

                if (currentLevel >= furthestLevel)
                {
                    furthestLevel = currentLevel;
                    SaveManager.SaveGameData();
                }
            }

            Debug.Log(currentLevel);
            SceneLoader.LoadScene(SceneName.LevelEnd);
        }

        public void LoadLevel(int index)
        {
            SceneManager.LoadScene(index);
        }
    }
}