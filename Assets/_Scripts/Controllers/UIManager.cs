using System;
using UnityEngine;
using UnityEngine.UI;

namespace AstroShift
{
    public class UIManager : MonoBehaviour
    {
        public static UIManager Instance {get; private set;}
        [SerializeField] Image fuelBar;
        [SerializeField] Text scoreText;
        /// <summary>
        /// Awake is called when the script instance is being loaded.
        /// </summary>
        private void Awake()
        {
            if(Instance == null)
                Instance = this;
            else
                Destroy(gameObject);
        }

        public void UpdateFuelBar(float amount, float maxAmount)
        {
            fuelBar.fillAmount = amount / maxAmount;
        }   

        public void ShowGameOverPanel()
        {
            
        }

        public void UpdateScore(int score)
        {
            scoreText.text = score.ToString();
        }
    }
}