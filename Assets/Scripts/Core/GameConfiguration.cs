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
        [SerializeField] private CharacterConfiguration _characterConfiguration;

        [Header("Easy Difficult")]
        [SerializeField] private PipeSpawnConfiguration _easyPipeSpawnConfiguration;
        [SerializeField] private PipeConfiguration _easyDifficultPipeConfiguration;
        [Header("Easy Difficult")]
        [SerializeField] private PipeSpawnConfiguration _mediumPipeSpawnConfiguration;
        [SerializeField] private PipeConfiguration _mediumDifficultPipeConfiguration;
        [Header("Easy Difficult")]
        [SerializeField] private PipeSpawnConfiguration _hardPipeSpawnConfiguration;
        [SerializeField] private PipeConfiguration _hardDifficultPipeConfiguration;
        
        public CharacterConfiguration CharacterConfiguration => _characterConfiguration;
        public PipeSpawnConfiguration PipeSpawnConfiguration => _easyPipeSpawnConfiguration;
        public ParallaxConfiguration BackgroundConfiguration => _backgroundConfiguration;
        public ParallaxConfiguration GroundConfiguration => _groundConfiguration;
        public PipeConfiguration EasyDifficultPipeConfiguration => _easyDifficultPipeConfiguration;
        public PipeSpawnConfiguration EasyPipeSpawnConfiguration => _easyPipeSpawnConfiguration;
        public PipeConfiguration MediumDifficultPipeConfiguration => _mediumDifficultPipeConfiguration;
        public PipeSpawnConfiguration MediumPipeSpawnConfiguration => _mediumPipeSpawnConfiguration;
        public PipeConfiguration HardDifficultPipeConfiguration => _hardDifficultPipeConfiguration;
        public PipeSpawnConfiguration HardPipeSpawnConfiguration => _hardPipeSpawnConfiguration;
    }
}

