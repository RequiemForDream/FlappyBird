using System;

namespace Common.Interfaces
{
    public interface IDestroyable
    {
        event Action OnDestroyHandler;
    }
}
