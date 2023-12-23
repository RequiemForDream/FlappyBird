using Core.Interfaces;
using System;

namespace Character.Interfaces
{
    public interface ICharacter : IUpdateListener
    {
        event Action OnCharacterDeath;
    }
}
