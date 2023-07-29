using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detector : MonoBehaviour
{
    // Define the tag of the object you want to detect
    [SerializeField] private string objectTag = "NPC";
    [HideInInspector] public bool isWithinCollider;
    

    // void OnTriggerEnter2D(Collider2D other)
    // {
    //     if (other.gameObject.CompareTag(objectTag))
    //     {
    //         Debug.Log("Object with tag " + objectTag + " entered the box collider.");
    //     }
    // }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(objectTag))
        {
            isWithinCollider = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(objectTag))
        {
            isWithinCollider = false;
        }
    }
    
    void Update()
    {
        if (isWithinCollider)
        {
            if(Input.GetKeyDown(KeyCode.K))
            {
                Debug.Log("K pressed");
            }
            else if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("E pressed");
            }
        }
    }


}