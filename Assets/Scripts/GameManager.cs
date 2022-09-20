using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public UIManager uiManager;
    public AdManager adManager;
    private void Start()
    {
        CoinCalculator(0);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player") && gameObject.CompareTag("FinishLine")) 
        {
            Debug.Log("Oyun Bitti");
            int _levelIndex = PlayerPrefs.GetInt("LevelIndex");
            PlayerPrefs.SetInt("LevelIndex", _levelIndex + 1);

            if (PlayerPrefs.GetInt("Noads") == 0) 
            {
                adManager.RequestInterstitial();
            }

            adManager.RequstRewarded();
            CoinCalculator(100);
            Debug.Log(PlayerPrefs.GetInt("Money"));
            uiManager.CoinTextUpdate();
            uiManager.FinishScreen();
            
        }
    }
    public void CoinCalculator(int money) 
    {
        if (PlayerPrefs.HasKey("Money")) 
        {
            int saveMoney = PlayerPrefs.GetInt("Money");
            PlayerPrefs.SetInt("Money", saveMoney+money);
            
        }
        else 
        {
            PlayerPrefs.SetInt("Money", 0);
        }
        
    }
}
