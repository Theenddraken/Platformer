using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Playercontroller : MonoBehaviour {

    private Animator animator;

    [SerializeField]
    private float movementSpeed;
   

    public float groundedCheckLength = 10f;

    public float playerDamage = 25f;

    public float ymin = -5f;

    private bool facingRight;

    private Rigidbody2D myRigidbody;

    public float moveSpeed;

    public float jumpPower;

    private bool isGrounded;
    public bool checkIfGrounded = true;

    private HealthScript health;

    // Use this for initialization
    void Start ()
    {
        animator = GetComponent<Animator>();
        health = GetComponent<HealthScript>();
        facingRight = true;
        myRigidbody = GetComponent<Rigidbody2D>();
	}

    private void OnDestroy()
    {
        SceneManager.LoadScene(2);
    }

    // Update is called once per frame
    void Update ()
    {
        CheckGrounded();

        float horizontal = Input.GetAxis("Horizontal");
        if (!Mathf.Approximately(0f, horizontal))
        {
            animator.SetFloat("speed", 1f);
        }
        else
        {
            animator.SetFloat("speed", 0f);
        }

        HandleMovement(horizontal);

        Flip(horizontal);

        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (Input.GetKey(KeyCode.Space) && isGrounded)
            rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Spikes")
        {
            health.RemoveHealth(100f);
        }
    }

    private void CheckGrounded()
    {
        if (!checkIfGrounded) { return; }

        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, groundedCheckLength);
        if (hit.collider != null)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }

        Debug.DrawRay(transform.position, Vector2.down * groundedCheckLength, Color.red);
    }


    private void HandleMovement(float horizontal)
    {
        myRigidbody.velocity = new Vector2(horizontal * movementSpeed, myRigidbody.velocity.y);
        //animator.SetFloat("speed", Mathf.Abs(myRigidbody.velocity.x));
    }

    private void Flip(float horizontal)
    {
        if (horizontal > 0 && !facingRight || horizontal < 0 && facingRight)
        {
            facingRight = !facingRight;

            Vector3 theScale = transform.localScale;

            theScale.x *= -1;

            transform.localScale = theScale;
        }
    }

 


}
