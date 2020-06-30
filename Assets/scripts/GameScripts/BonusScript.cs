using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusScript : MonoBehaviour
{
    public float bonusTime = 5.1f;
    public int bonusValue = 1;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        bonusTime += Time.deltaTime;
        if (bonusTime > 5.0f)
        {
            bonusValue = 1;
        }
    }
}

