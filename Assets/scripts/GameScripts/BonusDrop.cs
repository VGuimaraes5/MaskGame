using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusDrop : MonoBehaviour
{
    public BonusScript bonus;
    public float bonusRandom;
    void Start()
    {
        bonus = GameObject.Find("BonusControl").GetComponent<BonusScript>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "MaskTag")
        {
            bonus.bonusTime = 0.0f;
            bonusRandom = Random.Range(0.0f, 10.0f);
            if (bonusRandom < 1.0f)
            {
                bonus.bonusValue = 10;
            }
            else if (bonusRandom < 4.0f && bonusRandom >= 1.0f)
            {
                bonus.bonusValue = 5;
            }
            else
            {
                bonus.bonusValue = 2;
            }
            Destroy(gameObject);
        }
        
    }
}
