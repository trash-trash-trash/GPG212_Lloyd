using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Commentator : MonoBehaviour
{
    private Renderer rend;
    void Start()
    {
        rend = this.GetComponent<Renderer>();
        rend.material.SetColor("_Color", Color.magenta);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
