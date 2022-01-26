﻿namespace BehaviourTrees
{
    public interface INode
    {
        bool IsActive();
        void Enter();
        void Execute();
        void Exit();
    }
}