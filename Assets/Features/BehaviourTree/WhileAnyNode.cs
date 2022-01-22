using System.Collections.Generic;

namespace BehaviourTree
{
    public class WhileAnyNode : NodeSequenceDecorator
    {
        public WhileAnyNode(IEnumerable<INode> nodes) : base(nodes)
        {
        }

        protected override void InternalEnter()
        {
        }

        public override bool Execute()
        {
            var isActive = false;
            
            foreach (var node in Nodes)
            {
                isActive |= node.Execute();
            }

            return isActive;
        }
    }
}