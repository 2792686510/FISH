using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fishmake : MonoBehaviour
{
    public GameObject fishs;
    public GameObject[] fishPres;
    public Transform[] fishMakepoints;
    void Start()
    {
        InvokeRepeating("makefish", 0, 1);
    }
    void makefish()
    {

        int fishtype = Random.Range(0,fishPres.Length);
        int fishpoint = Random.Range(0,fishMakepoints.Length);
        int fishcount = fishPres[fishtype].GetComponent<fishcon>().count;
        fishcount = Random.Range(1, fishcount);
        int angle = Random.Range(-10,10);
        if (Random.Range(0, 2) == 1)
        {
            StartCoroutine(creatfish(fishtype, fishcount, fishpoint, angle));
        }
        else
        {
            int anglespeed= Random.Range(-20,20);
            StartCoroutine(creatfish2(fishtype, fishcount, fishpoint, angle,anglespeed));
        }
    }
    IEnumerator creatfish2(int fishtype, int fishcount, int fishpoint, int angle,int anglespeed)
    {
        for (int i = 0; i < fishcount; i++)
        {
            GameObject fish = Instantiate(fishPres[fishtype]);
            fish.transform.position = fishMakepoints[fishpoint].position;
            fish.AddComponent<fishrotate>().speed = anglespeed;
            fish.transform.rotation = Quaternion.Euler(fishMakepoints[fishpoint].rotation.eulerAngles.x, fishMakepoints[fishpoint].rotation.eulerAngles.y, fishMakepoints[fishpoint].rotation.eulerAngles.z + angle);
            fish.transform.SetParent(fishs.transform);
            fish.GetComponent<SpriteRenderer>().sortingOrder += 1;
            yield return new WaitForSeconds(0.5f);
        }
    }
    IEnumerator creatfish(int fishtype,int fishcount,int fishpoint,int angle)
    {
        for (int i = 0; i < fishcount; i++)
        {
            GameObject fish = Instantiate(fishPres[fishtype]);
            fish.transform.position = fishMakepoints[fishpoint].position;
            fish.transform.rotation = Quaternion.Euler(fishMakepoints[fishpoint].rotation.eulerAngles.x, fishMakepoints[fishpoint].rotation.eulerAngles.y, fishMakepoints[fishpoint].rotation.eulerAngles.z+angle);
            fish.transform.SetParent(fishs.transform);
            fish.GetComponent<SpriteRenderer>().sortingOrder += 1;
            yield return new WaitForSeconds(0.5f);
        }
    }
    void Update()
    {
        
    }
}
