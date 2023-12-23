using Character;
using Common.Interfaces;
using System;
using UnityEngine;

namespace Pipes
{
    public class PointTrigger : MonoBehaviour, IDetector
    {
        public event Action OnCollided;

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out CharacterView character))
            {
                OnCollided.Invoke();
            }
        }
    }
}
