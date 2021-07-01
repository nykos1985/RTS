using Abstraction;
using UnityEngine;


namespace Core.CommandsExecutors
{
    public class PatrolCommand : CommandExecutorBase<IPatrolCommand>
    {
        protected override void ExecuteExactCommand(IPatrolCommand command)
        {
            Debug.Log($"{name} is patroling");
        }
    }
}