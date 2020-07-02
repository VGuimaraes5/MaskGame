using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

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
    public GameObject gameOverPanel;
    public GameObject spawnObject;

    public AudioClip gameOverAudio;

    void Start()
    {
        playerAnimator = GetComponent<Animator>();
    }
    void Update()
    {
        movePlayer();
        maxPlayerMovement();
        throwMask();
        UpdateLifes();

        if(lifes == 0)
        {
            AudioSource.PlayClipAtPoint(gameOverAudio, transform.position);
            GameOver();
        }
    }

    private void GameOver()
    {
        Destroy(spawnObject);
        gameObject.SetActive(false);
        gameOverPanel.gameObject.SetActive(true);
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
        fireDelayTime += Time.deltaTime;

        if (Input.GetKeyDown("space") && fireDelayTime >= fireDalayMinimun)
        {
            playerAnimator.SetTrigger("ThrowMask");
            Invoke("spawnMask", 0.2f);
            fireDelayTime = 0;
        }
    }

    private void spawnMask()
    {
        Instantiate(mask, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
    }

    private void UpdateLifes()
    {
        if (lifes < 3) heart3.sprite = emptyHeart;
        if (lifes < 2) heart2.sprite = emptyHeart;
        if (lifes < 1) heart1.sprite = emptyHeart;
    }
}
