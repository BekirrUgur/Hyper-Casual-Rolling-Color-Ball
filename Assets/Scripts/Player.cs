using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    public CameraShake cameraShake;
    public UIManager uiManager;
    public SoundManager soundManager;

    public GameObject mainCamera;
    public GameObject vectorBack;
    public GameObject vectorForward;

    private Touch touch;
    private Rigidbody rb;

    [Range(20, 40)]
    public int speedModifier;
    public int forwardSpeed;

    private bool speedBallForward = false;
    private bool firstTouchControl = false;

    private int soundLimitCount;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {


        if(Variables.firstTouch == 1 && speedBallForward == false)
        {

            transform.position += new Vector3(0, 0, forwardSpeed * Time.deltaTime);
            vectorBack.transform.position += new Vector3(0, 0, forwardSpeed * Time.deltaTime);
            vectorForward.transform.position += new Vector3(0, 0, forwardSpeed * Time.deltaTime);

        }

        if (Input.touchCount > 0) 
        {
            touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:

                    if (!EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId)) 
                    {
                        if(firstTouchControl == false) 
                        {
                            Variables.firstTouch = 1;
                            uiManager.FirstTouchAndDisappear();
                            firstTouchControl = true;
                        }

                    }

                    
                    break;

                case TouchPhase.Moved:
              
                    if (!EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
                    {
                        rb.velocity = new Vector3(touch.deltaPosition.x * speedModifier * Time.deltaTime,
                                             transform.position.y,
                                             touch.deltaPosition.y * speedModifier * Time.deltaTime);
                        if (firstTouchControl == false)
                        {
                            Variables.firstTouch = 1;
                            uiManager.FirstTouchAndDisappear();
                            firstTouchControl = true;
                        }

                    }
                    break;
                case TouchPhase.Ended:
                    rb.velocity = Vector3.zero;
                    break;


            }

        }
        
    }

    public GameObject[] fractureItems;
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle")) 
        {
            
            cameraShake.CameraShakesCall();
            uiManager.StartCoroutine("WhiteEffect");
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
            soundManager.BlowUpClickSound();
            if (PlayerPrefs.GetInt("Vibration") == 1) 
            {
                Vibration.Vibrate(100);
            }
            else if (PlayerPrefs.GetInt("Vibration") == 0) 
            {
                Debug.Log("Vibration off");
             
            }
            Vibration.Vibrate(50);
          foreach(GameObject item in fractureItems) 
            {
                item.GetComponent<Rigidbody>().isKinematic = false;
                item.GetComponent<SphereCollider>().enabled = true;
            }
            StartCoroutine(TimeScaleControl());
        }
        if (collision.gameObject.CompareTag("Untagged")) 
        {
           
            soundLimitCount++;
        }
        if(collision.gameObject.CompareTag("Untagged") && soundLimitCount % 5 == 0)
        {
            soundManager.ObjectHitClickSound();
        }
    }

    public IEnumerator TimeScaleControl() 
    {
        speedBallForward = true;
        yield return new WaitForSecondsRealtime(0.4f);
        Time.timeScale = 0.4f;
        yield return new WaitForSecondsRealtime(0.6f);
        uiManager.RestartButton();
        rb.velocity = Vector3.zero;
    }
}
