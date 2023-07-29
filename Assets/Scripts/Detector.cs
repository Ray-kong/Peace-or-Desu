using Fungus;
using UnityEngine;

public class Detector : MonoBehaviour
{
    [SerializeField] private string objectTag = "Player";
    [HideInInspector] public bool isWithinCollider;

    [SerializeField] public GameObject PanelB;
    [SerializeField] public GameObject PanelL;
    [SerializeField] public GameObject Text1;
    [SerializeField] public GameObject Text2;
    [SerializeField] public GameObject Text3;
    [SerializeField] public GameObject TextAnswer1;
    [SerializeField] public GameObject TextAnswer2;
    [SerializeField] public GameObject TextAnswer3;
    [SerializeField] public GameObject Name;
    [SerializeField] public GameObject Image;
    [SerializeField] public GameObject A;
    [SerializeField] public GameObject B;
    [SerializeField] public GameObject C;
    [SerializeField] public GameObject NextButton;
    [SerializeField] public GameObject End;
    [SerializeField] public GameObject Enemy;

    public GameObject flowChartObj;

    PatrolAI patrolAI;

    public int textcount = 0;

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
            if (Input.GetKeyDown(KeyCode.K))
            {
                Debug.Log("K pressed");
            }
            else if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("E pressed");
                PanelB.SetActive(true);
                PanelL.SetActive(true);
                Text1.SetActive(true);
                Name.SetActive(true);
                Image.SetActive(true);
                A.SetActive(true);
                B.SetActive(true);
                C.SetActive(true);
                Enemy.SetActive(true);
                textcount = 1;
            }
        }
    }

    public void OK1()
    {
        A.SetActive(false);
        B.SetActive(false);
        C.SetActive(false);
        Text1.SetActive(false);
        TextAnswer1.SetActive(true);
        NextButton.SetActive(true);
    }
    public void OK2()
    {
        A.SetActive(false);
        B.SetActive(false);
        C.SetActive(false);
        Text2.SetActive(false);
        TextAnswer2.SetActive(true);
        NextButton.SetActive(true);
    }
    public void OK3()
    {
        A.SetActive(false);
        B.SetActive(false);
        C.SetActive(false);
        Text3.SetActive(false);
        TextAnswer3.SetActive(true);
        End.SetActive(true);
    }
    //äOÇµÇΩèÍçá
    public void NO1()
    {
        A.SetActive(false);
        B.SetActive(false);
        C.SetActive(false);
        Text1.SetActive(false);
        TextAnswer1.SetActive(true);
        End.SetActive(true);
    }
    //ñ‚ëËâÊñ Ç™è¡Ç¶ÇÈ
    public void EndButton()
    {

    }

}