using UnityEngine;

namespace Pipes
{
    [CreateAssetMenu(fileName = "PipeConfiguration", menuName = "Pipes / New Pipe Configuration")]
    public class PipeConfiguration : ScriptableObject
    {
        [SerializeField] private PipeView _pipeView;
        [SerializeField] private PipeModel _pipeModel;

        public PipeView PipeView => _pipeView;
        public PipeModel PipeModel => _pipeModel;
    }
}
