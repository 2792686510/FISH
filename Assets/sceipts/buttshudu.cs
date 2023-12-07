using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttshudu : MonoBehaviour
{
    public int damage;
    public int speed;
    public GameObject web;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up*speed*2.5f*Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag  == "fish")
        {
            GameObject webins= Instantiate(web, transform.position, Quaternion.identity);
            webins.GetComponent<webcon>().damage = damage;
            Destroy(gameObject);
        }
        if(collision.tag == "border")
        {
            Destroy(gameObject);
        }

    }
}
