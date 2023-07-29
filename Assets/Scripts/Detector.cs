using UnityEngine;

public class Detector : MonoBehaviour
{
    [SerializeField] private string objectTag = "Player";
    [HideInInspector] public bool isWithinCollider;

    public GameObject flowChartObj;

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(objectTag))
        {
            //Debug.Log("Object with tag " + objectTag + " is within the box collider.");
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
                flowChartObj.SetActive(true);
            }
        }
    }
}