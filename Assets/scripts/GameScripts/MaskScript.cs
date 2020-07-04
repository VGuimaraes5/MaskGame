using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Security;
using UnityEngine;

public class MaskScript : MonoBehaviour
{
    SpriteRenderer maskRenderer;
    Animator animator;
    Rigidbody2D rb;

    public float speed = -10.0f;
    public bool contaminated = false;


    void Start()
    {
        animator = GetComponent<Animator>();
        maskRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        
        rb.velocity = new Vector2(0, speed);
    }


    void FixedUpdate()
    {
        StopOnGround();        
    }

    //para a mascara na calçada ao atingir a posição -5 de y
    private void StopOnGround()
    {
        if (transform.position.y <= -5.0f)
        {
            rb.velocity = new Vector2(0, 0);
            animator.SetBool("MaskStop", true);
            //destroi o objeto dps de 1.5 segundos parado 
            Destroy(gameObject, 1.5f);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {   
        // caso haja colisao com o corona ela ficara infectada 
        if (collision.gameObject.tag == "CoronaTag")
        {
            maskRenderer.color = Color.green;
            contaminated = true;
        }
    }
}
