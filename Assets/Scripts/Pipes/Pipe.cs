using Core;
using UI;
using UnityEngine;
using Utilities;

namespace Pipes
{
    public class Pipe : IPipe
    {
        public PipeView PipeView
        {
            get
            {
                return _pipeVew;
            }
        }

        private readonly PipeView _pipeVew;
        private readonly PipeModel _pipeModel;
        private readonly Updater _updater;
        private readonly ScoreCounter _scoreCounter;

        public Pipe(PipeView pipeVew, PipeModel pipeModel, Updater updater, ScoreCounter scoreCounter)
        {
            _pipeVew = pipeVew;
            _pipeModel = pipeModel;
            _updater = updater;
            _scoreCounter = scoreCounter;
            _updater.AddListener(this);
            _pipeVew.OnDestroyHandler += Destroy;
            _pipeVew.PointTrigger.OnCollided += AddScore;
        }

        public void SetParent(Transform parent)
        {
            _pipeVew.transform.parent = parent;
        }

        public void SetPosition(Vector3 position)
        {
           _pipeVew.transform.position = position;
        }

        public void Tick(float deltaTime)
        {
            _pipeVew.transform.position += Vector3.left * _pipeModel.Speed * deltaTime;

            if (_pipeVew.transform.position.x <= DataClass.LEFT_EDGE)
            {
                _pipeVew.gameObject.SetActive(false);
            }
        }

        private void AddScore()
        {
            _scoreCounter.AddScore(_pipeModel.PointsToAdd);
        }

        private void Destroy()
        {
            _updater.RemoveListener(this);
            _pipeVew.PointTrigger.OnCollided -= AddScore;
            _pipeVew.OnDestroyHandler -= Destroy;
        }
    }
}
