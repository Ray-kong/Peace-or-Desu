using Fungus;
using UnityEngine;

public class Detector : MonoBehaviour
{
    [SerializeField] private string objectTag = "Player";
    [HideInInspector] public bool isWithinCollider;

    [SerializeField] public GameObject PanelB;
    [SerializeField] public GameObject PanelL;
    [SerializeField] public GameObject Text;
    [SerializeField] public GameObject Name;
    [SerializeField] public GameObject Image;
    [SerializeField] public GameObject A;
    [SerializeField] public GameObject B;
    [SerializeField] public GameObject C;
    [SerializeField] public GameObject Enemy;

    public GameObject flowChartObj;

    PatrolAI patrolAI;

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
                PanelB.SetActive(true);
                PanelL.SetActive(true);
                Text.SetActive(true);
                Name.SetActive(true);
                Image.SetActive(true);
                A.SetActive(true);
                B.SetActive(true);
                C.SetActive(true);
                Enemy.SetActive(true);
            }
        }
    }
}