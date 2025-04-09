using UnityEngine;

public class RotateItem : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 5f;

    void Update()
    {
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime, Space.World);
    }
}