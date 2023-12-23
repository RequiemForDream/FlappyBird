using Core;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace Menu
{
    public class ChooseDifficultyButton : MonoBehaviour
    {
        public event Action<ChooseDifficultyButton> OnButtonClick;
        public Image ButtonImage { get; private set; }

        [SerializeField] private DifficultyType _difficultyType;

        private Settings _settings;
        private GameObject _choseDifficultyScreen;
        private Button _button;

        public void Initiliaze(Settings settings, GameObject choseDifficultyScreen)
        {
            _settings = settings;
            _choseDifficultyScreen = choseDifficultyScreen;
            _button = GetComponent<Button>();
            ButtonImage = GetComponent<Image>();
            _button.onClick.AddListener(SetDifficult);
            SetColor();
        }

        private void SetColor()
        {
            if (_difficultyType == _settings.DifficultyType)
            {
                ButtonImage.color = Color.yellow;
            }
        }

        private void SetDifficult()
        {
            _settings.DifficultyType = _difficultyType;
            OnButtonClick?.Invoke(this);
            _choseDifficultyScreen.SetActive(false);
        }
    }
}
