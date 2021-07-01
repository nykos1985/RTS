using System;
using Abstraction;
using UnityEngine;
using UnityEngine.UI;


namespace Core
{

    public class MainBuilding : CommandExecutorBase<IProduceUnitCommand>, ISelectableItem 
    {
        
        [SerializeField] private Sprite _icon;
        [SerializeField] private float _health;
        [SerializeField] private float _maxHealth;
        
        public Sprite Icon => _icon;
        public float Health => _health;
        public float MaxHealth => _maxHealth;

        private GameObject _spawnPoint;

        protected override void ExecuteExactCommand(IProduceUnitCommand command)
        {
            if (command.UnitPrefab == null)
            {
                Debug.LogError("No prefab to produce unit");
                return;
            }

            _spawnPoint=GameObject.FindGameObjectWithTag("SpawnPoint");
            Instantiate(command.UnitPrefab, _spawnPoint.transform.position, Quaternion.identity);
        }
    }
}