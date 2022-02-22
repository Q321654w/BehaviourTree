using System;
using UnityEngine;

namespace Features.BehaviourTrees.Common
{
    [RequireComponent(typeof(Collider))]
    public class CustomCollider : MonoBehaviour
    {
        public event Action<Collision> Collided;
        public event Action<Collision> CollisionBraked;
        
        private void OnCollisionEnter(Collision other)
        {
            Collided?.Invoke(other);
        }

        private void OnCollisionExit(Collision other)
        {
            CollisionBraked?.Invoke(other);
        }
    }
}