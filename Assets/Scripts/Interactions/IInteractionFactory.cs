using UnityEngine;

public interface IInteractionFactory
{
    public void HandleInteraction(Animator animator, InteractionType type);
}