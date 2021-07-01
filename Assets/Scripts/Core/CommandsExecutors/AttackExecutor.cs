using Abstraction;
using UnityEngine;

namespace Core.CommandsExecutors
{
    public class AttackExecutor : CommandExecutorBase<IAttackCommand>
    {
        protected override void ExecuteExactCommand(IAttackCommand command)
        {
            Debug.Log($"{name} is attacking");
        }
    }
}