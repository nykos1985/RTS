using System;
using Abstraction;
using UnityEngine;
using Utils;

namespace InputSystem
{
    public class ProduceUnitCommand : IProduceUnitCommand
    {
        [InjectAsset("Ellen")] public GameObject _unitPrefab;
        public GameObject UnitPrefab => _unitPrefab;
    }

    public class AttackCommand : IAttackCommand
    {
        
    }
    
    public class MoveCommand : IAttackCommand
    {
        
    }
    
    public class PatrolCommand : IAttackCommand
    {
        
    }
    
    public class HoldPositionCommand : IAttackCommand
    {
        
    }
}