using Packages.Rider.Editor.UnitTesting;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Security;
using UnityEngine;

public class MaskScript : MonoBehaviour
{
    // Ajuste da velocidade em que a mascara cai
    SpriteRenderer mt;
    public float speed = -10.0f;
    public Animator animator;
    public bool contaminated = false;

    void Start()
    {
        adjustVelocity(0, speed);
        animator = GetComponent<Animator>();
        mt = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Caso a mascara não atinja um alvo ou obstáculo, a mascara para na calçada por 2s e depois eh destruida
        if (transform.position.y <= -5.0f)
        {
            adjustVelocity(0, 0);
            animator.SetBool("MaskStop", true);
            Destroy(gameObject, 2.0f);
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
            mt.color = Color.green;
            contaminated = true;
        }
    }

    // Modularização do ajuste de velocidade para evitar repetição
    private void adjustVelocity(float coordX, float coordY)
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(coordX, coordY);
    }

}
