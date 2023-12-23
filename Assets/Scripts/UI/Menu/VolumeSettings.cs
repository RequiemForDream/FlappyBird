using Core;
using UnityEngine;
using UnityEngine.UI;

namespace Menu
{
    public class VolumeSettings : MonoBehaviour
    {
        private Settings _settings;
        [SerializeField] private Slider _volumeSlider;

        public void Initialize(Settings settings)
        {
            _settings = settings;
            SetSliderValue();
            _volumeSlider.onValueChanged.AddListener(delegate { SetVolume(); });
        }

        private void SetVolume()
        {
            _settings.Volume = _volumeSlider.value;
        }

        private void SetSliderValue()
        {
            _volumeSlider.value = _settings.Volume;
        }
    }
}
