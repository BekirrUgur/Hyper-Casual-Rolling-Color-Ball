using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Shop : MonoBehaviour
{
    public UIManager uiManager;

    public GameObject particle1;
    public GameObject particle2;
    public GameObject particle3;
    public GameObject particle4;

    public Sprite YellowImage;
    public Sprite GreenImage;

    public GameObject item1;
    public GameObject item2;
    public GameObject item3;

    public GameObject lock1;
    public GameObject lock2;
    public GameObject lock3;


    private void Awake()
    {
        if (PlayerPrefs.HasKey("itemSelect") == false) 
            PlayerPrefs.SetInt("itemSelect",0);

        //--------------Item Select--------------

        if (PlayerPrefs.GetInt("itemSelect") == 0) 
        {
            particle1.SetActive(true);
            particle2.SetActive(false);
            particle3.SetActive(false);
            particle4.SetActive(false);
        }else if (PlayerPrefs.GetInt("itemSelect") == 1) 
        {
            Item1Open();
        }
        else if (PlayerPrefs.GetInt("itemSelect") == 2)
        {
            Item2Open();
        }
        else if (PlayerPrefs.GetInt("itemSelect") == 3)
        {
            Item3Open();
        }


    }
    public void Start()
    {

        //---------LOCKS----------
        if (PlayerPrefs.HasKey("lock1Control") == false) 
            PlayerPrefs.SetInt("lock1Control", 0);

        if (PlayerPrefs.HasKey("lock2Control") == false)
            PlayerPrefs.SetInt("lock2Control", 0);
        
        if (PlayerPrefs.HasKey("lock3Control") == false)
            PlayerPrefs.SetInt("lock3Control", 0);

        if (PlayerPrefs.GetInt("lock1Control") == 1)
            lock1.SetActive(false);

        if (PlayerPrefs.GetInt("lock2Control") == 1)
            lock2.SetActive(false);

        if (PlayerPrefs.GetInt("lock3Control") == 1)
            lock3.SetActive(false);





    }
    public void Item1Open()
    {
        particle1.SetActive(false);
        particle2.SetActive(true);
        particle3.SetActive(false);
        particle4.SetActive(false);

        item1.GetComponent<Image>().sprite = GreenImage;
        item2.GetComponent<Image>().sprite = YellowImage;
        item3.GetComponent<Image>().sprite = YellowImage;

        PlayerPrefs.SetInt("itemSelect",1);
    }
    public void Item2Open()
    {
        particle1.SetActive(false);
        particle2.SetActive(false);
        particle3.SetActive(true);
        particle4.SetActive(false);

        item1.GetComponent<Image>().sprite = YellowImage;
        item2.GetComponent<Image>().sprite = GreenImage;
        item3.GetComponent<Image>().sprite = YellowImage;

        PlayerPrefs.SetInt("itemSelect", 2);
    }
    public void Item3Open()
    {
        particle1.SetActive(false);
        particle2.SetActive(false);
        particle3.SetActive(false);
        particle4.SetActive(true);

        item1.GetComponent<Image>().sprite = YellowImage;
        item2.GetComponent<Image>().sprite = YellowImage;
        item3.GetComponent<Image>().sprite = GreenImage;

        PlayerPrefs.SetInt("itemSelect", 3);

    }

    //------------------------------------LOCKS------------------------------------

    public void Lock1Open() 
    {
        int money = PlayerPrefs.GetInt("Money");
        int _lock1Control = PlayerPrefs.GetInt("lock1Control");
        if (money >= 2000 && _lock1Control == 0) 
        {
            lock1.SetActive(false);
            money = money - 2000;
            PlayerPrefs.SetInt("Money", money);
            Item1Open();
            uiManager.CoinTextUpdate();
            PlayerPrefs.SetInt("lock1Control",1);
            

        }
    }

    public void Lock2Open()
    {
        int money = PlayerPrefs.GetInt("Money");
        int _lock2Control = PlayerPrefs.GetInt("lock2Control");
        if (money >= 5000 && _lock2Control == 0)
        {
            lock2.SetActive(false);
            money = money - 5000;
            PlayerPrefs.SetInt("Money", money);
            Item2Open();
            uiManager.CoinTextUpdate();
            PlayerPrefs.SetInt("lock2Control", 1);


        }
    }

    public void Lock3Open()
    {
        int money = PlayerPrefs.GetInt("Money");
        int _lock3Control = PlayerPrefs.GetInt("lock3Control");
        if (money >= 10000 && _lock3Control == 0)
        {
            lock3.SetActive(false);
            money = money - 10000;
            PlayerPrefs.SetInt("Money", money);
            Item3Open();
            uiManager.CoinTextUpdate();
            PlayerPrefs.SetInt("lock3Control", 1);


        }
    }
}
