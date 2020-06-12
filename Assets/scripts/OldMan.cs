using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OldMan : MonoBehaviour
{

    public float speed = 0.005f;
    private Animator animator;
    private bool verificaMascara = false;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(+speed, 0, 0);

        if (transform.position.x <= -5.8f || transform.position.x >= 6.3f)
        {
            // Criando o limite
            float xPos = Mathf.Clamp(transform.position.x, 6.3f, -5.8f);
            // Limitando
            transform.position = new Vector3(xPos, transform.position.y, transform.position.z);
        }

        if (Input.GetKeyDown("space"))
        {
            animator.SetBool("Mask", true);
            verificaMascara = true;
        }

    }

    void OnBecameInvisible()
    {
        // Destroi a bala quando já está fora da tela
        if (verificaMascara == true)
        {
            Destroy(gameObject);
        }
    }

}