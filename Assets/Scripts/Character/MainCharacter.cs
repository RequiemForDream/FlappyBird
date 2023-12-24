using Character.Interfaces;
using Core;
using Core.Interfaces;
using System;
using UnityEngine;

namespace Character
{
    public class MainCharacter : ICharacter
    {
        public event Action OnCharacterDeath;

        private readonly CharacterView _characterView;
        private readonly CharacterModel _characterModel;
        private readonly Updater _updater;
        private readonly IInputService _inputService;

        private Vector3 _direction;

        public MainCharacter(CharacterView characterView, CharacterModel characterModel, Updater updater,
            IInputService inputService)
        {
            _characterView = characterView;
            _characterModel = characterModel;
            _updater = updater;
            _inputService = inputService;
        }

        public void Initialize()
        {
            _characterView.gameObject.SetActive(true);
            _updater.AddListener(this);
            _inputService.OnTapScreen += Swing;
            _characterView.PipeDetector.OnCollided += OnDeath;
            _characterView.Initialize(_characterModel.AnimatedSprites, _characterModel.AnimationTime,
                _characterModel.RepeatBase);
            _characterView.OnDestroyHandler += Destroy;
            
        }

        public void Tick(float deltaTime)
        {
            _direction.y += _characterModel.Gravity * deltaTime;
            _characterView.transform.position += _direction * deltaTime;
        }

        public void Reset()
        {
            _characterView.gameObject.SetActive(false);
            _updater.RemoveListener(this);
            _inputService.OnTapScreen -= Swing;
        }

        private void OnDeath()
        {
            OnCharacterDeath?.Invoke();
        }

        private void Swing()
        {
            _direction = Vector3.up * _characterModel.Strength;
        }

        private void Destroy()
        {
            _updater.RemoveListener(this);
            _characterView.PipeDetector.OnCollided -= OnDeath;
            _characterView.OnDestroyHandler -= Destroy;
        }
    }
}
