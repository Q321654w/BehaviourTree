using System;
using UnityEngine;

namespace BehaviourTrees
{
    [RequireComponent(typeof(Collider))]
    public class CustomCollider : MonoBehaviour
    {
        public event Action<Collision> Collided;
        public event Action<Collision> CollisionBreaked;
        
        private void OnCollisionEnter(Collision other)
        {
            Collided?.Invoke(other);
        }

        private void OnCollisionExit(Collision other)
        {
            CollisionBreaked?.Invoke(other);
        }
    }
}