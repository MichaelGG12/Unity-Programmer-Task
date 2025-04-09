using UnityEngine;

public class InventoryTest : MonoBehaviour
{
    public InventoryManager InventoryManager;
    public ItemSO[] Items;

    public void AddRandomIdem()
    {
        int randomNumber = Random.Range(0, Items.Length);

        bool result = InventoryManager.AddItem(Items[randomNumber]);

        if (result)
        {
            Debug.Log("Item successfully added to inventory.");
        }
        else
        {
            Debug.Log("Couldn't add item, inventory is full.");
        }

    }
}