using System;

namespace Common.Interfaces
{
    public interface IDetector
    {
        event Action OnCollided;
    }
}
