using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour, IDropHandler, IPointerDownHandler
{
    public Image image;
    public Color selectedColor, notSelectedColor;
    private DataPanel _dataPanel;
    public int slotIndex;
    private InventoryManager inventoryManager;

    private void Awake()
    {
        DeselectSlot();
        _dataPanel = FindFirstObjectByType<DataPanel>();
        inventoryManager = FindFirstObjectByType<InventoryManager>();
    }

    public void SelectSlot()
    {
        image.color = selectedColor;
    }

    public void DeselectSlot()
    {
        image.color = notSelectedColor;
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (transform.childCount == 0)
        {
            InventoryItem inventoryItemNew = eventData.pointerDrag.GetComponent<InventoryItem>();
            inventoryItemNew.parentAfterDrag = transform;
            inventoryManager.ChangeSelectedSlot(slotIndex);
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (_dataPanel != null && transform.childCount > 0)
        {
            var inventoryItem = GetComponentInChildren<InventoryItem>();
            _dataPanel.ShowItem(inventoryItem);
            inventoryManager.ChangeSelectedSlot(slotIndex);
        }
    }

}