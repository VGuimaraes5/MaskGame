using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetScript : MonoBehaviour
{
    //script que controla o comportamento dos alvos passando na rua, o mesmo script foi adicionado nos 3 prefabs de cada alvo.
    //o script foi feito de uma forma genérica que identifica em qual prefab está adicionada


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

        if (gameObject.tag != "DogTag") //os objetos OldMan e Young possuem diferentes skins, o cachorro é o único que não precisa dessa função
        {
            selectSkin();
        }

        adjustMovement();
    }

    //destroi caso saia da tela
    void OnBecameInvisible()
    {
            Destroy(gameObject);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Verifica a colisao entre mascara e um Target

        if (collision.gameObject.tag == "MaskTag" && usingMask == false)
        {
            //verifica se a mascara colidida esta infectada
            if (collision.gameObject.GetComponent<MaskScript>().contaminated)
            {
                //audio de "dano", coloração avermelhada e animação de mascara infectada
                AudioSource.PlayClipAtPoint(loseLifeAudio, transform.position);
                maskRenderer.color = Color.red;
                animator.SetBool("MaskInfected", true);

                //o player perde uma vida
                playerScript.lifes --;
            }
            else
            {
                //audio de "pontuação", coloração azul, animação mascara não infectada
                AudioSource.PlayClipAtPoint(pointAudio, transform.position);
                maskRenderer.color = Color.cyan;
                animator.SetBool("MaskInfected", false);

                //acrescenta a pontuação de acordo com o valor do Target acertado multiplicado pelo o valor do bonus
                ptScript.points += pointValue * bonusScript.bonusValue;

                //chance de spawnar um bonus 
                SpawnBonus();
            }
            //normaliza a cor
            Invoke("NormalColor", 0.2f);
            //adiciona o boleano de usando mascara no animator e no script para true
            animator.SetBool("Mask", true);
            usingMask = true;
            //destroi a mascara
            Destroy(collision.gameObject);
        }
    }


    private void SpawnBonus()
    {
        //adiciona uma chance de 20% de instanciar um bonus no local em que o objeto foi acertado
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

        if (gameObject.tag == "DogTag") transform.Rotate(0, -180, 0); //inverte sprite do cachorro para igualar com os outros por ser o único que foi criado virado inicialmente para esquerda

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
