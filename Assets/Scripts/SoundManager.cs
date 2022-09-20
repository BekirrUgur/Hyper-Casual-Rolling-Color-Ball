using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource buttonClickSource;
    public AudioSource blowUpClickSource;
    public AudioSource cashClickSource;
    public AudioSource completeClickSource;
    public AudioSource objectHitClickSource;

    public AudioClip buttonClip;
    public AudioClip blowUpClip;
    public AudioClip cashClip;
    public AudioClip completeClip;
    public AudioClip objectHitClip;

    public void ButtonClickSound()
    {
        buttonClickSource.PlayOneShot(buttonClip);
    }
    public void BlowUpClickSound()
    {
        blowUpClickSource.PlayOneShot(blowUpClip, .3f);
    }
    public void CashClickSound()
    {
        cashClickSource.PlayOneShot(cashClip);
    }
    public void CompleteClickSound()
    {
        completeClickSource.PlayOneShot(completeClip);
    }
    public void ObjectHitClickSound()
    {
        objectHitClickSource.PlayOneShot(objectHitClip);
    }
}
