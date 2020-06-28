using Packages.Rider.Editor.UnitTesting;
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
        PreventLeavingScreen();        
    }


    private void PreventLeavingScreen()
    {
        if (transform.position.y <= -5.0f)
        {
            rb.velocity = new Vector2(0, 0);
            animator.SetBool("MaskStop", true);
            Destroy(gameObject, 1.5f);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {   
        // caso a colisao com um alvo aconteça a mascara eh destruida
        if (collision.gameObject.tag == "OldManTag" || collision.gameObject.tag == "YoungTag")
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "CoronaTag")
        {
            maskRenderer.color = Color.green;
            contaminated = true;
        }
    }
}
