using UnityEngine;

public class Follow : MonoBehaviour
{
    // Declared variable 'target'
    public Transform target;
    public Vector3 offset;

    private void LateUpdate()
    {
        transform.position = target.position + offset;
    }
}
