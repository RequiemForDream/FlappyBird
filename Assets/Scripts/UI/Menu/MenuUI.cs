using Core;
using UnityEngine;
using UnityEngine.UI;
using Utilities;

namespace Menu
{
    public class MenuUI : MonoBehaviour
    {
        [SerializeField] private DifficultySettings _difficultySettings;
        [SerializeField] private VolumeSettings _volumeSettings;
        [SerializeField] private Button _startButton;
        [SerializeField] private Settings _settings;

        private void Awake()
        {
            _difficultySettings.Initalize(_settings);
            _volumeSettings.Initialize(_settings);
            _startButton.onClick.AddListener(StartGame);
        }

        private void StartGame()
        {
            SceneLoader.LoadSceneByBuildIndex(DataClass.GAMEPLAY_SCENE);
        }
    }
}
