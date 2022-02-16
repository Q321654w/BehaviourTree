using BehaviourTrees;
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

        public AnimatorFloatChangeNode(IValue<float> value, string animationId, float defaultValue, Animator animator)
        {
            _value = value;
            _sourceId = animationId;
            _defaultValue = defaultValue;
            _animator = animator;
        }

        public void Enter()
        {
            Execute();
        }

        public bool Active()
        {
            var currentValue = _value.Value();
            var active = _lastValue.CompareTo(currentValue) != 0;
            
            _lastValue = currentValue;
            
            return active;
        }

        public void Execute()
        {
            var currentValue = _value.Value();

            _animator.SetFloat(_sourceId, currentValue);
        }

        public void Exit()
        {
            _animator.SetFloat(_sourceId, _defaultValue);
        }
    }
}