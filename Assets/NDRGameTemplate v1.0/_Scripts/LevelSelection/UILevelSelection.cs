using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NDRGameTemplate
{
    public class UILevelSelection : MonoBehaviour
    {
        [SerializeField] LevelSelectionBtn btnPrefab;
        [SerializeField] Transform buttonContainer;

        private void Start()
        {
            for (int i = 0; i <= PlaySessionManager.instance.FurthestLevel; i++)
            {
                LevelSelectionBtn newBtn = Instantiate(btnPrefab, buttonContainer);
                newBtn.Initialize(this, i);
            }
        }
        public void OnBtnPressed_StartGame()
        {
            SceneLoader.LoadScene(SceneName.Level);
        }

        public void OnBtnPressed_BackToMenu()
        {
            SceneLoader.LoadScene(SceneName.MainMenu);
        }

        public void LevelButtonPressed(int levelIndex)
        {
            PlaySessionManager.instance.CurrentLevel = levelIndex;
            SceneLoader.LoadScene(SceneName.Level);
        }
    }
}