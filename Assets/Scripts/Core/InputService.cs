using Core.Interfaces;
using System;
using UnityEngine;

namespace Core
{
    public class InputService : IInputService
    {
        public event Action OnTapScreen;

        private readonly Updater _updater;

        public InputService(Updater updater)
        {
            _updater = updater;
            Initialize();
        }

        private void Initialize()
        {
            _updater.AddListener(this); 
        }
        
        public void Tick(float deltaTime)
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Began)
                {
                    OnTapScreen?.Invoke();
                }
            }

            if (Input.GetMouseButtonDown(0))
            {
                OnTapScreen?.Invoke();
            }
        }
    }
}
