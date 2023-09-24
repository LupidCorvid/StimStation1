using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2.5f;
    [SerializeField] private bool isGrounded = false;
    [SerializeField] private LayerMask ground;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private Transform wallCheck;
    [SerializeField] private float checkDistance;

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
        rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
        
        if (!CheckGrounded() || !CheckWall())
        {
            FlipX();
        }

    }

    private void FlipX()
    {
       Vector3 localScale = transform.localScale;
       localScale.x *= -1;
       transform.localScale = localScale;
       facingRight = !facingRight;
        moveSpeed = -1 * moveSpeed;
    }

    private bool CheckWall()
    {
        Vector2 checkDirection;
        if (facingRight)
        {
            checkDirection = Vector2.right;
        } else
        {
            checkDirection = Vector2.left;
        }

        RaycastHit2D hit = Physics2D.Raycast(wallCheck.position, checkDirection, checkDistance, ground);
        if (hit.collider != null)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
    private bool CheckGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(groundCheck.position, Vector2.down, checkDistance, ground);
        if (hit.collider != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
