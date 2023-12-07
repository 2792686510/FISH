using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class reward60 : MonoBehaviour
{
    private float time;
    private Text text;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = (60 - Mathf.FloorToInt(time)).ToString();
        time += Time.deltaTime;
        if (60 - Mathf.FloorToInt(time) == 0)
        {
            playcon.Instance.jiaqian(60);
            time = 0;
        }
    }
}
