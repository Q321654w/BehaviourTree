using UnityEngine;

namespace BehaviourTree
{
    public class RandomNode : INode
    {
        public void Enter()
        {
            
        }

        public bool Execute()
        {
            return Random.value > 0.5f;
        }
    }
}