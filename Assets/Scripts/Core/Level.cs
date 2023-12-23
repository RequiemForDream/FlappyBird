using Character.Interfaces;
using StateMachine;

namespace Core
{
    public class Level
    {
        private GameStateMachine _gameStateMachine;

        private readonly ICharacter _character;

        public Level(ICharacter character)
        {
            _character = character;
        }

        public void Start()
        {
            _character.OnCharacterDeath += GameOver;
            _gameStateMachine = new GameStateMachine();
            InitilializeStates();
        }

        private void InitilializeStates()
        {
            GameOverState gameOverState = new GameOverState();
            GameplayState gameplayState = new GameplayState();

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

