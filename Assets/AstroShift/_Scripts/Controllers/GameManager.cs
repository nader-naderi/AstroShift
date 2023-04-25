using System.Reflection;

using UnityEngine;
using UnityEngine.SceneManagement;

namespace AstroShift
{
    public class GameManager : MonoBehaviour
    {
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