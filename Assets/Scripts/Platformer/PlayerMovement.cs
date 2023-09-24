using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2.5f;
    [SerializeField] private float jumpHeight = 5f;

     private bool isGrounded = false;
    [SerializeField] private LayerMask ground;
    [SerializeField] private Transform feetPoint;
    [SerializeField] private float checkDistance;
    [SerializeField] Transform dropPoint;

    [SerializeField] public bool hasPhone = true;
    [SerializeField] GameObject controlText;
    private bool textShowing = false;

    public int knockForce = 3;
    public bool knockedBack = true;
    public float hitStunTime = 0.5f;

    //Videoscript toggling
    [SerializeField] private VideoScript vScript;



    private bool phoneNear = false;
    [SerializeField] GameObject phonePrefab;

    private float moveX;
    
    private bool facingRight = true;

    [SerializeField] Rigidbody2D rb;

    //For animations:
    private Animator anim;

    
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        AnimationCheck();

        if (!knockedBack && !vScript.isPaused)
        {
            moveX = Input.GetAxisRaw("Horizontal") * moveSpeed;
            rb.velocity = new Vector2(moveSpeed * moveX, rb.velocity.y);
            flipX();

            CheckGrounded();
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Jump();
            }

            if (Input.GetKeyDown(KeyCode.E) && phoneNear)
            {
                hasPhone = true;
                vScript.pickedUpPhone = true;
                vScript.PhonePickedUp();
                GameObject phone = GameObject.Find("Phone Drop(Clone)");
                Destroy(phone);
            }
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

    private IEnumerator hitStunReset()
    {
        
        yield return new WaitForSeconds(hitStunTime);
        knockedBack = false;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag== "Pickup") {
            ToggleHiddenText();
            phoneNear = true;
        }
        //Drop the player's phone
        if (collision.gameObject.tag == "Enemy")
        {
            if (hasPhone)
            {
                Debug.Log("Dropped Phone");
                DropPhone();
            }
            if (!knockedBack)
            {
                Vector2 knockDirection;
                //Knock the player back
                if (collision.transform.position.x > transform.position.x)
                {
                    knockDirection = new Vector2(-knockForce, knockForce / 2);
                }
                else
                {
                    knockDirection = new Vector2(knockForce, knockForce / 2);
                }
                knockedBack = true;
                rb.AddForce(knockDirection * knockForce, ForceMode2D.Impulse);
                StartCoroutine("hitStunReset");
            }
            
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Pickup")
        {
            ToggleHiddenText();
            phoneNear = false;
        }
    }

    private void DropPhone()
    {
        hasPhone = false;
        vScript.droppedPhone = true;

        Debug.Log("TrytoDrop");

        vScript.PhoneDropped();
        phoneNear = false;

        Instantiate(phonePrefab, new Vector3(dropPoint.position.x, dropPoint.position.y, dropPoint.position.z), Quaternion.identity);
        Debug.Log("Dropped?");

    }

    public void ToggleHiddenText()
    {
        if (textShowing)
        {
            controlText.SetActive(false);
            textShowing = false;
        }
        else
        {
            controlText.SetActive(true);
            textShowing = true;
        }
    }

    public void popAndReset()
    {
        StartCoroutine("deathWait");
    }

    IEnumerator deathWait()
    {
        this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        rb.constraints = RigidbodyConstraints2D.FreezePositionY;
        rb.constraints = RigidbodyConstraints2D.FreezePositionX;
        yield return new WaitForSeconds(3f);
        FindAnyObjectByType<GameManager>().ResetScene();
    }

    private void AnimationCheck()
    {
        if (moveX != 0)
        {
            anim.SetFloat("moveX", 1f);
        } else
        {
            anim.SetFloat("moveX", 0f);
        }
        
        if (hasPhone)
        {
            anim.SetBool("hasPhone", true);
        }
        else
        {
            anim.SetBool("hasPhone", false);
        }
    }

}
