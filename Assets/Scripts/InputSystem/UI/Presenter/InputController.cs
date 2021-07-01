using System;
using UnityEngine;
using Abstraction;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace InputSystem
{

    public class InputController : MonoBehaviour
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private SelectedItem _currentSelection;
        [SerializeField] private EventSystem _eventSystem;
        protected void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (_eventSystem.IsPointerOverGameObject()) return;
                if (Physics.Raycast(_camera.ScreenPointToRay(Input.mousePosition), out var hitInfo))
                {
                    var selectableItem = hitInfo.collider.GetComponent<ISelectableItem>();
                    _currentSelection.SetValue(selectableItem);
                }
                else
                {
                    _currentSelection.SetValue(null);
                }
            }
        }
    }
}
