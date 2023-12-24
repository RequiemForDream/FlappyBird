using Background;
using Character.Interfaces;
using Pipes.Generation;
using Sound;
using StateMachine;
using UI;

namespace Core
{
    public class Level
    {
        private GameStateMachine _gameStateMachine;

        private readonly ICharacter _character;
        private readonly PipeSpawner _pipeSpawner;
        private readonly GameOverScreen _gameOverScreen;
        private readonly Parallax _background;
        private readonly Parallax _ground;
        private readonly MusicPlayer _musicPlayer;

        public Level(ICharacter character, PipeSpawner pipeSpawner, GameOverScreen gameOverScreen, Parallax background,
            Parallax ground, MusicPlayer musicPlayer)
        {
            _character = character;
            _pipeSpawner = pipeSpawner;
            _gameOverScreen = gameOverScreen;
            _background = background;
            _ground = ground;
            _musicPlayer = musicPlayer;
        }

        public void Start()
        {
            _character.OnCharacterDeath += GameOver;
            _gameStateMachine = new GameStateMachine();
            InitilializeStates();
        }

        private void InitilializeStates()
        {
            GameOverState gameOverState = new GameOverState(_gameOverScreen);
            GameplayState gameplayState = new GameplayState(_pipeSpawner, _character, _background, _ground, _musicPlayer);

            _gameStateMachine.AddState<GameOverState>(gameOverState);
            _gameStateMachine.AddState<GameplayState>(gameplayState);

            _gameStateMachine.ChangeState<GameplayState>();
        }

        private void GameOver()
        {
            _gameStateMachine.ChangeState<GameOverState>();
        }
    }
}

