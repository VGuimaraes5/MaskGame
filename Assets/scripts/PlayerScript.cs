using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public GameObject mask;
    public float speed = 5.0f;
    private float fireDelay = 1.5f;
    
    
    void Update()
    {
        // Corre o tempo pra poder atirar a mascara novamente
        fireDelay += Time.deltaTime;

        movePlayer();

        //delimita a movimentação do player até o fim da sacada
        maxPlayerMovement();

        // Atira uma mascara caso o fire delay for maior que 2s
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
        if (Input.GetKeyDown("space") && fireDelay >= 2.0f)
        {
            Instantiate(mask, transform.position, Quaternion.identity);
            fireDelay = 0;
        }
    }
}
