using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class wave : MonoBehaviour
{
    public Texture[] wavets;
    private Material waveMaterial;
    private int index=0;
    private Image ima;
    void Start()
    {
        waveMaterial = GetComponent<MeshRenderer>().material;
        InvokeRepeating("wave1",0,0.1f);
    }

    void Update()
    {

    }
    void wave1()
    {
        index = (index + 1) % wavets.Length;
        waveMaterial.mainTexture = wavets[index];
    }
}
