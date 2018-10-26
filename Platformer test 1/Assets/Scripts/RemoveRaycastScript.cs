using UnityEngine;

public class RemoveRaycastScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Playercontroller player = collision.GetComponent<Playercontroller>();
        if (player != null)
        {
            Debug.Log("yes");
            player.checkIfGrounded = false;
        }
    }
}
