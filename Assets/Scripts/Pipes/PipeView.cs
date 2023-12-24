using Common.Interfaces;
using System;
using UnityEngine;

namespace Pipes
{
    public class PipeView : MonoBehaviour, IDestroyable
    {
        public event Action OnDestroyHandler;

        [SerializeField] private PointTrigger _pointTrigger;

        public PointTrigger PointTrigger 
        { 
            get 
            { 
                return _pointTrigger; 
            }
        }

        private void OnDestroy()
        {
            OnDestroyHandler?.Invoke();
        }
    }
}
