using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private Animator animator;
    [SerializeField] private PlayerInputReader inputReader;

    private Rigidbody rb;

    private bool IsMoving => Mathf.Abs(inputReader.MoveInput.x) > 0.01f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        animator.SetBool("IsMoving", IsMoving);

        if (IsMoving)
        {
            float direction = inputReader.MoveInput.x > 0 ? 1f : -1f;
            transform.rotation = Quaternion.Euler(0f, direction == 1f ? 0f : 180f, 0f);
        }
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(0f, 0f, inputReader.MoveInput.x);
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}