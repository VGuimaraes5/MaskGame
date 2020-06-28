﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    public GameObject OldMan;
    public GameObject Corona;
    public GameObject Young;

    public float coronaSpawnTime = 2.0f;
    public float targetsSpawnTime = 5.0f;
    
    void Start()
    {
        Random.InitState((int)System.DateTime.Now.Ticks);
        InvokeRepeating("spawnTargets", targetsSpawnTime, targetsSpawnTime);
        InvokeRepeating("spawnCorona", coronaSpawnTime, coronaSpawnTime);
    }


    //Spawna aleatoriamente o objeto passado entre a altura minima e máxima permitidas, posiciona tambem em z para evitar bugs de sobreposição
    private void SpawnObject(GameObject objectToSpawn, float spwanPointMin, float spawnPointMax) 
    {
        float positionYZ = Random.Range(spwanPointMin, spawnPointMax);
        float positionX = 0.0f;

        int leftOrRight = Random.Range(0, 2);

        positionX = leftOrRight == 1 ? 5.8f : -5.8f;
        
        var spwanPoint = new Vector3(positionX, positionYZ, positionYZ);
        Instantiate(objectToSpawn, spwanPoint, Quaternion.identity);
    }


    private void spawnTargets() 
    {
        float randonTarget = Random.Range(0.0f, 10.0f);
        
        if (randonTarget < 5.0f)
        {
            SpawnObject(OldMan, -4.83f, -3.21f);
        } 
        else
        {
            SpawnObject(Young, -4.83f, -3.21f);
        }
    }

 
    void spawnCorona()
    {
        SpawnObject(Corona, -1.2f, 1.7f);
    }
}