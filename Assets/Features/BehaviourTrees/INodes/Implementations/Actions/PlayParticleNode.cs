using UnityEngine;

namespace Features.BehaviourTrees.INodes.Implementations.Actions
{
    public class PlayParticleNode : INode
    {
        private readonly Transform _viewTransform;
        private readonly ParticleSystem _prefab;
        private Status _status;

        public PlayParticleNode(ParticleSystem prefab, Transform viewTransform)
        {
            _prefab = prefab;
            _viewTransform = viewTransform;
            _status = Status.Idle;
        }

        public Status ExecutionStatus()
        {
            return _status;
        }

        public void Enter()
        {
            _status = Status.Running;
        }

        public void Execute()
        {
            _status = Status.Success;
            Object.Instantiate(_prefab, _viewTransform.position, _viewTransform.rotation);
        }

        public void Exit()
        {
            _status = Status.Idle;
        }
    }
}