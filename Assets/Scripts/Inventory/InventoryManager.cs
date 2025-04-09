using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.EventSystems;
using UnityEditor;

public class InventoryManager : MonoBehaviour
{
    public InventorySlot[] InventorySlots;
    public GameObject InvetoryItemPrefab;
    int selectedSlot = -1;
    public ItemSO[] allItems;
    private InventoryItemFactory _itemFactory;

    [SerializeField] private DataPanel dataPanel;
    [SerializeField] private UIManager uiManager;

    private void Awake()
    {
        _itemFactory = new InventoryItemFactory(InvetoryItemPrefab);
    }

    private void Start()
    {
        LoadInventory();

        dataPanel.OnUseClicked += HandleUse;
        dataPanel.OnRemoveClicked += HandleRemove;
    }

    public void ChangeSelectedSlot(int slotIndex)
    {
        if (selectedSlot >= 0)
        {
            InventorySlots[selectedSlot].DeselectSlot();
        }

        InventorySlots[slotIndex].SelectSlot();
        selectedSlot = slotIndex;
    }

    public bool AddItem(ItemSO item)
    {
        for (int i = 0; i < InventorySlots.Length; i++)
        {
            InventorySlot slot = InventorySlots[i];
            InventoryItem itemItem = slot.GetComponentInChildren<InventoryItem>();
            if (itemItem == null)
            {
                SpawnNewItem(item, slot);
                return true;
            }
        }
        return false;
    }

    public void SpawnNewItem(ItemSO item, InventorySlot inventorySlot)
    {
        _itemFactory.CreateItem(item, inventorySlot.transform);
    }

    public ItemSO GetSelectedItem(bool use)
    {
        InventorySlot inventorySlot = InventorySlots[selectedSlot];
        InventoryItem itemSlot = inventorySlot.GetComponentInChildren<InventoryItem>();

        if (itemSlot != null)
        {
            ItemSO item = itemSlot.item; 

            if(use)
            {
                Destroy(itemSlot.gameObject);
            }
            return itemSlot.item;
        }
        return null;
    }

    private void HandleUse()
    {
        var item = dataPanel.GetCurrentItem();
        if (item != null)
        {
            item.item.UseItem();
            Destroy(item.gameObject);
            dataPanel.Hide();
        }
    }

    private void HandleRemove()
    {
        var item = dataPanel.GetCurrentItem();
        if (item != null)
        {
            Destroy(item.gameObject);
            dataPanel.Hide();
        }
    }

    #region Save/Load

    public void SaveInventory()
    {
        InventorySaveData data = new InventorySaveData();

        foreach (var slot in InventorySlots)
        {
            InventoryItem item = slot.GetComponentInChildren<InventoryItem>();
            if (item != null && item.item != null)
            {
                data.itemIDs.Add(item.item.ID);
            }
            else
            {
                data.itemIDs.Add("");
            }
        }
        InventorySaveSystem.Save(data);

        uiManager.ShowMessage("Successfully saved.");
    }

    public void LoadInventory()
    {
        InventorySaveData data = InventorySaveSystem.Load();

        if (data == null) return;

        for (int i = 0; i < InventorySlots.Length; i++)
        {
            if (i >= data.itemIDs.Count || string.IsNullOrEmpty(data.itemIDs[i]))
                continue;

            string id = data.itemIDs[i];
            ItemSO item = System.Array.Find(allItems, x => x.ID == id);
            if (item != null)
            {
                SpawnNewItem(item, InventorySlots[i]);
            }
        }
        Debug.Log("Inventory loaded.");
    }

    #endregion
}