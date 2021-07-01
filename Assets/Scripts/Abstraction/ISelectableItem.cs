using UnityEngine;


namespace Abstraction
{
    public interface ISelectableItem
    {
        Sprite Icon { get; }
        float Health { get; }
        float MaxHealth { get; }
        
    }
}