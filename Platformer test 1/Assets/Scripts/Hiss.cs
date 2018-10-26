using UnityEngine;

public class Hiss : MonoBehaviour
{
    public float hissSpeed;
    public float depth = 8.0f;

    public Playercontroller player;

    private void Update()
    {
        transform.position = new Vector3(Mathf.PingPong(Time.time * hissSpeed, depth * 3f) - depth, transform.position.y, transform.position.z);
    }
}

    