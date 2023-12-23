using Core;
using UnityEngine;
using UnityEngine.UI;

namespace Menu
{
    public class DifficultySettings : MonoBehaviour
    {
        [SerializeField] private ChooseDifficultyButton[] _buttons;
        [SerializeField] private Button _settingsActivator;

        private Settings _settings;
        
        public void Initalize(Settings settings)
        {
            _settings = settings;
            _settingsActivator.onClick.AddListener(ActivateScreen);

            foreach (var button in _buttons)
            {
                button.Initiliaze(settings, this.gameObject);
                button.OnButtonClick += ShowChosenDifficulty;
            }

            gameObject.SetActive(false);
        }

        public void SetDifficulty(DifficultyType difficultyType)
        {
            _settings.DifficultyType = difficultyType;
        }

        private void ActivateScreen()
        {
            gameObject.SetActive(!gameObject.activeInHierarchy);
        }

        private void ShowChosenDifficulty(ChooseDifficultyButton chooseDifficultyButton)
        {
            chooseDifficultyButton.ButtonImage.color = Color.yellow;

            foreach (var button in _buttons)
            {
                if (button != chooseDifficultyButton)
                {
                    button.ButtonImage.color = Color.white;
                }
            }
        }
    }
}
