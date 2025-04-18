using UnityEngine;

public enum InteractionType { PickUp, Dialogue }

public class InteractionFactory : MonoBehaviour, IInteractionFactory
{
    public void HandleInteraction(Animator animator, InteractionType type)
    {
        animator.SetInteger("InteractionType", (int)type);
        animator.SetTrigger("Interaction");
    }
}