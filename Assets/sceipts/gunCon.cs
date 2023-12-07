using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunCon : MonoBehaviour
{
    private Vector3 mosuePos;
    void Start()
    {
    }

    void Update()
    {
        
        mosuePos =  Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float angle = Vector2.Angle(Vector2.up, mosuePos - transform.position);
        if(mosuePos.x > transform.position.x)
        {
            angle = -angle;
        }
        transform.rotation = Quaternion.Euler(0,0, angle);
    }
}
