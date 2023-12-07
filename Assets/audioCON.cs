using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class audioCON : MonoBehaviour
{
    public AudioClip dapao;
    public AudioClip shengji;
    public AudioClip qiehuanpao;
    public AudioClip money;
    public AudioClip seaWave;
    public AudioClip wang;
    private static audioCON instance;
    public AudioSource audio;
    public Slider slider;
    public Toggle toggle;
    public bool jingying = false;
    public static audioCON Instance {  get { return instance; } set { instance = value; } }
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;  
    }
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void playAudio(AudioClip name)
    {
        if (jingying == false)
        {
            audio.PlayOneShot(name, 1.25f);
        }

    }
    public void stopAudio()
    {
        if(jingying == false)
        {
            audio.Stop();
            jingying=true;
        }
        else
        {
            audio.Play();
            jingying=false;
        }
    }
    public void gaibian()
    {
        audio.volume = slider.value;
    }
}
