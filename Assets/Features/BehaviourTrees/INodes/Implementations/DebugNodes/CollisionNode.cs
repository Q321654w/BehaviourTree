using Features.BehaviourTrees.Common;
using UnityEngine;

namespace Features.BehaviourTrees.INodes.Implementations.DebugNodes
{
    public class CollisionNode : INode
    {
        private readonly CustomCollider _collider;
        private Status _status;

        public CollisionNode(CustomCollider collider)
        {
            _collider = collider;
            _status = Status.Idle;
            
            _collider.Collided += OnCollided;
            _collider.CollisionBraked += OnCollisionBraked;
        }

        private void OnCollisionBraked(Collision obj)
        {
            _status = Status.Failure;
        }
        
        private void OnCollided(Collision obj)
        {
            _status = Status.Success;
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
        }

        public void Exit()
        {
            _status = Status.Idle;
        }
    }
}