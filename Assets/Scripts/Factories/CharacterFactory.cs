using Character;
using Character.Interfaces;
using Core;
using Core.Interfaces;
using Factories.Interfaces;
using Object = UnityEngine.Object;

namespace Factories
{
    public class CharacterFactory : IFactory<ICharacter>
    {
        private readonly Updater _updater;
        private readonly CharacterConfiguration _characterConfiguration;
        private readonly IInputService _inputService;

        public CharacterFactory(Updater updater, CharacterConfiguration characterConfiguration, IInputService inputService)
        {
            _updater = updater;
            _characterConfiguration = characterConfiguration;
            _inputService = inputService;
        }

        public ICharacter Create()
        {
            var characterView = Object.Instantiate(_characterConfiguration.CharacterView);

            var character = new MainCharacter(characterView, _characterConfiguration.CharacterModel, _updater, _inputService);

            return character;
        }
    }
}
