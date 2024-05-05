using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DanteMove1 : MonoBehaviour
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
    private int numLayer = 6;
    private bool control = true;
    public bool gunTrigger;

    [SerializeField]
    private Transform shootPositionRight;
    [SerializeField]
    private Transform shootPositionLeft;
    [SerializeField]
    private GameObject bulletR;
    [SerializeField]
    private GameObject bulletL;

    void Start()
    {
        gunTrigger = false;
    }
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        if (control)
        {
            Vector2 velocity = new Vector2(horizontal * movespeed, RB2D.velocity.y);
            RB2D.velocity = velocity;
        }
        //Esto nos da ´que tanto va a aumentar gracias a nuestra velocidad
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
        if (Input.GetKeyDown(KeyCode.Z) && control)
        {
            animator.SetBool("IsAttacking", true);
            if (gunTrigger)
            {
                shoot();
            }

        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            gunTrigger = !gunTrigger;
            animator.SetBool("GunTrigger", gunTrigger);
            animator.SetBool("GunTransition", true);
            DissableControl();

        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == numLayer)
        {
            animator.SetBool("IsJumping", false);
            DoubleJump = 0;
        }
    }
    public void OnAttackAnimationEnd()
    {
        animator.SetBool("IsAttacking", false);
    }
    public void GunTransitionEnd()
    {
        animator.SetBool("GunTransition", false);
        EnableControl();

    }
    public void DissableControl()
    {
        control = false;
    }
    public void EnableControl()
    {
        control = true;
    }
    private void shoot()
    {
        if (spriteRenderer.flipX)
        {
            Instantiate(bulletL, shootPositionLeft.transform.position, shootPositionLeft.transform.rotation);
        }
        else
        {
            Instantiate(bulletR, shootPositionRight.transform.position, shootPositionRight.transform.rotation);
        }

    }
}