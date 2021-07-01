using UnityEngine;

namespace Abstraction
{
    public interface ICommand
    {
        
    }

    public interface IProduceUnitCommand : ICommand
    {
        GameObject UnitPrefab { get; }
    }

    public interface IMoveCommand : ICommand
    {
        Vector3 Position { get; }
    }

    public interface IAttackCommand:ICommand
    {
        
    }

    public interface IPatrolCommand : ICommand
    {
        
    }

    public interface IHoldPositionCommand : ICommand
    {
        
    }
}