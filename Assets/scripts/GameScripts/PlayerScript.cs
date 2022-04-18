using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class PlayerScript : MonoBehaviour
{
    //controles do jogador

    public GameObject mask;
    public float speed = 10.0f;
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

    public enum MobileHorizMovement
    {
        Accelerometer,
        ScreenTouch
    }

    public MobileHorizMovement horizMovement = MobileHorizMovement.Accelerometer;

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
        Destroy(spawnObject); //destroi o spawner pois se ele ficasse na tela começava a spawnar alvos com erro que buscavam o componente vida no player e não encontravam
        gameObject.SetActive(false); //desativa o player
        gameOverPanel.gameObject.SetActive(true); //ativa a tela de gameover 
    }

    //define a movimentação do player
    private void movePlayer()
    {
#if UNITY_STANDALONE || UNITY_WEBPLAYER || UNITY_EDITOR
        float horizontal = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        transform.Translate(horizontal, 0, 0);
#elif UNITY_IOS || UNITY_ANDROID
        if (horizMovement == MobileHorizMovement.Accelerometer)
        {
            float horizontal = Input.acceleration.x * speed * Time.deltaTime;
            transform.Translate(horizontal, 0, 0);
        }
#endif
    }

    //delimita a area em que o jogador pode andar (a area da sacada do predio)
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
        //define o tempo q o jogador esta com a mascara na mão
        fireDelayTime += Time.deltaTime;

#if UNITY_STANDALONE || UNITY_WEBPLAYER || UNITY_EDITOR
        //se apertar espaço e o tempo do fireDelay for menor q o delay minimo (1.5 segundos) possibilita o jogador de jogar outra mascara
        if (Input.GetKeyDown("space") && fireDelayTime >= fireDalayMinimun)
        {
            //muda a animação do player
            playerAnimator.SetTrigger("ThrowMask");
            //invoca a mascara depois de 2 segundos
            Invoke("spawnMask", 0.2f);
            //zera o contador do fireDelay
            fireDelayTime = 0;
        }
#elif UNITY_IOS || UNITY_ANDROID
        if (Input.touchCount > 0 && fireDelayTime >= fireDalayMinimun)
        {
            //muda a animação do player
            playerAnimator.SetTrigger("ThrowMask");
            //invoca a mascara depois de 2 segundos
            Invoke("spawnMask", 0.2f);
            //zera o contador do fireDelay
            fireDelayTime = 0;
        }
#endif
    }

    //função que spawna a mascara, fizemos separado da função de jogar a mascara, pois precisavamos adicionar um delay com o Invoke para encaixar na animação da mão no player
    private void spawnMask()
    {
        Instantiate(mask, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
    }

    //muda os sprites dos corações de acordo com a quantidade de vida
    private void UpdateLifes()
    {
        if (lifes < 3) heart3.sprite = emptyHeart;
        if (lifes < 2) heart2.sprite = emptyHeart;
        if (lifes < 1) heart1.sprite = emptyHeart;
    }
}
