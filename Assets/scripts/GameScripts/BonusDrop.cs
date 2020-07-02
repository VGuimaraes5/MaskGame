using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusDrop : MonoBehaviour
{
    private BonusScript bonus;
    private float bonusMultiplierChance;

    public AudioClip bonusAudio;
    void Start()
    {
        Random.InitState((int)System.DateTime.Now.Ticks);

        bonus = GameObject.Find("BonusControl").GetComponent<BonusScript>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "MaskTag")
        {
            if (!collision.gameObject.GetComponent<MaskScript>().contaminated)
            {
                AudioSource.PlayClipAtPoint(bonusAudio, transform.position);
                bonus.bonusTime = 0.0f;
                bonusMultiplierChance = Random.Range(0.0f, 100.0f);
                if (bonusMultiplierChance < 5.0f)
                {
                    bonus.bonusValue = 10;
                }
                else if (bonusMultiplierChance < 30.0f)
                {
                    bonus.bonusValue = 5;
                }
                else
                {
                    bonus.bonusValue = 2;
                }
            }
            
            Destroy(gameObject);
        }
        
    }
}
