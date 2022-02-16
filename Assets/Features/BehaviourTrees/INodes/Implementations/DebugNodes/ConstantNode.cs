﻿﻿ using Features.BehaviourTrees;

   namespace BehaviourTrees
{
    public class ConstantNode : INode
    {
        private readonly bool _isActive;

        public ConstantNode(bool isActive)
        {
            _isActive = isActive;
        }

        public bool Active()
        {
            return _isActive;
        }

        public void Enter()
        {
            
        }

        public void Execute()
        {
           
        }

        public void Exit()
        {
            throw new System.NotImplementedException();
        }
    }
}