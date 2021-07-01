using UnityEngine;
using UnityEngine.UI;

public class SelectedItemPresenter : MonoBehaviour
{
    [SerializeField] private SelectedItem _item;
    [SerializeField] private SelectedItemView _view;

    protected void Start()
    {
        _item.OnSelected += UpdateView;
        UpdateView();
    }

    private void UpdateView()
    {
        var hasItem = _item.SelectedValue != null;
        _view.gameObject.SetActive(hasItem);
        
        if (!hasItem)
        {
            return;
        }
        _view.Icon = _item.SelectedValue.Icon;
        _view.Text = $"{_item.SelectedValue.Health}/{_item.SelectedValue.MaxHealth}";
        _view.HealthPercent = _item.SelectedValue.Health / _item.SelectedValue.MaxHealth;
    }

}
