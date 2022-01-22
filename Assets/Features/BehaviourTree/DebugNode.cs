using UnityEngine;

namespace BehaviourTree
{
    public class DebugNode : INode
    {
        public void Enter()
        {
            Debug.Log("Debug Node Entered");
        }

        public bool Execute()
        {
            return true;
        }
    }
}