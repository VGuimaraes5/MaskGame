using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    public GameObject OldMan;

    // Variável para conhecer quão rápido nós devemos criar novos Asteroides
    public float spawnTime = 7;
    
    void Start()
    {        
        // Chamar a função 'addEnemy' a cada 'spawnTime' segundos
        InvokeRepeating("addEnemy", spawnTime, spawnTime);
    }

    void addEnemy()
    {
        float posX;
        float alternatives = Random.Range(0.0f, 0.9f);
        //determina se o velho vai nascer na esquerda ou na direita
        if (alternatives < 0.5f){
            posX = -5.8f;
        }else{
            posX = 5.8f;
        }
        // Aleatoriamente escolhe um ponto da calçada
        var spawnPoint = new Vector2(posX, Random.Range(-4.83f, -3.21f));
        // Criar o velhote 
        Instantiate(OldMan, spawnPoint, Quaternion.identity);

    }
}