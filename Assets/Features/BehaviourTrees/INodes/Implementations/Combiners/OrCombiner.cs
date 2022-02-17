using Features.BehaviourTrees;

namespace BehaviourTrees
{
    public class OrCombiner : NodeCombiner
    {
        public OrCombiner(INode childNode, INode otherNodes) : base(childNode, otherNodes)
        {
        }


        public override Status ExecutionStatus()
        {
            var firstChildStatus = ChildNode.ExecutionStatus();
            var secondChildStatus = ChildNode.ExecutionStatus();

            if (firstChildStatus == Status.Idle && secondChildStatus == Status.Idle)
                return Status.Idle;

            if (firstChildStatus == Status.Running || secondChildStatus == Status.Running)
                return Status.Running;

            if (firstChildStatus == Status.Success || secondChildStatus == Status.Success)
                return Status.Success;

            return Status.Failure;
        }

        public override void Execute()
        {
            ChildNode.Execute();
            SecondNode.Execute();
        }

        public override void Exit()
        {
            ChildNode.Exit();
            SecondNode.Exit();
        }
    }
}