using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
        private float horizontal;
    private int speed = 8;
    private float jumpingPower = 8f;
    private bool isFacingRight = true;
    Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask box;
    [SerializeField] private Animator animator;
    [SerializeField] private ParticleSystem dust;

    void Start(){
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update(){
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded() || Input.GetKeyDown(KeyCode.Space) && isBoxed()){
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }

        if(Input.GetKeyUp(KeyCode.Space) && rb.velocity.y > 0f){
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }

        animator.SetFloat("speed", Mathf.Abs(horizontal));

        Flip();
        Jumping();

    }

    private bool isGrounded(){
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }
    private bool isBoxed(){
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, box);
    }

    void FixedUpdate(){
        horizontal = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }


    void Flip(){
        if(isFacingRight == true && Input.GetKeyDown(KeyCode.A)){
            transform.Rotate(0f, 180f, 0f);
            isFacingRight = false;
            CreateDust();
        }

        else if(isFacingRight == false && Input.GetKeyDown(KeyCode.D)){
            transform.Rotate(0f, 180f, 0f);
            isFacingRight = true;
            CreateDust();
        }

    }

    void CreateDust(){
        dust.Play();
    }

    void Jumping(){
        if (rb.velocity.y > 0){
            animator.SetBool("Jumping", true);
            animator.SetBool("Falling", false);
        }
        else if(rb.velocity.y < 0){
            animator.SetBool("Falling", true);
            animator.SetBool("Jumping", false);
        }
        else{
            animator.SetBool("Falling", false);
            animator.SetBool("Jumping", false);
        }
    }
}
