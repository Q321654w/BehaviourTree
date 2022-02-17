﻿namespace Features.BehaviourTrees
{
    public interface INode
    {
        Status ExecutionStatus();
        void Enter();
        void Execute();
        void Exit();
    }

    public enum Status
    {
        Idle,
        Running,
        Failure,
        Success,
    }
}