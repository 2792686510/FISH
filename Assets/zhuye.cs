using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class zhuye : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void start()
    {
        SceneManager.LoadScene(1);
        PlayerPrefs.SetInt("jiazai", 0);
    }
    public void start2()
    {
        SceneManager.LoadScene(1);
        PlayerPrefs.SetInt("jiazai", 1);
    }
}
