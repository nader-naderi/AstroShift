using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace NDRGameTemplate
{
    public class UILevelEnd : MonoBehaviour
    {
        [SerializeField] Text messageTxt;
        [SerializeField] Button restartButton;
        [SerializeField] Text restartButtonLabel;

        private void Start()
        {
            if(PlaySessionManager.instance.IsGameCompleted)
            {
                messageTxt.text = "You Won !";
                restartButton.gameObject.SetActive(false);
                PlaySessionManager.instance.IsGameCompleted = false;
                return;
            }
            bool success = PlaySessionManager.instance.PreviousLevelEndSuccess;
            messageTxt.text = success ? "Level Complete!" : "Level Failed";
            restartButtonLabel.text = success ? "Next Level" : "Try Again";
        }

        public void OnBtnPressed_Restart()
        {
            SceneLoader.LoadScene(SceneName.Level);
        }

        public void OnBtnPressed_ReturnToMenu()
        {
            SceneLoader.LoadScene(SceneName.MainMenu);
        }
    }
}