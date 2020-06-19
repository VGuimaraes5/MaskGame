﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public GameObject mask;
    public float speed = 5.0f;
    private float fireDelay = 1.0f;
    
    
    void Update()
    {
        fireDelay += Time.deltaTime;

        movePlayer();
        maxPlayerMovement();
        throwMask();
    }


    private void movePlayer()
    {
        float horizontal = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        transform.Translate(horizontal, 0, 0);
    }


    private void maxPlayerMovement()
    {
        if (transform.position.x <= -3.4f || transform.position.x >= 3.0f)
        {
            float xPos = Mathf.Clamp(transform.position.x, -3.4f, 3.0f);
            transform.position = new Vector2(xPos, transform.position.y);
        }
    }


    private void throwMask()
    {
        if (Input.GetKeyDown("space") && fireDelay >= 1.0f)
        {
            Instantiate(mask, new Vector2(transform.position.x - 0.4f, transform.position.y), Quaternion.identity);
            fireDelay = 0;
        }
    }
}
