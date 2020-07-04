using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    //Nosso objeto spawner que gera os alvos e obstáculos aleatóriamente no jogo

    public GameObject OldMan;
    public GameObject Corona;
    public GameObject Young;
    public GameObject Dog;

    public float coronaSpawnTime = 2.0f;
    public float targetsSpawnTime = 2.5f;
    
    void Start()
    {
        Random.InitState((int)System.DateTime.Now.Ticks);
        InvokeRepeating("spawnTargets", targetsSpawnTime, targetsSpawnTime);
        InvokeRepeating("spawnCorona", coronaSpawnTime, coronaSpawnTime);
    }


    //Spawna aleatoriamente o objeto passado entre a altura minima e máxima permitidas, posiciona tambem em z para evitar bugs de sobreposição
    private void SpawnObject(GameObject objectToSpawn, float spwanPointMin_Y, float spawnPointMax_Y) 
    {
        float positionYZ = Random.Range(spwanPointMin_Y, spawnPointMax_Y);

        int leftOrRight = Random.Range(0, 2);

        float positionX = leftOrRight == 1 ? 5.8f : -5.8f;
        
        var spwanPoint = new Vector3(positionX, positionYZ, positionYZ);
        Instantiate(objectToSpawn, spwanPoint, Quaternion.identity);
    }


    private void spawnTargets() 
    {
        //Escolhe aleatoriamente um dos 3 alvos para ser spawnado
        float randonTarget = Random.Range(0.0f, 100.0f);

        float min = -4.83f;
        float max = -3.21f;
        
        if (randonTarget <= 20.0f)
        {
            SpawnObject(OldMan, min, max);
        }
        else if (randonTarget <= 50.0f)
        {
            SpawnObject(Dog, min, max);
        }
        else
        {
            SpawnObject(Young, min, max);
        }
    }

 
    void spawnCorona()
    {
        SpawnObject(Corona, -1.2f, 1.7f);
    }
}