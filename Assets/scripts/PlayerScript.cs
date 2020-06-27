using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    public GameObject mask;
    public float speed = 5.0f;
    private float fireDelayTime = 1.0f;
    public float fireDalayMinimun = 1.5f;
    public Sprite emptyHeart;

    public Image heart1;
    public Image heart2;
    public Image heart3;

    public Animator playerAnimator;

    public int lifes = 3;

    void Start()
    {
        playerAnimator = GetComponent<Animator>();
    }
    void Update()
    {
        fireDelayTime += Time.deltaTime;
        maskAnimation();
        movePlayer();
        maxPlayerMovement();
        throwMask();
        UpdateLifes();
    }

    void maskAnimation()
    {
        if(fireDelayTime < fireDalayMinimun)
        {
            playerAnimator.SetBool("Fire", false);
        }
        else
        {
            playerAnimator.SetBool("Mask", true);           
        }
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
        if (Input.GetKeyDown("space") && fireDelayTime >= fireDalayMinimun)
        {
            playerAnimator.SetBool("Fire", true);
            playerAnimator.SetBool("Mask", false);
            Invoke("spawnMask", 0.4f);
            fireDelayTime = 0;
        }
    }

    private void spawnMask()
    {
        Instantiate(mask, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
    }
    private void UpdateLifes()
    {
        switch (lifes)
        {
            case 2:
                heart3.sprite = emptyHeart;
                break;
            case 1:
                heart2.sprite = emptyHeart;
                break;
            case 0:
                heart1.sprite = emptyHeart;
                break;
        }
    }
}
