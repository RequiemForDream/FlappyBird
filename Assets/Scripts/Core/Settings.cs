using UnityEngine;

namespace Core
{
    [CreateAssetMenu(fileName = "Settings Configuration", menuName = "Configuration / New Settings Configuration")]
    public class Settings : ScriptableObject
    {
        public float Volume;
        public DifficultyType DifficultyType;
    }
}

