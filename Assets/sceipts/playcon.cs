using DG.Tweening;
using LitJson;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class playcon : MonoBehaviour
{
    public UnityEngine.UI.Slider levelSilder;  //�ȼ���
    private int level=1;  //�ȼ�
    public Text leveltext;
    public Text leveltext2;
    private string[] levelstr = { "����", "�м�", "�߼�", "����", "��ʦ" };
    private int levelstrindex=0;
    private int leveljia=0;
    public GameObject[] buttlts;
    public GameObject[] guns;
    public Transform[] gunspoint;
    private int buttltindex = 0;
    private int gunsindex = 0;
    private int money;
    public Text moneytext;
    public Text costtext;
    private int[] costs = { 30, 40, 50, 100, 200, 500 };
    private bool panduan = false;
    public GameObject shengji;
    public Text shengjitext;
    private bool jihuoleve=false;
    private float tiemlevel=0;
    private static playcon instance;
    public static playcon Instance { get { return instance; } set { instance = value; } }
    private void Awake()
    {
        instance = this;
        if (PlayerPrefs.GetInt("jiazai") == 1)
        {
            level = PlayerPrefs.GetInt("level");
            money = PlayerPrefs.GetInt("money");
            leveljia = PlayerPrefs.GetInt("jingyan");


            

        }
    }
    void Start()
    {
        if (PlayerPrefs.GetInt("jiazai") == 1)
        {
            string filepath = Application.dataPath + "/cuncu.json";
            StreamReader sr = new StreamReader(filepath);
            string json = sr.ReadToEnd();
            sr.Close();
            cuncu cuncu1 = JsonMapper.ToObject<cuncu>(json);
            if (cuncu1.shengying == true)
            {//����
                audioCON.Instance.audio.Pause();
                audioCON.Instance.toggle.isOn = false;
            }
            else
            {
                audioCON.Instance.audio.Play();
                audioCON.Instance.toggle.isOn = false;
            }
        }

        money = Convert.ToInt32(moneytext.text);
    }
    void Update()
    {
        moneytext.text = money.ToString();
        levelSilder.value = (leveljia / (2000.000f * level));
        leveltext.text = level.ToString();
        leveltext2.text = levelstr[levelstrindex];
        //print(leveljia / (2000 * level));
        //ÿһ�������ֵֵ = 2000*�ȼ�
        if(leveljia >= 2000 * level)
        {
            audioCON.Instance.playAudio(audioCON.Instance.shengji);
            level++;
            leveljia = 0;
            shengji.SetActive(true);
            shengjitext.text = level.ToString();
            shengji.transform.DOScale(new Vector3(2.5f, 2.5f, 2), 2).From().OnComplete(() =>
            {
                shengji.transform.localScale = new Vector3(1,1,1);
                shengji.SetActive(false);
            });
            switch (level)
            {
                case 1: levelstrindex=0; break;
                case 3: levelstrindex=1; break;
                case 8: levelstrindex=2; break;
                case 20: levelstrindex=3; break;
                case 50: levelstrindex=4; break;
            }
        }


        if (Input.GetMouseButtonDown(0) && EventSystem.current.IsPointerOverGameObject() == false )
        {
            moneytext.transform.DOPause();
            moneytext.color = Color.yellow;
            moneytext.fontStyle = FontStyle.Normal;
            moneytext.transform.localScale = new Vector3 (1f, 1f, 1f);
            if (money >= costs[buttltindex])
            {  //����������е�Ǯ���ܷ���
                audioCON.Instance.playAudio(audioCON.Instance.dapao);
                money -= costs[buttltindex];
                    //�����ӵ�
                GameObject butt = Instantiate(buttlts[buttltindex], gunspoint[gunsindex].position, Quaternion.identity);
                butt.transform.rotation = gunspoint[gunsindex].transform.rotation;
            }else
            {//��С�����е�Ǯ��ʱ������
                if(panduan == false)
                {
                    moneytext.transform.DOScale(new Vector3(2, 2, 2), 1f).SetLoops(-1);
                    moneytext.color = Color.red;
                    moneytext.fontStyle = FontStyle.Bold;
                    panduan = true;
                }
                else
                {
                    moneytext.fontStyle = FontStyle.Bold;
                    moneytext.color = Color.red;
                    moneytext.transform.DOPlay();
                }

            }

        }
        

    }
    public void onclickjian1()
    {
        audioCON.Instance.playAudio(audioCON.Instance.qiehuanpao);
        buttltindex = (buttltindex == 0) ? buttlts.Length : buttltindex;
        buttltindex--;
        if (buttltindex == 5 || buttltindex == 3 || buttltindex == 1)
        {
            guns[gunsindex].SetActive(false);
            gunsindex--;
            gunsindex = gunsindex == -1 ? guns.Length - 1 : gunsindex;
            guns[gunsindex].SetActive(true);
        }
        costtext.text = costs[buttltindex].ToString();
        if (money >= costs[buttltindex])
        {
            moneytext.transform.DOPause();
            moneytext.color = Color.yellow;
            moneytext.fontStyle = FontStyle.Normal;
        }

    }
    public void onclickjian()
    {
        audioCON.Instance.playAudio(audioCON.Instance.qiehuanpao);
        //ÿ�ε�����ӵ������������ӵ�����ǹ����
        buttltindex++;
        if (buttltindex % 2 == 0)
        {
            guns[gunsindex].SetActive(false);
            gunsindex++;
            gunsindex = gunsindex == guns.Length ? 0 : gunsindex;
            guns[gunsindex].SetActive(true);
        }
        buttltindex = (buttltindex == buttlts.Length) ? 0 : buttltindex;
        costtext.text = costs[buttltindex].ToString();
        if (money >= costs[buttltindex])
        {
            moneytext.transform.DOPause();
            moneytext.color = Color.yellow;
            moneytext.fontStyle = FontStyle.Normal;
        }
    }
    public void jiaqian(int jiaq)
    {
        audioCON.Instance.playAudio(audioCON.Instance.money);
        money += jiaq;
        leveljia += jiaq;
    }
    public void exit()
    {
        PlayerPrefs.SetInt("level",level);
        PlayerPrefs.SetInt("money", money);
        PlayerPrefs.SetInt("jingyan", leveljia);
        cuncu cuncu = new cuncu();
        cuncu.shengying = audioCON.Instance.jingying;
        string filepath = Application.dataPath + "/cuncu.json";
        string savejsonstr = JsonMapper.ToJson(cuncu);
        StreamWriter sw = new StreamWriter(filepath);
        sw.Write(savejsonstr);
        sw.Close();
    }
}
class cuncu
{//����json�洢
    public bool shengying;
}
