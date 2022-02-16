using BehaviourTrees;
using Features.BehaviourTrees;
using UnityEngine;

namespace MVQ
{
    public class AnimatorBoolChangeNode : INode
    {
        private readonly IValue<bool> _value;
        private readonly string _sourceId;
        private readonly bool _defaultValue;
        private readonly Animator _animator;

        private bool _changed;
        private bool _lastValue;

        public AnimatorBoolChangeNode(IValue<bool> value, string sourceId, bool defaultValue, Animator animator)
        {
            _value = value;
            _sourceId = sourceId;
            _defaultValue = defaultValue;
            _animator = animator;
        }

        public void Enter()
        {
            Execute();
        }

        public bool Active()
        {
            return _value.Value();
        }

        public void Execute()
        {
            var value = _value.Value();
            
            _changed = value != _lastValue;
            _lastValue = value;

            _animator.SetBool(_sourceId, _changed);
        }

        public void Exit()
        {
            _animator.SetBool(_sourceId, _defaultValue);
        }
    }
}