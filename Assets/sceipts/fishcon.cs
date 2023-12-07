using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fishcon : MonoBehaviour
{
    public int speed = 0;
    public int count = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right *speed * Time.deltaTime*0.5f);
    }
}
