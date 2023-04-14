using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fluido : MonoBehaviour
{
    // Start is called before the first frame update
    private float velocidad = 1;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 offset = GetComponent<MeshRenderer>().material.mainTextureOffset;
        offset.y -= Time.deltaTime * velocidad;
        GetComponent<MeshRenderer>().material.mainTextureOffset = offset;
    }
}
