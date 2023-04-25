using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NDRGameTemplate
{
    public class OutsiderViewer : MonoBehaviour
    {
        void Start()
        {
            LevelManager.OnLevelEnd += AnnounceGameOver;
     //       LevelManager.StartLevel();
        }

        private void AnnounceGameOver(bool isCompleted)
        {
            if (isCompleted)
                 Debug.Log("Level Completed.");
            else
                Debug.Log("Level Over.");
        }
    }
}