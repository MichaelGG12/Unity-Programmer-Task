using UnityEngine;

public class PickUpItem : MonoBehaviour, IInteractable, IInteractionTypeProvider
{
    public InteractionType Type => InteractionType.PickUp;

    public void Interact()
    {
        Debug.Log("Picked up item!");
    }
}