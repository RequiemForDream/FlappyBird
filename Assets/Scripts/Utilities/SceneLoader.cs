using UnityEngine.SceneManagement;

namespace Utilities
{
    public static class SceneLoader
    {
        public static void LoadSceneByBuildIndex(int sceneIndex)
        {
            SceneManager.LoadScene(sceneIndex);
        }
    }
}

