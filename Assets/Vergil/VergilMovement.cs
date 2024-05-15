using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VergilMovement : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D RB2D;
    private float movespeed = 5;
    private float JumpSpeed = 5;
    private float DoubleJump = 0;
    [SerializeField]
    private SpriteRenderer spriteRenderer;
    [SerializeField]
    private Animator animator;
    private int GroundLayer = 6;
    private bool control = true;
    public float UltCharge = 0;
    private bool UltimateReady = false;
    public GameObject ultimateOBJ;
    void Start()
    {

    }
    void Update()
    {
        if (UltCharge < 50)
        {
            UltCharge += Time.deltaTime;
        }
        else
        {
            UltimateReady = true;
        }
        float horizontal = Input.GetAxisRaw("Horizontal");
        if (control)
        {
            Vector2 velocity = new Vector2(horizontal * movespeed, RB2D.velocity.y);
            RB2D.velocity = velocity;
        }
        if (DoubleJump < 2 && control)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                RB2D.AddForce(Vector2.up * JumpSpeed, ForceMode2D.Impulse);
                animator.SetBool("IsJumping", true);
                DoubleJump++;
            }
        }
        if (horizontal < 0 && control)
        {
            spriteRenderer.flipX = true;
            animator.SetBool("IsMoving", true);
        }
        else if (horizontal > 0 && control)
        {
            spriteRenderer.flipX = false;
            animator.SetBool("IsMoving", true);
        }
        else if (horizontal == 0)
        {
            animator.SetBool("IsMoving", false);
        }
        if (Input.GetKeyDown(KeyCode.Q) && control)
        {
            animator.SetBool("IsAttacking", true);
            DissableControl();
        }
        if (Input.GetKeyDown(KeyCode.E) && UltimateReady && animator.GetBool("IsJumping") == false)
        {
            animator.SetBool("Ultimate", true);
            DissableControl();
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == GroundLayer)
        {
            animator.SetBool("IsJumping", false);
            DoubleJump = 0;
        }
        if (collision.gameObject.layer == 6)
        {
            animator.SetBool("IsJumping", false);
            DoubleJump = 0;
        }
    }

    private void VergilAttackEnd()
    {
        animator.SetBool("IsAttacking", false);
        EnableControl();
    }
    private void VergilUltimateEnd()
    {
        animator.SetBool("Ultimate", false);
        EnableControl();
        CameraTarget.Instance.shakeCamera(30f, 2);
        UltCharge = 0;
    }
    private void ultimateTurn()
    {
        GameObject ultimateObject = Instantiate(ultimateOBJ);
        Destroy(ultimateObject, 2f);
        UltimateReady = false;
    }
    public void DissableControl()
    {
        control = false;
        movespeed = 0;
    }
    public void EnableControl()
    {
        control = true;
        movespeed = 5;
    }

}
