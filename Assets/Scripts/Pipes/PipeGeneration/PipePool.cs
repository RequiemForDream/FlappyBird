using Factories;
using System.Collections.Generic;
using UnityEngine;

namespace Pipes.Generation
{
    public class PipePool
    {
        private readonly PipeFactory _pipeFactory;
        private readonly int _poolCount;
        private readonly bool _autoExpand;
        private readonly GameObject _container;
        private List<IPipe> _pool;

        public PipePool(bool autoExpand, int poolCount, PipeFactory pipeFactory, GameObject container)
        {
            _autoExpand = autoExpand;
            _poolCount = poolCount;
            _pipeFactory = pipeFactory;
            _container = container;
        }

        public void CreatePool()
        {
            _pool = new List<IPipe>();

            for (int i = 0; i < _poolCount; i++)
            {
                SpawnObstacle();
            }
        }

        private IPipe SpawnObstacle(bool isActiveByDefault = false)
        {
            var pipe = _pipeFactory.Create();
            pipe.PipeView.gameObject.SetActive(isActiveByDefault);
            pipe.SetParent(_container.transform);
            _pool.Add(pipe);
            return pipe;
        }

        public IPipe GetFreeElement()
        {
            if (HasFreeElement(out var element))
            {
                return element;
            }

            if (_autoExpand)
            {
                return SpawnObstacle(true);
            }

            throw new System.Exception($"There is no free elements in pool of type {typeof(IPipe)}");
        }

        private bool HasFreeElement(out IPipe element)
        {
            foreach (var pipe in _pool)
            {
                if (!pipe.PipeView.gameObject.activeInHierarchy)
                {
                    element = pipe;
                    pipe.PipeView.gameObject.SetActive(true);
                    return true;
                }
            }

            element = null;
            return false;
        }

        public void Clear()
        {
            foreach (var pipe in _pool)
            {
                pipe.PipeView.gameObject.SetActive(false);
            }
        }
    }
}

