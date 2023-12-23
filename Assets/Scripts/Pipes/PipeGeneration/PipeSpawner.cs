using Core;
using Core.Interfaces;
using Factories;
using UnityEngine;
using Utilities;

namespace Pipes.Generation
{
    public class PipeSpawner : IUpdateListener
    {
        private readonly PipeFactory _pipeFactory;
        private readonly PipeSpawnConfiguration _pipeSpawnConfiguration;
        private readonly Updater _updater;
        private GameObject _pipeContainer = new GameObject("Pipe Container");
        private PipePool _pipePool;

        private float _currentTime;

        public PipeSpawner(PipeFactory pipeFactory, PipeSpawnConfiguration pipeSpawnConfiguration, Updater updater)
        {
            _pipeFactory = pipeFactory;
            _pipeSpawnConfiguration = pipeSpawnConfiguration;
            _updater = updater;
            _updater.AddListener(this);
            CreatePool();
            _currentTime = _pipeSpawnConfiguration.SpawnRate;
        }

        private void CreatePool()
        {
            _pipePool = new PipePool(_pipeSpawnConfiguration.AutoExpand, _pipeSpawnConfiguration.Count, _pipeFactory, _pipeContainer);
            _pipePool.CreatePool();
        }

        public void Tick(float deltaTime)
        {
            _currentTime -= Time.deltaTime;
            if (_currentTime < 0)
            {
                SpawnPipe();
                _currentTime = _pipeSpawnConfiguration.SpawnRate;
            }
        }

        private void SpawnPipe()
        {
            var pipe = _pipePool.GetFreeElement();
            var y = 1f * Random.Range(_pipeSpawnConfiguration.MinHeight, _pipeSpawnConfiguration.MaxHeight);
            Vector3 position = new Vector3(DataClass.RIGHT_EDGE, y, 0f);
            pipe.SetPosition(position);
        }
    }
}
