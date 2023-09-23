using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private int moveSpeed = 3;
    [SerializeField] private float moveX;

    [SerializeField] Rigidbody2D rb;

    
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizantal") * moveSpeed;
        if (moveX > 0)
        {
            rb.AddForce(new Vector2(moveX, 0f));
        }
    }
}
