public interface IInteractable
{
    void Interact();
}

public interface IInteractionTypeProvider
{
    InteractionType Type { get; }
}
