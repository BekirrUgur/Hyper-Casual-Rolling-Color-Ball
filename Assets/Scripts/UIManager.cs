using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class UIManager : MonoBehaviour
{
    public SoundManager soundManager;

    public Image whiteEffectImage;
    private int effectControl = 0;

    public Image fillRateImage;
    public GameObject player;
    public GameObject finishLine;

    public Animator layoutAnimator;

    public TextMeshProUGUI coinText;
    public bool radial_shine = false;

    #region Button variables
    public GameObject layoutBackground;
    public GameObject settingsOpen;
    public GameObject settingsClosed;
    public GameObject soundOn;
    public GameObject soundOff;
    public GameObject vibrationOn;
    public GameObject vibrationOff;
    public GameObject iap;
    public GameObject information;

    public GameObject introHand;
    public GameObject touchtomoveText;
    public GameObject noAds;
    public GameObject shopButton;

    public GameObject restartScene;
    #endregion

    #region End game screen variables
    public GameObject finishScreen;
    public GameObject blackBackground;
    public GameObject complete;
    public GameObject radialShine;
    public GameObject coin;
    public GameObject rewardedButton;
    public GameObject noThanks;

    public GameObject achievedCoin;
    public GameObject nextLevel;
    public TextMeshProUGUI achievedCoinText;

    #endregion

    public void Start()
    {
        #region Settings pre - assignment
        if (PlayerPrefs.HasKey("Sound") == false) 
        {
            PlayerPrefs.SetInt("Sound", 1);
        }

        if (PlayerPrefs.HasKey("Vibration") == false)
        {
            PlayerPrefs.SetInt("Vibration", 1);
        }

      
        if (PlayerPrefs.GetInt("Noads") == 1) 
        {
            RemoveNoAds();
        }

        if (PlayerPrefs.GetInt("Sound") == 1)
        {
            soundOn.SetActive(true);
            soundOff.SetActive(false);
            
        }
        else if (PlayerPrefs.GetInt("Sound") == 0)
        {
            soundOff.SetActive(true);
            soundOn.SetActive(false);
           
        }

        if (PlayerPrefs.GetInt("Vibration") == 1)
        {
            vibrationOn.SetActive(true);
            vibrationOff.SetActive(false);

        }
        else if (PlayerPrefs.GetInt("Vibration") == 0)
        {
            vibrationOff.SetActive(true);
            vibrationOn.SetActive(false);

        }
        #endregion

        CoinTextUpdate();

    }
    public void Update()
    {
        if(radial_shine == true) 
        {
            radialShine.GetComponent<RectTransform>().Rotate(new Vector3(0,0,Time.deltaTime * 10));
        }

        fillRateImage.fillAmount = ((player.transform.position.z) / (finishLine.transform.position.z));
        
    }

    public void RestartButton() 
    {
        Variables.firstTouch = 0;
        Time.timeScale = 1;
        restartScene.SetActive(true);
    }

    public void RestartScene() 
    {
        Variables.firstTouch = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextScene() 
    {
        Variables.firstTouch = 0;
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }
    public void FirstTouchAndDisappear() 
    {
        introHand.SetActive(false);
        touchtomoveText.SetActive(false);
        shopButton.SetActive(false);
        noAds.SetActive(false);
        settingsOpen.SetActive(false);
        settingsClosed.SetActive(false);
        soundOn.SetActive(false);
        soundOff.SetActive(false);
        vibrationOn.SetActive(false);
        vibrationOff.SetActive(false);
        iap.SetActive(false);
        information.SetActive(false);
        layoutBackground.SetActive(false);
    }

    public void RemoveNoAds() 
    {
        noAds.SetActive(false);
    }

    public void CoinTextUpdate() 
    {
        coinText.text = PlayerPrefs.GetInt("Money").ToString();
    }

    public void FinishScreen() 
    {
        StartCoroutine("FinishLaunch");
    }

   
    #region Settings
    public void PrivacyPolicy()
    {
        Application.OpenURL("https://policies.google.com/privacy?hl=en");
    }
    public void TermsOfUse()
    {
        Application.OpenURL("https://policies.google.com/terms?hl=en");
    }
    public void LayoutSettingsOpen()
    {
        layoutAnimator.SetTrigger("Slide_in");
        settingsOpen.SetActive(false);
        settingsClosed.SetActive(true);
    }

    public void LayoutSettingsClosed()
    {
        layoutAnimator.SetTrigger("Slide_out");
        settingsClosed.SetActive(false);
        settingsOpen.SetActive(true);
    }

    public void SoundOn()
    {
        soundOff.SetActive(true);
        soundOn.SetActive(false);
        AudioListener.volume = 0;
        PlayerPrefs.SetInt("Sound", 0);
    }
    public void SoundOff()
    {
        soundOn.SetActive(true);
        soundOff.SetActive(false);
        AudioListener.volume = 1;
        PlayerPrefs.SetInt("Sound", 1);
    }

    public void VibrationOn()
    {
        vibrationOff.SetActive(true);
        vibrationOn.SetActive(false);
        PlayerPrefs.SetInt("Vibration", 0);
    }
    public void VibrationOff()
    {
        vibrationOn.SetActive(true);
        vibrationOff.SetActive(false);
        PlayerPrefs.SetInt("Vibration", 1);
    }
    #endregion

    #region UI Effects

    public IEnumerator FinishLaunch()
    {
        radial_shine = true;
        finishScreen.SetActive(true);
        blackBackground.SetActive(true);
        yield return new WaitForSecondsRealtime(1.0f);
        complete.SetActive(true);
        soundManager.CompleteClickSound();
        yield return new WaitForSecondsRealtime(1.0f);
        soundManager.CompleteClickSound();
        radialShine.SetActive(true);
        coin.SetActive(true);
        yield return new WaitForSecondsRealtime(1.0f);
        rewardedButton.SetActive(true);
        soundManager.CompleteClickSound();
        yield return new WaitForSecondsRealtime(3f);
        noThanks.SetActive(true);

    }

    public IEnumerator AfterRewardButton()
    {
        achievedCoin.SetActive(true);
        achievedCoinText.gameObject.SetActive(true);
        rewardedButton.SetActive(false);
        noThanks.SetActive(false);
        for (int i = 0; i <= 400; i += 5)
        {
            achievedCoinText.text = "+" + i.ToString();
            yield return new WaitForSecondsRealtime(0.02f);
        }
        yield return new WaitForSecondsRealtime(1.0f);
        nextLevel.SetActive(true);

        


    }
    
    public IEnumerator WhiteEffect() 
    {
        whiteEffectImage.gameObject.SetActive(true);
        while(effectControl == 0)
        {
            yield return new WaitForSeconds(0.001f);
            whiteEffectImage.color += new Color(0, 0, 0, 0.1f);
            if(whiteEffectImage.color == new Color(whiteEffectImage.color.r, whiteEffectImage.color.b, 1)) 
            {
                effectControl = 1;
            }
        }

        while (effectControl == 1)
        {
            yield return new WaitForSeconds(0.001f);
            whiteEffectImage.color -= new Color(0, 0, 0, 0.1f);
            if (whiteEffectImage.color == new Color(whiteEffectImage.color.r, whiteEffectImage.color.b, 0))
            {
                effectControl = -1;
            }
        }

        if (effectControl == -1) 
        {
            Debug.Log("Efekt Bitti");
        }


    }
    #endregion
}
