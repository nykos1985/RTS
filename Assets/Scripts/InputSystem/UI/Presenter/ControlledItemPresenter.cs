using System;
using System.Linq;
using Abstraction;
using InputSystem.UI.View;
using UnityEngine;
using UnityEngine.UI;
using Utils;

namespace InputSystem.UI.Presenter
{

    public class ControlledItemPresenter : MonoBehaviour
    {
        [SerializeField] private SelectedItem _item;
        [SerializeField] private ControlledItemView _controlledItemView;
        [SerializeField] private AssetsContext _context;

        private ISelectableItem _currentSelected;

        protected void Start()
        {
            _item.OnControl += SetButtons;
            SetButtons();
            _controlledItemView.OnClick += HandleClick;
        }

        private void SetButtons()
        {
            if (_currentSelected == _item.SelectedValue)
            {
                return;
            }

            _currentSelected = _item.SelectedValue;
            _controlledItemView.ClearButtons();

            var commandExecutors = (_currentSelected as Component)?.GetComponentsInParent<ICommandExecutor>().ToList();

            _controlledItemView.SetButtons(commandExecutors);

        }

        private void HandleClick(ICommandExecutor executor)
        {

            if (executor as CommandExecutorBase<IProduceUnitCommand>)
            {
                executor.Execute(_context.Inject(new ProduceUnitCommand()));
            }
            else
            {
                if (executor as CommandExecutorBase<IAttackCommand>)
                {
                    executor.Execute(_context.Inject(new AttackCommand()));
                }
                else
                {
                    if (executor as CommandExecutorBase<IMoveCommand>)
                    {
                        executor.Execute(_context.Inject(new MoveCommand()));
                    }
                    else
                    {
                        if (executor as CommandExecutorBase<IPatrolCommand>)
                        {
                            executor.Execute(_context.Inject(new PatrolCommand()));
                        }
                        else
                        {
                            if (executor as CommandExecutorBase<IHoldPositionCommand>)
                            {
                                executor.Execute(_context.Inject(new HoldPositionCommand()));
                            }
                            else
                            {
                                throw new ApplicationException($"{nameof(ControlledItemPresenter)}." +
                                                               $"{nameof(HandleClick)}: Unknown type of commands " +
                                                               $"executor: {executor.GetType().FullName}!");

                            }
                        }
                    }
                }
            }

        }
    }
}