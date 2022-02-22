using UnityEngine;

namespace Features.BehaviourTrees.INodes.Implementations.AnimatorNodes
{
    public class AnimatorBoolChangeNode : INode
    {
        private readonly IValue<bool> _value;
        private readonly string _sourceId;
        private readonly bool _defaultValue;
        private readonly Animator _animator;

        private bool _lastValue;

        public AnimatorBoolChangeNode(IValue<bool> value, string sourceId, bool defaultValue, Animator animator)
        {
            _value = value;
            _sourceId = sourceId;
            _defaultValue = defaultValue;
            _animator = animator;
        }

        public Status ExecutionStatus()
        {
            var changed = _lastValue != _value.Value();
            return changed ? Status.Success : Status.Running;
        }

        public void Enter()
        {
            Execute();
        }

        public void Execute()
        {
            var currentValue = _value.Value();
            _animator.SetBool(_sourceId, currentValue);
            _lastValue = currentValue;
        }

        public void Exit()
        {
            _animator.SetBool(_sourceId, _defaultValue);
        }
    }
}