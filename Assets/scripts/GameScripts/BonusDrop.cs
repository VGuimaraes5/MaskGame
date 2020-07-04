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
        //verifica se houve colisão com uma mascara
        if (collision.gameObject.tag == "MaskTag")
        {
            //verifica se a mascara não esta contaminada
            if (!collision.gameObject.GetComponent<MaskScript>().contaminated)
            {
                AudioSource.PlayClipAtPoint(bonusAudio, transform.position);
                //define o tempo do bonus como 0
                bonus.bonusTime = 0.0f;
                //atribui um valor pro bonus com uma chance de 5% para 10x, 25% para 5x e 70% para 2x
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
            //destroy o objeto
            Destroy(gameObject);
        }
        
    }
}
