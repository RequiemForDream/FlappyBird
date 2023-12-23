using Common.Interfaces;
using System;
using UnityEngine;

namespace Character
{
    public class CharacterView : MonoBehaviour, IDestroyable
    {
        public event Action OnDestroyHandler;
        public SpriteRenderer SpriteRenderer { get; private set; }
        public IDetector PipeDetector { get; private set; }

        private Sprite[] _sprites;
        private float _repeatBase;
        private float _time;

        private int _spriteIndex = 0;

        private void Start()
        {
            SpriteRenderer = GetComponent<SpriteRenderer>();
            PipeDetector = GetComponent<IDetector>();
            InvokeRepeating(nameof(AnimateSwing), _time, _repeatBase);
        }

        public void Initialize(Sprite[] sprites, float time, float repeatBase)
        {
            _sprites = sprites;
            _repeatBase = repeatBase;
            _time = time;
        }

        private void AnimateSwing()
        {
            _spriteIndex++;

            if (_spriteIndex >= _sprites.Length)
            {
                _spriteIndex = 0;
            }

            SpriteRenderer.sprite = _sprites[_spriteIndex];
        }
    }
}
