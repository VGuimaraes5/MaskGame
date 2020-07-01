using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusScript : MonoBehaviour
{
    public Animator animator;
    public float bonusTime;
    public int bonusValue;
    void Start()
    {
        bonusTime = 6.0f;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetInteger("Value", bonusValue);
        bonusTime += Time.deltaTime;
        animator.SetFloat("Time", bonusTime);
        if (bonusTime >= 6.0f)
        {
            bonusValue = 1;
        }
    }
}

