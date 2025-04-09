using UnityEngine;

public interface IInventoryItemFactory
{
    InventoryItem CreateItem(ItemSO item, Transform parent);
}