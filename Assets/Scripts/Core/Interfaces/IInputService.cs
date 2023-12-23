using System;

namespace Core.Interfaces
{
    public interface IInputService : IUpdateListener
    {
        event Action OnTapScreen;
    }
}
