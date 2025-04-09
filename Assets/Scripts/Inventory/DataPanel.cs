using System;
using UnityEngine;
using UnityEngine.UI;

public class DataPanel : MonoBehaviour
{
    [SerializeField] private Text selectedItemName;
    [SerializeField] private Image selectedItemIcon;
    [SerializeField] private Button useButton;
    [SerializeField] private Button removeButton;

    private InventoryItem _currentItem;

    public event Action OnUseClicked;
    public event Action OnRemoveClicked;

    private void Awake()
    {
        SetDataPanel(false, null);
        useButton.onClick.AddListener(() => OnUseClicked?.Invoke());
        removeButton.onClick.AddListener(() => OnRemoveClicked?.Invoke());
    }

    public void ShowItem(InventoryItem item)
    {
        _currentItem = item;

        if (item != null && item.item != null)
        {
            selectedItemName.text = item.item.Name;
            selectedItemIcon.sprite = item.item.Sprite;
            selectedItemIcon.enabled = true;
            useButton.interactable = true;
            removeButton.interactable = true;
        }
        else
        {
            SetDataPanel(false, null);
        }
    }

    public void Hide()
    {
        SetDataPanel(false, null);
    }

    public InventoryItem GetCurrentItem()
    {
        return _currentItem;
    }

    private void SetDataPanel(bool setData, InventoryItem? item)
    {
        selectedItemName.text = item != null ? item.item.Name : string.Empty;
        selectedItemIcon.sprite = item != null ? item.item.Sprite : null;
        selectedItemIcon.enabled = setData;
        useButton.interactable = setData;
        removeButton.interactable = setData;
    }
}
