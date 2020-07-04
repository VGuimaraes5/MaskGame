using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusScript : MonoBehaviour
{
    private Animator animator;
    public float bonusTime;
    public int bonusValue;

    //script para controle do objeto que mostra e temporiza o bonus pego,
    //fizemos separado para implementar as animações e ter um controle mais específico

    void Start()
    {
        bonusTime = 6.0f;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        BonusTime();
        BonusAnimation();
    }

    private void BonusTime()
    {
        bonusTime += Time.deltaTime;
        //caso o tempo seja maior que 6 segundos o bonus acaba e volta pro valor 1
        if (bonusTime >= 6.0f)
        {
            bonusValue = 1;
        }

    }

    //muda a animação do icone de bonus de acordo com o valor e o tempo
    private void BonusAnimation()
    {
        animator.SetInteger("Value", bonusValue);
        animator.SetFloat("Time", bonusTime);  
    }

}

