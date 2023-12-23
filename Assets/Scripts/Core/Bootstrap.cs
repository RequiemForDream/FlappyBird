using Background;
using Character.Interfaces;
using Factories;
using Pipes.Generation;
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

        private void Awake()
        {
            BindParallaxes();
            var scorCounter = BindScoreCounter();
            _scoreView.Initialize(scorCounter);
            var inputService = BindInputService();
            var character = BindCharacter(inputService);
            var pipeFactory = BindPipeFactory(scorCounter);
            var pipeSpawner = BindPipeGenerator(pipeFactory);
        }

        private InputService BindInputService()
        {
            var inputService = new InputService(_updater);
            return inputService;
        }

        private ICharacter BindCharacter(InputService inputService)
        {
            var characterFactory = new CharacterFactory(_updater, _gameConfiguration.CharacterConfiguration, inputService);
            return characterFactory.Create();
        }

        private void BindParallaxes()
        {
            _background.Initialize(_updater, _gameConfiguration.BackgroundConfiguration);
            _ground.Initialize(_updater, _gameConfiguration.GroundConfiguration);
        }

        private PipeFactory BindPipeFactory(ScoreCounter scoreCounter)
        {
            var pipeFactory = new PipeFactory(_updater, _gameConfiguration.EasyDifficultPipeConfiguration, scoreCounter);
            return pipeFactory;
        }

        private PipeSpawner BindPipeGenerator(PipeFactory pipeFactory)
        {
            var pipeGenerator = new PipeSpawner(pipeFactory, _gameConfiguration.PipeSpawnConfiguration, _updater);
            return pipeGenerator;
        }

        private ScoreCounter BindScoreCounter()
        {
            return new ScoreCounter();
        }
    }
}

