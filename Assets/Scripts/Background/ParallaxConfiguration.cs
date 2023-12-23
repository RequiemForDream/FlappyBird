using UnityEngine;

namespace Background
{
    [CreateAssetMenu(fileName = "Parallax", menuName = "Parallax Configuration / New Configuration")]
    public class ParallaxConfiguration : ScriptableObject
    {
        [SerializeField] private float _animationSpeed = 0.05f;
        public float AnimationSpeed => _animationSpeed;
    }
}

