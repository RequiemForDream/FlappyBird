using Core.Interfaces;
using UnityEngine;

namespace Pipes
{
    public interface IPipe : IUpdateListener
    {
        PipeView PipeView { get; }
        void SetParent(Transform parent);
        void SetPosition(Vector3 position);
    }
}
