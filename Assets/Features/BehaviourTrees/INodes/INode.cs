﻿namespace Features.BehaviourTrees
{
    public interface INode
    {
        Status ExecutionStatus();
        void Enter();
        void Execute();
        void Exit();
    }
}