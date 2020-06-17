using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    public GameObject OldMan;
    public GameObject Corona;
    public GameObject Young;

    // Determina tempo de spawn dos alvos
    public float oldManSpawnTime = 9.0f;
    public float coronaSpawnTime = 6.0f;
    public float youngSpawnTime = 5.0f;
    
    void Start()
    {        
        // Chamar as funções 'spawn' a cada 'spawnTime' segundos
        InvokeRepeating("spawnCorona", coronaSpawnTime, coronaSpawnTime);
        InvokeRepeating("spawnOldMan", oldManSpawnTime, oldManSpawnTime);
        InvokeRepeating("spawnYoung", youngSpawnTime, youngSpawnTime);
    }

    void spawnYoung()
    {

        // Aleatoriamente escolhe um ponto da calçada 
        float posYZ = Random.Range(-4.83f, -3.21f);
        var spawnPoint = new Vector3(spawnDirection(), posYZ, posYZ);
        // Instancia um novo OldMan na scene
        Instantiate(Young, spawnPoint, Quaternion.identity);

    }

    void spawnOldMan()
    {

        // Aleatoriamente escolhe um ponto da calçada 
        float posYZ = Random.Range(-4.83f, -3.21f);
        //posiciona o mesmo valor de Y pra Z para que um sprite a frente n fique por tras de outro mais ao fundo
        var spawnPoint = new Vector3(spawnDirection(), posYZ, posYZ);
        // Instancia um novo OldMan na scene
        Instantiate(OldMan, spawnPoint, Quaternion.identity);

    }
    void spawnCorona()
    {   
        // Aleatoriamente escolhe um ponto da calçada 
        var spawnPoint = new Vector2(spawnDirection(), Random.Range(-0.2f, -1.2f));
        // Instancia um novo OldMan na scene
        Instantiate(Corona, spawnPoint, Quaternion.identity);

    }

    float spawnDirection()
    {
        float alternatives = Random.Range(0.0f, 1.0f);
        //determina se OldMan ira spawnar na esquerda ou na direita
        if (alternatives < 0.5f)
        {
            return -5.8f;
        }
        else
        {
            return 5.8f;
        }
    }
}