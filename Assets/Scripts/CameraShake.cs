using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    private bool shakeControl = false;
    public IEnumerator CameraShakes(float duration, float magnitude) 
    {
        Vector3 originalPos = transform.localPosition;

        float elapsed = 0.0f;

        while (elapsed < duration) 
        {
            float x = Random.Range(-1.0f, 1.0f) * magnitude;
            float y = Random.Range(-1.0f, 1.0f) * magnitude;

            transform.localPosition = new Vector3(x, y, originalPos.z);

            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.localPosition = originalPos;
        
    }

    public void CameraShakesCall() 
    {
        if (shakeControl == false) 
        {
            StartCoroutine(CameraShakes(0.22f, 0.4f));
            shakeControl = true;
        }
        
    }
}
