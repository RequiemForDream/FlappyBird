using Background;
using Character;
using Pipes;
using Pipes.Generation;
using UnityEngine;

namespace Core
{
    [CreateAssetMenu(fileName = "Game Configuration", menuName = "Configuration / New Game Configuration")]
    public class GameConfiguration : ScriptableObject
    {
        [SerializeField] private ParallaxConfiguration _backgroundConfiguration;
        [SerializeField] private ParallaxConfiguration _groundConfiguration;
        [SerializeField] private PipeSpawnConfiguration _pipeSpawnConfiguration;
        [SerializeField] private CharacterConfiguration _characterConfiguration;

        [Header("Easy Difficult")]
        [SerializeField] private PipeConfiguration _easyDifficultPipeConfiguration;
        [Header("Easy Difficult")]
        [SerializeField] private PipeConfiguration _mediumDifficultPipeConfiguration;
        [Header("Easy Difficult")]
        [SerializeField] private PipeConfiguration _hardDifficultPipeConfiguration;
        
        public CharacterConfiguration CharacterConfiguration => _characterConfiguration;
        public PipeSpawnConfiguration PipeSpawnConfiguration => _pipeSpawnConfiguration;
        public ParallaxConfiguration BackgroundConfiguration => _backgroundConfiguration;
        public ParallaxConfiguration GroundConfiguration => _groundConfiguration;
        public PipeConfiguration EasyDifficultPipeConfiguration => _easyDifficultPipeConfiguration;
        public PipeConfiguration MediumDifficultPipeConfiguration => _mediumDifficultPipeConfiguration;
        public PipeConfiguration HardDifficultPipeConfiguration => _hardDifficultPipeConfiguration;
    }
}

