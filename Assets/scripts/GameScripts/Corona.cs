using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corona : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed = 2.0f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        //muda a velocidade do corona dependendo do lado q ele foi spawnado
        rb.velocity = transform.position.x == 5.8f ? new Vector2(-speed, 0) : new Vector2(speed, 0);
    }
 
    //verifica se o corona atingiu uma mascara para então se auto destruir
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "MaskTag")
        {
            Destroy(gameObject);
        }
    }


    //destroi o objeto caso saia da tela
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
