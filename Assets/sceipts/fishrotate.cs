using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fishrotate : MonoBehaviour
{
    public int speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0,0,1*speed*Time.deltaTime);
    }
    //ÓãÅö×²

}
