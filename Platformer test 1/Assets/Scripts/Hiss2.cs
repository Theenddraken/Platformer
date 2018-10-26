using UnityEngine;

public class Hiss2 : MonoBehaviour {

    public float hissSpeed;
    public float depth = -1.2f;

    public Playercontroller player;

    private void Update()
    {
        transform.position = new Vector3(transform.position.x, Mathf.PingPong(Time.time * hissSpeed, depth * 3f) - depth, transform.position.z);
    }
}
