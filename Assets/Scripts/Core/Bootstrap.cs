using Background;
using Character.Interfaces;
using Factories;
using Pipes;
using Pipes.Generation;
using Sound;
using UI;
using UnityEngine;

namespace Core
{
    public class Bootstrap : MonoBehaviour
    {
        [SerializeField] private GameConfiguration _gameConfiguration;
        [SerializeField] private Parallax _background;
        [SerializeField] private Parallax _ground;
        [SerializeField] private Updater _updater;
        [SerializeField] private ScoreView _scoreView;
        [SerializeField] private GameOverScreen _gameOverScreen;
        [SerializeField] private Settings _settings;
        [SerializeField] private AudioSource _audioSource;

        private void Awake()
        {
            BindParallaxes();
            var musicPlayer = BindMusicPlayer();
            var scorCounter = BindScoreCounter();
            _scoreView.Initialize(scorCounter);
            var inputService = BindInputService();
            var character = BindCharacter(inputService);
            var pipeFactory = BindPipeFactory(scorCounter);
            var pipeSpawner = BindPipeGenerator(pipeFactory);
            var level = BindLevel(character, pipeSpawner, musicPlayer);
            level.Start();
        }

        private InputService BindInputService()
        {
            var inputService = new InputService(_updater);
            return inputService;
        }

        private Level BindLevel(ICharacter character, PipeSpawner pipeSpawner, MusicPlayer musicPlayer)
        {
            return new Level(character, pipeSpawner, _gameOverScreen, _background, _ground, musicPlayer);
        }

        private ICharacter BindCharacter(InputService inputService)
        {
            var characterFactory = new CharacterFactory(_updater, _gameConfiguration.CharacterConfiguration, inputService);
            return characterFactory.Create();
        }

        private MusicPlayer BindMusicPlayer()
        {
            return new MusicPlayer(_settings, _audioSource);
        }

        private void BindParallaxes()
        {
            _background.Initialize(_updater, _gameConfiguration.BackgroundConfiguration);
            _ground.Initialize(_updater, _gameConfiguration.GroundConfiguration);
        }

        private PipeFactory BindPipeFactory(ScoreCounter scoreCounter)
        {
            PipeConfiguration pipeConfiguration = null;

            switch (_settings.DifficultyType)
            {
                case DifficultyType.Easy:
                    pipeConfiguration = _gameConfiguration.EasyDifficultPipeConfiguration; 
                    break;
                case DifficultyType.Medium:
                    pipeConfiguration = _gameConfiguration.MediumDifficultPipeConfiguration;
                    break;
                case DifficultyType.Hard:
                    pipeConfiguration = _gameConfiguration.HardDifficultPipeConfiguration;
                    break;
            }

            var pipeFactory = new PipeFactory(_updater, pipeConfiguration, scoreCounter);
            return pipeFactory;
        }

        private PipeSpawner BindPipeGenerator(PipeFactory pipeFactory)
        {
            PipeSpawnConfiguration pipeSpawnConfiguration = null;

            switch (_settings.DifficultyType)
            {
                case DifficultyType.Easy:
                    pipeSpawnConfiguration = _gameConfiguration.EasyPipeSpawnConfiguration;
                    break;
                case DifficultyType.Medium:
                    pipeSpawnConfiguration = _gameConfiguration.MediumPipeSpawnConfiguration;
                    break;
                case DifficultyType.Hard:
                    pipeSpawnConfiguration = _gameConfiguration.HardPipeSpawnConfiguration;
                    break;
            }

            var pipeGenerator = new PipeSpawner(pipeFactory, pipeSpawnConfiguration, _updater);
            return pipeGenerator;
        }

        private ScoreCounter BindScoreCounter()
        {
            return new ScoreCounter();
        }
    }
}

