using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public GameObject mask;
    public float speed = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    { 
        float horizontal = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        transform.Translate(horizontal, 0, 0);

        if (Input.GetKeyDown("space")) 
        {
            Instantiate(mask, transform.position, Quaternion.identity);
        }
        if (transform.position.x <= -3.4f || transform.position.x >= 3.0f)
        {
            float xPos = Mathf.Clamp(transform.position.x, -3.4f, 3.0f);
            transform.position = new Vector3(xPos, transform.position.y, transform.position.z);
        } 
    }
}
