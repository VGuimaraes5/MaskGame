using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corona : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.position.x == 5.8f ? new Vector2(-speed, 0) : new Vector2(speed, 0);
    }
 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "MaskTag")
        {
            Destroy(gameObject);
        }
    }


    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
