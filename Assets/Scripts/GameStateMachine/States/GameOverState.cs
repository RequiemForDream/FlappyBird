using UI;

namespace StateMachine
{
    public class GameOverState : State
    {
        private readonly GameOverScreen _gameOverScreen;

        public GameOverState(GameOverScreen gameOverScreen)
        {
            _gameOverScreen = gameOverScreen;
        }

        public override void Enter()
        {
            _gameOverScreen.gameObject.SetActive(true);
        }
    }
}
