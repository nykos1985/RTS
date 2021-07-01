using System.Collections;
using Abstraction;
using UnityEngine.UI;
using UnityEngine;

namespace InputSystem
{


    public class OutlinePresenter : MonoBehaviour
    {
        [SerializeField] private SelectedItem _selectable;

        private OutlineView[] _outlineSelectors;
        private ISelectableItem _currentSelectable;

        private void Start()
        {
            
            onSelected(_selectable.SelectedValue);
        }

        private void onSelected(ISelectableItem selectable)
        {
            if (_currentSelectable == selectable)
            {
                return;
            }

            _currentSelectable = selectable;

            setSelected(_outlineSelectors, false);
            _outlineSelectors = null;

            if (selectable != null)
            {
                _outlineSelectors = (selectable as Component).GetComponentsInParent<OutlineView>();
                setSelected(_outlineSelectors, true);
            }

            static void setSelected(OutlineView[] selectors, bool value)
            {
                if (selectors != null)
                {
                    for (int i = 0; i < selectors.Length; i++)
                    {
                        selectors[i].SetSelected(value);
                    }
                }
            }
        }
    }
}