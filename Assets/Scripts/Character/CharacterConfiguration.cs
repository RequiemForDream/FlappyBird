using UnityEngine;

namespace Character
{
    [CreateAssetMenu(fileName = "CharacterConfiguration", menuName = "Character / New Character Configuration")]
    public class CharacterConfiguration : ScriptableObject
    {
        [SerializeField] private CharacterView _characterView;
        [SerializeField] private CharacterModel _characterModel;

        public CharacterView CharacterView => _characterView;
        public CharacterModel CharacterModel => _characterModel;
    }
}
