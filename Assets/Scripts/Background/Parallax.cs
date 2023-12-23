using Core;
using Core.Interfaces;
using UnityEngine;

namespace Background
{
    public class Parallax : MonoBehaviour, IUpdateListener
    {
        private MeshRenderer _meshRenderer;
        private ParallaxConfiguration _parallaxConfiguration;
        private Updater _updater;

        public void Initialize(Updater updater, ParallaxConfiguration parallaxConfiguration)
        {
            _meshRenderer = GetComponent<MeshRenderer>();
            _updater = updater;
            _parallaxConfiguration = parallaxConfiguration;
            _updater.AddListener(this);
        }

        public void Tick(float deltaTime)
        {
            _meshRenderer.material.mainTextureOffset += new Vector2(_parallaxConfiguration.AnimationSpeed * deltaTime, 0);
        }
    }
}

