using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    public GameObject proyectilPrefab;
    
    private Transform trf;
    private Rigidbody2D rb;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        trf = gameObject.GetComponent<Transform>();
        //Debug.Log("La posición de mi Player es:");
        //Debug.Log("En X: " + gameObject.GetComponent<Transform>().position.x);
        //Debug.Log("En y: " + gameObject.GetComponent<Transform>().position.y);
        //Debug.Log("Nombre de mi game object: " + gameObject.name);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       Movement();
       CheckAnimation();
       CheckJump();

       

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            animator.SetTrigger("shoot");
            Instantiate(proyectilPrefab, transform.position, Quaternion.identity);
        }
    }

    private void CheckJump()
    { if (Input.GetKey(KeyCode.Space) 
          && gameObject.GetComponentInChildren<CheckGround>().isGround)
        {
            //Debug.Log("Jump");
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    private void CheckAnimation()
    {
        if (rb.velocity.x < -0.1f)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (rb.velocity.x > 0.1f)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }

        if (Math.Abs(rb.velocity.x) > 0.1f)
        {
            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }

        if (!gameObject.GetComponentInChildren<CheckGround>().isGround)
        {
            animator.SetBool("isJumping", true);
        }
        else
        {
            animator.SetBool("isJumping", false);
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Suelo"))
        {
            Debug.Log("Ha colisionado");
        }

    }

    private void Movement()
    {
        if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
        }
        /*else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }*/
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        //Debug.Log("Ha salido");
    }
    
}
