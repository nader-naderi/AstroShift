using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace AstroShift
{
    public class GameControl : MonoBehaviour
    {
        public static GameControl Instance { get; private set; }

        public int startingFuel = 100;
        public int fuelDrainRate = 1;
        public int maxFuel = 200;
        public float respawnDelay = 2f;
        public int Score {get; private set; } = 0;
        private int _fuel;
        private bool _gameOver;
        public bool IsFlying {get; set;}
        public int Fuel
        {
            get { return _fuel; }
            set
            {
                _fuel = Mathf.Clamp(value, 0, maxFuel);
                UIManager.Instance.UpdateFuelBar(_fuel, maxFuel);
                
                if (_fuel == 0)
                {
                    GameOver();
                }
            }
        }

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void Start()
        {
            ResetGame();
        }

        private void Update()
        {
            if (!_gameOver && IsFlying)
            {
                Fuel -= fuelDrainRate;
            }
        }

        public void AddFuel(int amount)
        {
            Fuel += amount;
        }

        public void ResetGame()
        {
            _gameOver = false;
            Fuel = startingFuel;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        public void GameOver()
        {
            if (!_gameOver)
            {
                _gameOver = true;
                StartCoroutine(GameOverCoroutine());
            }
        }

        private IEnumerator GameOverCoroutine()
        {
            yield return new WaitForSeconds(respawnDelay);
            UIManager.Instance.ShowGameOverPanel();
        }

        public void AddScore(int score)
        {
            Score += score;
            UIManager.Instance.UpdateScore(Score);
        }
    }

}