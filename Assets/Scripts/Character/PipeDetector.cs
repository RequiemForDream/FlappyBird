using Common.Interfaces;
using Pipes;
using System;
using UnityEngine;

namespace Character
{
    public class PipeDetector : MonoBehaviour, IDetector
    {
        public event Action OnCollided;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out Obstacle obstacle))
            {
                OnCollided?.Invoke();
                Debug.Log("Detected");
            }
        }
    }
}
