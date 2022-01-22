﻿using UnityEngine;

namespace BehaviourTree
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

        public void Enter()
        {
            _collider.Collided += OnCollided;
            _collider.CollisionBreaked += OnCollisionBraked;
        }
        
        public bool Execute()
        {
            if (_isActive)
                return _isActive;
            
            _collider.Collided -= OnCollided;
            _collider.CollisionBreaked -= OnCollisionBraked;
            
            return _isActive;
        }
    }
}