using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    public GameObject OldMan;

    // Determina tempo de spawn dos alvos
    public float spawnTime = 7;
    
    void Start()
    {        
        // Chamar a função 'addEnemy' a cada 'spawnTime' segundos
        InvokeRepeating("addEnemy", spawnTime, spawnTime);
    }

    void addEnemy()
    {
        float spawnX;
        float alternatives = Random.Range(0.0f, 1.0f);
        //determina se OldMan ira spawnar na esquerda ou na direita
        if (alternatives < 0.5f){
            spawnX = -5.8f;
        }else{
            spawnX = 5.8f;
        }

        // Aleatoriamente escolhe um ponto da calçada 
        var spawnPoint = new Vector2(spawnX, Random.Range(-4.83f, -3.21f));
        // Instancia um novo OldMan na scene
        Instantiate(OldMan, spawnPoint, Quaternion.identity);

    }
}