using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class reward : MonoBehaviour
{
    private Text text;
    private float time;
    private bool dianji=false;
    public GameObject gold;
    private Vector3 point = new Vector3(6.39f,3.67f,0);

    // Start is called before the first frame update
    void Start()
    {
        transform.DOScale(new Vector3(1.4f, 1.4f, 1.4f), 1).SetLoops(-1);
        transform.DOPause();
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (dianji==false)
        {
            text.text = (3 - Mathf.FloorToInt(time)) + "s";
            if(3 - Mathf.FloorToInt(time) == 0)
            {
                dianji=true;
                text.text = "½±½ð";
                transform.DOPlay();

            }
        }
    }
    public void onclick()
    {
        if (dianji)
        {
            playcon.Instance.jiaqian(200);
            time = 0;
            dianji = false;
            text.gameObject.transform.localScale = new Vector3(1, 1, 1);
            StartCoroutine(creatGold());
            transform.DOPause();
        }

    }
    IEnumerator creatGold()
    {
        for (int i = 0; i < 5; i++)
        {
            yield return new WaitForSeconds(0.25f);
            Instantiate(gold,point, Quaternion.identity);
        }
    }
}
