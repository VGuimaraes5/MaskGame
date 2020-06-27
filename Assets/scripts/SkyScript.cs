using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SkyScript : MonoBehaviour
{
    private Material skyMaterial;
    private Vector2 moviment;
    public float speed;
    void Start()
    {
        skyMaterial = GetComponent<Renderer>().material;
        moviment = skyMaterial.GetTextureOffset("_MainTex");
    }

    // Update is called once per frame
    void Update()
    {
        moviment.x += (speed * Time.deltaTime);
        skyMaterial.SetTextureOffset("_MainTex", moviment);
    }
}
