using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    public GameObject OldMan;

    // Variável para conhecer quão rápido nós devemos criar novos Asteroides
    public float spawnTime =7;
    void Start()
    {        
        // Chamar a função 'addEnemy' a cada 'spawnTime' segundos
        InvokeRepeating("addEnemy", spawnTime, spawnTime);
    }

    void addEnemy()
    {
        // Aleatoriamente escolhe um ponto dentro do objeto spawn
        var spawnPoint = new Vector2(-5.8f, Random.Range(-4.83f, -3.21f));
        // Criar um Asteroide na posição 'spawnPoint'
        Instantiate(OldMan, spawnPoint, Quaternion.identity);

    }
}