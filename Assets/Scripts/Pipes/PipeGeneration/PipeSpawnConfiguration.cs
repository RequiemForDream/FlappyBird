using UnityEngine;

namespace Pipes.Generation
{
    [CreateAssetMenu(fileName = "Pipe Spawn Configuration", menuName = "Pipes / New Spawn Configuration")]
    public class PipeSpawnConfiguration : ScriptableObject
    {
        [SerializeField] private float _minHeight;
        [SerializeField] private float _maxHeight;
        [SerializeField] private float _spawnRate;
        [SerializeField] private bool _autoExpand;
        [SerializeField] private int _count;

        public float MinHeight => _minHeight;
        public float MaxHeight => _maxHeight;
        public float SpawnRate => _spawnRate;
        public bool AutoExpand => _autoExpand;
        public int Count => _count;
    }
}
