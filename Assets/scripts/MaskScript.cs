using Packages.Rider.Editor.UnitTesting;
using System.Collections;
using System.Collections.Generic;
using System.Security;
using UnityEngine;

public class MaskScript : MonoBehaviour
{
    public float speed = -5.0f;
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
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            rb.velocity = new Vector2(0, 0);
                Destroy(gameObject, 2.0f);
         
            }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "OldMan(Clone)")
        {
            Destroy(gameObject);
        }
    }

}
