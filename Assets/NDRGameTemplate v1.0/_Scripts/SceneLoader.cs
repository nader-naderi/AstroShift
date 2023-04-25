using UnityEngine;

namespace NDRGameTemplate
{
    public static class SceneLoader
    {
        public static void LoadScene(SceneName sceneName)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene((int)sceneName);
        }
    }

    public enum SceneName { MainMenu, Level, LevelEnd, MenuLevelSelect, MenuSetting }
}
