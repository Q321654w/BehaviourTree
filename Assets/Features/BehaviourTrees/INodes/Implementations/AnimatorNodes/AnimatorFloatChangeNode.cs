using System;
using Features.BehaviourTrees;
using UnityEngine;

namespace MVQ
{
    public class AnimatorFloatChangeNode : INode
    {
        private readonly IValue<float> _value;
        private readonly string _sourceId;
        private readonly float _defaultValue;
        private readonly Animator _animator;
        
        private float _lastValue;

        private const float TOLERANCE = 0.01f;

        public AnimatorFloatChangeNode(IValue<float> value, string animationId, float defaultValue, Animator animator)
        {
            _value = value;
            _sourceId = animationId;
            _defaultValue = defaultValue;
            _animator = animator;
        }

        public Status ExecutionStatus()
        {
            var changed = Math.Abs(_lastValue - _value.Value()) > TOLERANCE;
            return changed ? Status.Idle : Status.Success;
        }

        public void Enter()
        {
            Execute();
        }

        public void Execute()
        {
            var currentValue = _value.Value();
            _animator.SetFloat(_sourceId, currentValue);
            _lastValue = currentValue;
        }

        public void Exit()
        {
            _animator.SetFloat(_sourceId, _defaultValue);
        }
    }
}