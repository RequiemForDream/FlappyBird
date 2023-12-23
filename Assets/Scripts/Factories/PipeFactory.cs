using Core;
using Factories.Interfaces;
using Pipes;
using UI;
using Object = UnityEngine.Object;

namespace Factories
{
    public class PipeFactory : IFactory<IPipe>
    {
        private readonly Updater _updater;
        private readonly PipeConfiguration _pipeConfiguration;
        private readonly ScoreCounter _scoreCounter;

        public PipeFactory(Updater updater, PipeConfiguration pipeConfiguration, ScoreCounter scoreCounter)
        {
            _updater = updater;
            _pipeConfiguration = pipeConfiguration;
            _scoreCounter = scoreCounter;
        }

        public IPipe Create()
        {
            var pipeView = Object.Instantiate(_pipeConfiguration.PipeView);

            var pipe = new Pipe(pipeView, _pipeConfiguration.PipeModel, _updater, _scoreCounter);

            return pipe;
        }
    }
}
