using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OldMan : MonoBehaviour
{
    public float speed = 3.0f;
    private Animator animator;
    public bool verificaMascara = false;

    // Start is called before the first frame update
    void Start()
    {

        animator = GetComponent<Animator>();
        Rigidbody2D rb = GetComponent<Rigidbody2D>();

        //Verifica onde o veio foi spawnado
        if (transform.position.x == 5.8f)
        {
            //Rotaciona o veio caso spawnou na direita
            transform.Rotate(0, 180, 0);
            //determina a velocidade como negativo pro veio n dar moonwalk
            rb.velocity = new Vector2(-speed, 0);
        }else{
            rb.velocity = new Vector2(speed, 0);
        }
        
    }

    // Update is called once per frame
    void Update()
    {

        //deixa o veio indo de la pra ca e de ca pra la
        if (transform.position.x <= -6.0f || transform.position.x >= 6.3f)
        {
            // Criando o limite
            float xPos = Mathf.Clamp(transform.position.x, 6.3f, -6.0f);
            // Limitando
            transform.position = new Vector3(xPos, transform.position.y, transform.position.z);
        }

    }

    void OnBecameInvisible()
    {
        // Exclui o veiote da cena se ele ja estiver mascarado dps de sair da cena
        if (verificaMascara == true)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //verifica se a mascara trombou com o veio
        if (collision.gameObject.name == "Mask(Clone)" && verificaMascara == false)
        {
            //coloca a mascara no veiote
            animator.SetBool("Mask", true);
            verificaMascara = true;
        }
    }
}