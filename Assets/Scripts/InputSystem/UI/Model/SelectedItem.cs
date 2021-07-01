using System;
using Abstraction;
using UnityEditor.Experimental.GraphView;
using UnityEngine;


[CreateAssetMenu(fileName = "SelectedItem", menuName="Strategy/SelectedItem")]
public class SelectedItem : ScriptableObject
{
   private ISelectableItem _currentSelectedValue;
   public ISelectableItem SelectedValue => _currentSelectedValue;

   public void SetValue(ISelectableItem item)
   {
      _currentSelectedValue = item;
      OnSelected?.Invoke();
      OnControl?.Invoke();
   }

   public Action OnSelected;
   public Action OnControl;
}
