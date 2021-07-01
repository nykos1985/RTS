using Abstraction;
using UnityEngine;

namespace Core.CommandsExecutors
{
    public class MoveExecutor : CommandExecutorBase<IMoveCommand>
    {
        protected override void ExecuteExactCommand(IMoveCommand command)
        {
            Debug.Log($"{name} is moving");
        }
    }
}
