using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaskScript : MonoBehaviour
{
    
    public float speed = -3;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, speed);        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y <= -5.0f)
        {
            // Se a mascara não atingir nenhum alvo ou obstaculo ela "cai" para no chão por 2s e é destruida 
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            rb.velocity = new Vector2(0, 0);
            Destroy(gameObject, 2);
        }
    }
}
