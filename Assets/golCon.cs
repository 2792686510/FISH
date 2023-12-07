using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class golCon : MonoBehaviour
{
    private Vector3 point;
    // Start is called before the first frame update
    void Start()
    {
        point = new Vector3 (-6, -3.94f, 0.0f);
        
    }

    // Update is called once per frame
    void Update()
    {
       transform.position=  Vector3.MoveTowards(transform.position, point, 5f*Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "money")
        {
            Destroy(gameObject);
        }
    }
}
