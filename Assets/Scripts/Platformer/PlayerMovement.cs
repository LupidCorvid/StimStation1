using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2.5f;
    [SerializeField] private float jumpHeight = 5f;

    [SerializeField] private bool isGrounded = false;
    [SerializeField] private LayerMask ground;
    [SerializeField] private Transform feetPoint;
    [SerializeField] private float checkDistance;

    
    private float moveX;
    
    private bool facingRight = true;

    [SerializeField] Rigidbody2D rb;

    
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        moveX = Input.GetAxisRaw("Horizontal") * moveSpeed;
        rb.velocity = new Vector2(moveSpeed * moveX, rb.velocity.y);
        flipX();

        CheckGrounded();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    private void flipX()
    {
        if (facingRight && moveX < 0 || !facingRight && moveX >0)
        {
            Vector3 localScale = transform.localScale;
            localScale.x *= -1;
            transform.localScale = localScale;
            facingRight = !facingRight;
        }
    }

    private void Jump()
    {
        if (isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
            isGrounded = false;
        }
    }

    private void CheckGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(feetPoint.position, Vector2.down, checkDistance, ground);
        if (hit.collider != null)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }
}
