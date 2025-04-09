using UnityEngine;

public class InventoryItemFactory : IInventoryItemFactory
{
    private readonly GameObject itemPrefab;

    public InventoryItemFactory(GameObject prefab)
    {
        itemPrefab = prefab;
    }

    public InventoryItem CreateItem(ItemSO item, Transform parent)
    {
        GameObject obj = Object.Instantiate(itemPrefab, parent);
        InventoryItem inventoryItem = obj.GetComponent<InventoryItem>();
        inventoryItem.InitItem(item);
        return inventoryItem;
    }
}