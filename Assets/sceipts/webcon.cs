using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class webcon : MonoBehaviour
{
    public int damage;
    public float dietime;
    private float timecount;
    // Start is called before the first frame update
    void Start()
    {
        audioCON.Instance.playAudio(audioCON.Instance.wang);
    }

    // Update is called once per frame
    void Update()
    {
        timecount += Time.deltaTime;
        if (timecount > dietime*0.2f)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "fish")
        {
            damage =  Random.Range(1, damage*2);
            collision.SendMessage("surt", damage);
        }
    }
}
