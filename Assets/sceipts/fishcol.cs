using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class fishcol : MonoBehaviour
{
    private int cost;
    public int blood;
    private Animator animator;
    public GameObject gold;
    private float time;
    public GameObject[] texiao;
    // Start is called before the first frame update
    void Start()
    {
        cost = blood;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void surt(int damage)
    {
        blood -= damage;
        if (blood < 0)
        {//ÓãËÀÍö
            playcon.Instance.jiaqian(cost*2);
            gameObject.GetComponent<fishcon>().enabled = false;
            animator.SetBool("die", true);
            Destroy(gameObject,1);
            foreach (var item in texiao)
            {
                GameObject ins = Instantiate(item);
                Destroy(ins,3);
            }
            switch (transform.name)
            {
                case "½ðöè_0":
                    StartCoroutine(creatglod(20));
                    break;
                case "Òøöè_0":
                    StartCoroutine(creatglod(15)); 
                    break;
                default:
                    StartCoroutine(creatglod(2));
                    break;
            }
            
        }
    }
    IEnumerator creatglod(int cishu)
    {
        for (int i = 0; i < cishu; i++)
        {
            yield return new WaitForSeconds(0.5f);
            Instantiate(gold, transform.position, Quaternion.identity);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "border")
        {
            Destroy(gameObject);
        }
    }
}
