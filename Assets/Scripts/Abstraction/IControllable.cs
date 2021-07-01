using UnityEngine;
using UnityEngine.UI;

namespace Abstraction
{
    public interface IControllable
    {
        Button ButtonMove { get; }
        Button ButtonAttack { get; }
        Button ButtonPatrol { get; }
        Button ButtonHoldPosition { get; }
        
    }

}