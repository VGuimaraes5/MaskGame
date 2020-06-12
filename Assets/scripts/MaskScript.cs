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
                float yPos = Mathf.Clamp(transform.position.y, -5.0f, 5.0f);
                transform.position = new Vector3(transform.position.x, yPos, transform.position.z);
                Destroy(gameObject, 2);
         
            }
    }

}
