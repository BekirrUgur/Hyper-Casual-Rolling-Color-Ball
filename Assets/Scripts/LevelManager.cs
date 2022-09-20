using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public TextMeshProUGUI LoadingText;

    public void Start()
    {
        if(PlayerPrefs.HasKey("LevelIndex") == false) 
        {
            PlayerPrefs.SetInt("LevelIndex", 1);
        }
        StartCoroutine("loadingBar");
        LevelControl();
    }
    public void LevelControl() 
    {
        int level = PlayerPrefs.GetInt("LevelIndex"); 
        SceneManager.LoadSceneAsync(level);
    }
    public IEnumerator loadingBar()
    {
        while (true)
        {
            LoadingText.text ="LOADING".ToString();
            yield return new WaitForSecondsRealtime(0.5f);
            LoadingText.text = "LOADING.".ToString();
            yield return new WaitForSecondsRealtime(0.5f);
            LoadingText.text = "LOADING..".ToString();
            yield return new WaitForSecondsRealtime(0.5f);
            LoadingText.text = "LOADING...".ToString();
        }
    } 
}

