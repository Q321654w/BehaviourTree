﻿namespace Features.BehaviourTrees
{
    public interface INode
    {
        bool Active();
        void Enter();
        void Execute();
        void Exit();
    }
}