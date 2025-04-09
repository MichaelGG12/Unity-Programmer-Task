using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private Animator animator;
    private InteractionFactory interactionFactory;
    [SerializeField] private Transform interactionPoint;
    [SerializeField] private float interactionRadius = 1f;
    [SerializeField] private LayerMask interactionLayer;

    private PlayerControls controls;
    private IInteractable currentInteractable;

    private void Awake()
    {
        controls = new PlayerControls();
        interactionFactory = gameObject.AddComponent<InteractionFactory>();
    }

    private void OnEnable()
    {
        controls.Enable();
        controls.InGame.Interact.performed += _ => TryInteract();
    }

    private void OnDisable()
    {
        controls.InGame.Interact.performed -= _ => TryInteract();
        controls.Disable();
    }

    private void Update()
    {
        DetectInteractable();
    }

    private void DetectInteractable()
    {
        Collider[] hits = Physics.OverlapSphere(interactionPoint.position, interactionRadius, interactionLayer);
        currentInteractable = null;

        foreach (Collider hit in hits)
        {
            if (hit.TryGetComponent(out IInteractable interactable))
            {
                currentInteractable = interactable;
                break;
            }
        }
    }

    private void TryInteract()
    {
        if (currentInteractable == null) return;

        currentInteractable.Interact();

        if (currentInteractable is IInteractionTypeProvider provider)
        {
            interactionFactory.HandleInteraction(animator, provider.Type);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (interactionPoint == null) return;
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(interactionPoint.position, interactionRadius);
    }
}