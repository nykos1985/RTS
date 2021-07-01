using Abstraction;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

namespace Core
{
    public class Unit : MonoBehaviour, ISelectableItem
    {
        [SerializeField] private float _maxHealth = 100;
        [SerializeField] private Sprite _icon;
        
        public float Health => _health;
        public float MaxHealth => _maxHealth;
        public Sprite Icon => _icon;

        private float _health = 100;
        
    }
}