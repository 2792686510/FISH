using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class uiCon : MonoBehaviour
{
    public GameObject setpanel;
    private bool dakai = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void set()
    {
        if (dakai == false)
        {
            setpanel.SetActive(true);
            dakai = true;
        }
        else
        {
            setpanel.SetActive(false);
            dakai = false;
        }

    }
    public void zhuye()
    { //ÍË³öµÄÊ±ºò
        playcon.Instance.exit();
        SceneManager.LoadScene(0);
    }
}
