using UnityEngine;
using UnityEngine.UI;
using Utilities;

namespace UI
{
    public class GameOverScreen : MonoBehaviour
    {
        [SerializeField] private Button _menuButton;
        [SerializeField] private Button _playButton;

        private void Awake()
        {
            _menuButton.onClick.AddListener(GetToMenu);
            _playButton.onClick.AddListener(PlayAgain);
            gameObject.SetActive(false);
        }

        private void GetToMenu()
        {
            SceneLoader.LoadSceneByBuildIndex(DataClass.MENU_SCENE);
        }

        private void PlayAgain()
        {
            SceneLoader.LoadSceneByBuildIndex(DataClass.GAMEPLAY_SCENE);
        }
    }
}
