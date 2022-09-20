using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyedObject : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Untagged" || collision.gameObject.tag == "Obstacle") 
        {
            collision.gameObject.SetActive(false);
        }
    }

}
