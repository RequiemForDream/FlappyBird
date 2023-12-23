using System;
using UnityEngine;

namespace Character
{
    [Serializable]
    public struct CharacterModel
    {
        [SerializeField] private float _gravity;
        [SerializeField] private float _strength;
        [SerializeField] private float _animationTime;
        [SerializeField] private float _repeatBase;
        [SerializeField] private Sprite[] _animatedSprites;
        public float Gravity => _gravity;
        public float Strength => _strength;
        public float AnimationTime => _animationTime;
        public float RepeatBase => _repeatBase;
        public Sprite[] AnimatedSprites => _animatedSprites;
    }
}
