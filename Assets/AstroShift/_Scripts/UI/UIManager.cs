using NDR2ndAutoBattler;

using System;

using TMPro;

using UnityEngine;
using UnityEngine.UI;

namespace AstroShift
{
    public class UIManager : MonoBehaviour
    {
        public static UIManager Instance {get; private set;}
        public GameObject NoFuelAlert { get => noFuelAlert; }

        [SerializeField] private UIBar fuelBar;
        [SerializeField] private UIBar healthBar;
        [SerializeField] private UIBar boostBar;
        [SerializeField] private GameObject noFuelAlert;
        [SerializeField] TextMeshProUGUI scoreText;

        private void Awake()
        {
            if(Instance == null)
                Instance = this;
            else
                Destroy(gameObject);
        }

        public void UpdateFuelBar(float amount)
            => fuelBar.UpdateBar(amount);

        public void UpdateHealthBar(float amount)
           => healthBar.UpdateBar(amount);

        public void UpdateBoostBar(float amount)
           => boostBar.UpdateBar(amount);

        public void ShowGameOverPanel()
        {
            
        }

        public void UpdateScore(int score)
        {
            scoreText.text = score + " / 1000";
        }
    }
}