using Background;
using Character.Interfaces;
using Pipes.Generation;
using Sound;

namespace StateMachine
{
    public class GameplayState : State
    {
        private readonly PipeSpawner _pipeSpawner;
        private readonly ICharacter _mainCharacter;
        private readonly Parallax _background;
        private readonly Parallax _ground;
        private readonly MusicPlayer _musicPlayer;

        public GameplayState(PipeSpawner pipeSpawner, ICharacter mainCharacter, Parallax background, Parallax ground,
            MusicPlayer musicPlayer)
        {
            _mainCharacter = mainCharacter;
            _pipeSpawner = pipeSpawner;
            _background = background;
            _ground = ground;
            _musicPlayer = musicPlayer;
        }

        public override void Enter()
        {
            _pipeSpawner.Initialize();
            _mainCharacter.Initialize();
            _musicPlayer.Initialize();
        }

        public override void Exit()
        {
            _pipeSpawner.Reset();
            _mainCharacter.Reset();
            _background.Clear();
            _ground.Clear();
            _musicPlayer.Reset();
        }
    }
}
