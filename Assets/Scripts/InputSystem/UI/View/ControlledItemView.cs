using System;
using System.Collections.Generic;
using System.Linq;
using Abstraction;
using UnityEngine;
using UnityEngine.UI;

namespace InputSystem.UI.View
{

    public class ControlledItemView : MonoBehaviour
    {
        [SerializeField] private Button _buttonMove;
        [SerializeField] private Button _buttonAttack;
        [SerializeField] private Button _buttonProduceUnit;
        [SerializeField] private Button _buttonPatrol;
        [SerializeField] private Button _buttonHoldPosition;

        private Dictionary<Type, Button> _buttons;
        
        public Action<ICommandExecutor> OnClick;

        protected void Start()
        {
            _buttons = new Dictionary<Type, Button>()
            {
                {typeof(CommandExecutorBase<IProduceUnitCommand>), _buttonProduceUnit},
                {typeof(CommandExecutorBase<IMoveCommand>), _buttonMove},
                {typeof(CommandExecutorBase<IAttackCommand>), _buttonAttack},
                {typeof(CommandExecutorBase<IHoldPositionCommand>), _buttonHoldPosition},
                {typeof(CommandExecutorBase<IPatrolCommand>), _buttonPatrol},
            };
        }

        public void SetButtons(List<ICommandExecutor> commandExecutors)
        {
            if (commandExecutors == null)
            {
                return;
            }
            
            foreach (var executor in commandExecutors)
            {
                var button=_buttons.FirstOrDefault(kvp => kvp.Key.IsInstanceOfType(executor)).Value;

                if (button != null)
                {
                    button.gameObject.SetActive(true);
                    button.onClick.AddListener(()=>OnClick?.Invoke(executor));
                }
                else
                {
                    Debug.LogError("No button found for executor type"+executor.GetType());
                }
            }
        }
        
        public void ClearButtons()
        {
            foreach (var kvp in _buttons)
            {
                kvp.Value.gameObject.SetActive(false);
                kvp.Value.onClick.RemoveAllListeners();
            }
        }
    }
}