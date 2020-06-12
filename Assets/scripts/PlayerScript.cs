using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public GameObject mask;
    public float speed = 5.0f;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        //inicia com o tempo minimo pra poder ja jogar a mascara
       timer = 2.0f;
    }

    // Update is called once per frame
    void Update()
    {
        //Corre o tempo pra poder usar a mascara novamente
        timer += Time.deltaTime;

        //Movimenta o mano pra esquerda e direita
        float horizontal = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        transform.Translate(horizontal, 0, 0);

        //se apertar espaço e o tempo desde a ultima jogada de mascara for maior q 2 spawna uma nova mascara e zera o timer
        if (Input.GetKeyDown("space") && timer >= 2.0f) 
        {
            Instantiate(mask, transform.position, Quaternion.identity);
            timer = 0;
        }

        //delimita a movimentação do player até o fim da sacada
        if (transform.position.x <= -3.4f || transform.position.x >= 3.0f)
        {
            float xPos = Mathf.Clamp(transform.position.x, -3.4f, 3.0f);
            transform.position = new Vector3(xPos, transform.position.y, transform.position.z);
        } 
    }
}
