﻿namespace Factories.Interfaces
{
    public interface IFactory<out T>
    {
        T Create();
    }
}
