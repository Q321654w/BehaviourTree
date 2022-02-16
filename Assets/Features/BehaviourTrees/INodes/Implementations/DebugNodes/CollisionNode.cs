using Features.BehaviourTrees;
using UnityEngine;

namespace BehaviourTrees
{
    public class CollisionNode : INode
    {
        private readonly CustomCollider _collider;
        private bool _isActive;

        public CollisionNode(CustomCollider collider)
        {
            _collider = collider;
            _isActive = true;
        }

        private void OnCollisionBraked(Collision obj)
        {
            _isActive = true;
        }
        
        private void OnCollided(Collision obj)
        {
            _isActive = false;
        }

        public bool Active()
        {
            return _isActive;
        }

        public void Enter()
        {
            _collider.Collided += OnCollided;
            _collider.CollisionBreaked += OnCollisionBraked;
        }
        
        public void Execute()
        {
        }

        public void Exit()
        {
            _collider.Collided -= OnCollided;
            _collider.CollisionBreaked -= OnCollisionBraked;
        }
    }
}