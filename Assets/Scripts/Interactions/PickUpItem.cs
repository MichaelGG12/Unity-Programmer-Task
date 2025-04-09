using NUnit.Framework.Interfaces;
using UnityEngine;

public class PickUpItem : MonoBehaviour, IInteractable, IInteractionTypeProvider
{
    [SerializeField] private ItemSO item;
    private InventoryManager inventoryManager;

    public InteractionType Type => InteractionType.PickUp;

    private void Awake()
    {
        inventoryManager = FindFirstObjectByType<InventoryManager>();
    }

    public void Interact()
    {
        Debug.Log("Added to inventory.");
        inventoryManager.AddItem(item);
    }
}