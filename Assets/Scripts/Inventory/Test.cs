using UnityEngine;

public class Test : MonoBehaviour
{
    public InventoryManager InventoryManager;
    public ItemSO[] items;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            bool result = InventoryManager.AddItem(items[0]);

            if (result)
            {
                Debug.Log("added");
            }
            else
            {
                Debug.Log("not added");
            }

        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            InventoryManager.AddItem(items[1]);
        }
    }
}