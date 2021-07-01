using UnityEngine;
using Abstraction;


namespace Core.CommandsExecutors
{
    public class HoldPositionExecutor : CommandExecutorBase<IHoldPositionCommand>
    {
        protected override void ExecuteExactCommand(IHoldPositionCommand command)
        {
            Debug.Log($"{name} is stopped");
        }

}
}