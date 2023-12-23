using System;
using UnityEngine;

namespace Pipes
{
    [Serializable]
    public struct PipeModel
    {
        [SerializeField] private float _speed;
        [SerializeField] private int _pointsToAdd;
        
        public float Speed => _speed;
        public int PointsToAdd => _pointsToAdd;
    }
}
