using BehaviourTrees;
using Features.BehaviourTrees;
using UnityEngine;

namespace MVQ
{
    public class AnimatorIntChangeNode : INode
    {
        private readonly IValue<int> _value;
        private readonly string _sourceId;
        private readonly int _defaultValue;
        private readonly Animator _animator;
        
        private int _lastValue;

        public AnimatorIntChangeNode(IValue<int> value, string animationId, Animator animator) : this(value, animationId, 0, animator)
        {
        }

        public AnimatorIntChangeNode(IValue<int> value, string animationId, int defaultValue, Animator animator)
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
            var active = _lastValue.CompareTo(currentValue) > 0;
            
            _lastValue = currentValue;
            
            return active;
        }

        public void Execute()
        {
            var currentValue = _value.Value();

            _animator.SetInteger(_sourceId, currentValue);
        }

        public void Exit()
        {
            _animator.SetInteger(_sourceId, _defaultValue);
        }
    }
}