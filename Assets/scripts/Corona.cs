using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corona : MonoBehaviour
{
    public float speed = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
        adjustMovement();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void adjustMovement()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();

        //Verifica de qual lado o OldMan foi espawnado direita/esquerda
        if (transform.position.x == 5.8f)
        {
            // Caso o spawn seja na direita, rotaciona a sprite 180º em Y e inverte velocidade para movimentar para a esquerda
            transform.Rotate(0, 180, 0);
            rb.velocity = new Vector2(-speed, 0);
        }
        else
        {
            // Caso o spawn seja na esquerda, sprite mantem e velocidade eh ajustada para movimentar para direita
            rb.velocity = new Vector2(speed, 0);
        }
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
