using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NDRGameTemplate
{
    public class UIMainMenu : MonoBehaviour
    {
        public void OnBtnPressed_StartGame()
        {
            SceneLoader.LoadScene(SceneName.Level);
        }

        public void OnBtnPressed_LevelSelect()
        {
            SceneLoader.LoadScene(SceneName.MenuLevelSelect);
        }

        public void OnBtnPressed_SettingMenu()
        {
            SceneLoader.LoadScene(SceneName.MenuSetting);
        }
    }
}