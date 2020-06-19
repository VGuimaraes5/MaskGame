using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetScript : MonoBehaviour
{
    public float speed = 2.0f;
    private SpriteRenderer maskEfect;
    private Animator animator;
    public bool usingMask = false;

    public int CharacterSelec = -1;

    void Start()
    {
        maskEfect = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();

        if(gameObject.tag == "YoungTag")
        {
            selectSkin();
            speed = 4.0f;
        }

        adjustMovement();
    }


    void Update()
    {
        // Limitando o personagem a tela
        returnToScreen();
    }


    void OnBecameInvisible()
    {
        // Verifica se OldMan foi atingido por uma mascara e o destroi
        if (usingMask == true)
        {
            Destroy(gameObject);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Verifica a colisao entre mascara e OldMan

        if (collision.gameObject.tag == "MaskTag" && collision.gameObject.GetComponent<MaskScript>().contaminated == true && usingMask == false)
        {
            maskEfect.color = Color.red;
            Invoke("NormalColor", 0.5f);
            animator.SetBool("MaskInfected", true);
            animator.SetBool("Mask", true);

            usingMask = true;
        }

        if (collision.gameObject.tag == "MaskTag" && collision.gameObject.GetComponent<MaskScript>().contaminated == false && usingMask == false)
        {
            maskEfect.color = Color.cyan;
            Invoke("NormalColor", 0.5f);
            // Alterna a condição para troca das sprites de animação para a que OldMan esta vestindo mascara
            animator.SetBool("Mask", true);
            animator.SetBool("MaskInfected", false);
            // Identifica que esse objeto já foi atingido para que seja destruido quando sair de cena 
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
        if (transform.position.x <= -6.3f || transform.position.x >= 6.3f)
        {
            float xPos = Mathf.Clamp(transform.position.x, 6.3f, -6.3f);
            transform.position = new Vector3(xPos, transform.position.y, transform.position.z);
        }
    }


    void selectSkin()
    {
        CharacterSelec = Random.Range(1, 4);

        animator.SetInteger("SelectCharacter", CharacterSelec);
    }
}
