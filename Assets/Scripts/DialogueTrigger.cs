using UnityEngine;

public class DialogueTrigger : MonoBehaviour, IInteractable, IInteractionTypeProvider
{
    public InteractionType Type => InteractionType.Dialogue;

    public void Interact()
    {
        Debug.Log("Started dialogue.");
    }
}