﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetScript : MonoBehaviour
{
    public GameObject bonus;
    private BonusScript bonusScript;


    private SpriteRenderer maskRenderer;
    public bool usingMask = false;
    

    private Animator animator;


    private PlayerScript playerScript;
    private PointsScript ptScript;

    
    public int pointValue;
    public float speed;
    public int CharacterSelec;

    public AudioClip loseLifeAudio;
    public AudioClip pointAudio;


    void Start()
    {
        Random.InitState((int)System.DateTime.Now.Ticks);

        maskRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        ptScript = GameObject.Find("player").GetComponent<PointsScript>();
        playerScript = GameObject.Find("player").GetComponent<PlayerScript>();
        bonusScript = GameObject.Find("BonusControl").GetComponent<BonusScript>();

        if (gameObject.tag != "DogTag")
        {
            selectSkin();
        }

        adjustMovement();
    }


    void OnBecameInvisible()
    {
            Destroy(gameObject);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Verifica a colisao entre mascara e um Target

        if (collision.gameObject.tag == "MaskTag" && usingMask == false)
        {
            if (collision.gameObject.GetComponent<MaskScript>().contaminated)
            {
                AudioSource.PlayClipAtPoint(loseLifeAudio, transform.position);
                maskRenderer.color = Color.red;
                animator.SetBool("MaskInfected", true);
                playerScript.lifes --;
            }
            else
            {
                AudioSource.PlayClipAtPoint(pointAudio, transform.position);
                maskRenderer.color = Color.cyan;
                animator.SetBool("MaskInfected", false);
                ptScript.points += pointValue * bonusScript.bonusValue;

                SpawnBonus();
            }

            Invoke("NormalColor", 0.2f);
            animator.SetBool("Mask", true);
            usingMask = true;
            //destroi a mascara
            Destroy(collision.gameObject);
        }
    }

    private void SpawnBonus()
    {
        float bonusChance = Random.Range(0.0f, 100.0f);
        if (bonusChance < 20.0f)
        {
            Instantiate(bonus, transform.position, Quaternion.identity);
        }
    }


    private void NormalColor()
    {
        maskRenderer.color = Color.white;
    }


    private void adjustMovement()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();

        if (gameObject.tag == "DogTag") transform.Rotate(0, -180, 0); //inverte sprite do cachorro para igualar com os outros

            //Verifica de qual lado o Target foi espawnado direita/esquerda
            if (transform.position.x == 5.8f)
        {
            // Caso o spawn seja na direita, rotaciona a sprite 180º em Y e inverte velocidade para movimentar para a esquerda
            transform.Rotate(0, 180, 0);
            rb.velocity = new Vector2(-speed, 0);
        }
        else
        {
            // Caso o spawn seja na esquerda, sprite mantem e velocidade eh ajustada para movimentar para direita
            rb.velocity = new Vector2(speed, 0);
        }
    }

    void selectSkin()
    {
        //seleciona uma skin para o Old ou o Young
        CharacterSelec = Random.Range(1, 5);

        animator.SetInteger("SelectCharacter", CharacterSelec);
    }
}
