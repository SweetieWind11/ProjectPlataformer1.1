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
    private float UltCharge = 0;
    private bool UltimateReady = false;
    public GameObject ultimateOBJ;
    void Start()
    {

    }
    void Update()
    {
        if (UltCharge < 1)
        {
            UltCharge += Time.deltaTime;
        }
        else
        {
            UltimateReady = true;
        }
        float horizontal = Input.GetAxisRaw("HorizontalNumeric");
        if (control)
        {
            Vector2 velocity = new Vector2(horizontal * movespeed, RB2D.velocity.y);
            RB2D.velocity = velocity;
        }
        //Esto nos da ´que tanto va a aumentar gracias a nuestra velocidad
        if (DoubleJump < 2 && control)
        {
            if (Input.GetKeyDown(KeyCode.I))
            {
                RB2D.AddForce(Vector2.up * JumpSpeed, ForceMode2D.Impulse);
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
            control = false;
        }
        if (Input.GetKeyDown(KeyCode.E) && UltimateReady)
        {
            animator.SetBool("Ultimate", true);
            control = false;
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == GroundLayer)
        {
            animator.SetBool("IsJumping", false);
            DoubleJump = 0;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == GroundLayer)
        {
            animator.SetBool("IsJumping", true);
            DoubleJump = 0;
        }
    }
    private void VergilAttackEnd()
    {
        animator.SetBool("IsAttacking", false);
        control = true;
    }
    private void VergilUltimateEnd()
    {
        animator.SetBool("Ultimate", false);
        control = true;
        UltCharge = 0;
    }
    private void ultimateTurn()
    {
        GameObject ultimateObject = Instantiate(ultimateOBJ);
        Destroy(ultimateObject, 2f);
        CameraController.Instance.StartShake(.5f);
    }

}
