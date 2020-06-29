using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetScript : MonoBehaviour
{
    public float speed;
    private SpriteRenderer maskEfect;
    private Animator animator;
    public bool usingMask = false;
    public int pointValue;


    private PointsScript ptScript;
    private PlayerScript playerScript;

    

    public int CharacterSelec = -1;


    void Start()
    {
        maskEfect = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        ptScript = GameObject.Find("pointsControler").GetComponent<PointsScript>();
        playerScript = GameObject.Find("player").GetComponent<PlayerScript>();

        if(gameObject.tag == "YoungTag")
        {
            selectSkin();
        }

        adjustMovement();
    }


    void OnBecameInvisible()
    {
        // Verifica se OldMan foi atingido por uma mascara e o destroi
        if (usingMask == true)
        {
            Destroy(gameObject);
        }
        else
        {
            returnToScreen();
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Verifica a colisao entre mascara e OldMan

        if (collision.gameObject.tag == "MaskTag" && usingMask == false)
        {
            if (collision.gameObject.GetComponent<MaskScript>().contaminated)
            {
                maskEfect.color = Color.red;
                animator.SetBool("MaskInfected", true);
                playerScript.lifes --;
            }
            else
            {
                maskEfect.color = Color.cyan;
                animator.SetBool("MaskInfected", false);
                ptScript.points += pointValue;
            }

            Invoke("NormalColor", 0.2f);
            animator.SetBool("Mask", true);
            usingMask = true;
        }
    }


    private void NormalColor()
    {
        maskEfect.color = Color.white;
    }


    private void adjustMovement()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();

        //Verifica de qual lado o OldMan foi espawnado direita/esquerda
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


    private void returnToScreen()
    {
        // caso ainda não tenha sido atingido por uma mascara OldMan retorna a tela em loop infinito
        //if (transform.position.x <= -6.3f || transform.position.x >= 6.3f)
        
            float xPos = Mathf.Clamp(transform.position.x, 5.8f, -5.8f);
            transform.position = new Vector3(xPos, transform.position.y, transform.position.z);
   
    }


    void selectSkin()
    {
        CharacterSelec = Random.Range(1, 4);

        animator.SetInteger("SelectCharacter", CharacterSelec);
    }
}
