using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SkyScript : MonoBehaviour
{
    private Material skyMaterial;
    private Vector2 movement;
    public float speed;
    void Start()
    {
        skyMaterial = GetComponent<Renderer>().material;
        movement = skyMaterial.GetTextureOffset("_MainTex");
    }

    void Update()
    {
        movement.x += (speed * Time.deltaTime);
        skyMaterial.SetTextureOffset("_MainTex", movement);
    }
}
