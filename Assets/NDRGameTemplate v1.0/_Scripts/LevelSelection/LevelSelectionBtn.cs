using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

namespace NDRGameTemplate
{
    public class LevelSelectionBtn : MonoBehaviour
    {
        UILevelSelection levelSelection;
        int levelIndex;

        public void Initialize(UILevelSelection levelSelection, int levelIndex)
        {
            this.levelSelection = levelSelection;
            this.levelIndex = levelIndex;
            GetComponentInChildren<Text>().text = "Level " + levelIndex;
        }

        public void OnBtnPressed_SelectLevel()
        {
            levelSelection.LevelButtonPressed(levelIndex);
        }
    }
}