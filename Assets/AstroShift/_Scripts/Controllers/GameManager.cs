using System.Reflection;

using UnityEngine;
using UnityEngine.SceneManagement;

namespace AstroShift
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }
        public IAutomatonable Player { get; set; }

        private void Awake()
        {
            if (Instance == null)
                Instance = this;
            else
                Destroy(gameObject);
        }

        public void LoadScene(int index)
        {
            SceneManager.LoadScene(index);
        }

        public void ReloadScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}