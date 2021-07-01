using UnityEngine;

namespace Abstraction
{
    public interface ICommandExecutor
    {
        void Execute(ICommand command);
    }

    public abstract class CommandExecutorBase<T> : MonoBehaviour, ICommandExecutor where T : ICommand
    {
        public void Execute(ICommand command)
        {
            ExecuteExactCommand((T) command);
        }

        protected abstract void ExecuteExactCommand(T command);
    }
}