using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DanteMove1 : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D RB2D;
    //con esto accedemos al RigidBody para poder alterar las cordenadas, sumandole o restandole
    private float movespeed = 5;
    //obviamente la velocidad de movimiento del personaje que por gusto propio lo dejo en privado
    private float JumpSpeed = 5;
    private float DoubleJump = 0;
    //Un contador para tener un doble salto pero si nos deja a futuro lo puedo quitar
    [SerializeField]
    private SpriteRenderer spriteRenderer;
    [SerializeField]
    private Animator animator;
    //este accede al sprite renderer y al animador respectivamente permitiendonos controlar las animaciones a traves de condiciones (Booleanos)
    private int numLayer = 6;
    void Start()
    {

    }
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        Vector2 velocity = new Vector2(horizontal * movespeed, RB2D.velocity.y);
        RB2D.velocity = velocity;
        //Esto nos da ´que tanto va a aumentar gracias a nuestra velocidad
        if (DoubleJump < 2)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                RB2D.AddForce(Vector2.up * JumpSpeed, ForceMode2D.Impulse);
                animator.SetBool("IsJumping", true);
                DoubleJump++;
            }
        }
        if (horizontal < 0)
        {
            spriteRenderer.flipX = true;
            animator.SetBool("IsMoving", true);
        }
        else if (horizontal > 0)
        {
            spriteRenderer.flipX = false;
            animator.SetBool("IsMoving", true);
        }
        else if (horizontal == 0)
        {
            animator.SetBool("IsMoving", false);
        }
        //flip X funciona tal y como lo indica su nombre, rota a lo que seria el similar de X
        if (Input.GetKeyDown(KeyCode.Z))
        {

            animator.SetBool("IsAttacking", true);
        }
        //Y este es un codigo incompleto para un ataque
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

}