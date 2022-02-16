﻿using Features.BehaviourTrees;

namespace BehaviourTrees
{
    public class BehaviorTreeNode : INode
    {
        private readonly BehaviourTree _behaviourTree;
        private bool _isActive;

        public BehaviorTreeNode(BehaviourTree behaviourTree)
        {
            _behaviourTree = behaviourTree;
        }

        public bool Active()
        {
            return _behaviourTree.IsActive();
        }

        public void Enter()
        {
            _behaviourTree.Start();
            _isActive = true;
        }

        public void Execute()
        {
            if (_isActive)
                _behaviourTree.Update();
        }

        public void Exit()
        {
            _behaviourTree.Reset();
        }
    }
}