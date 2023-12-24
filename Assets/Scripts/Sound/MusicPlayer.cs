using Core;
using UnityEngine;

namespace Sound
{
    public class MusicPlayer
    {
        private readonly Settings _settings;
        private readonly AudioSource _audioSource;

        public MusicPlayer(Settings settings, AudioSource audioSource)
        {
            _settings = settings;
            _audioSource = audioSource;
        }

        public void Initialize()
        {
            _audioSource.volume = _settings.Volume;
        }

        public void Reset()
        {
            _audioSource.volume = 0f;
        }
    }
}
