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
    [SerializeField] public GameObject A1;
    [SerializeField] public GameObject A2;
    [SerializeField] public GameObject A3;
    [SerializeField] public GameObject B1;
    [SerializeField] public GameObject B2;
    [SerializeField] public GameObject B3;
    [SerializeField] public GameObject C1;
    [SerializeField] public GameObject C2;
    [SerializeField] public GameObject C3;
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
                A1.SetActive(true);
                B1.SetActive(true);
                C1.SetActive(true);
                Enemy.SetActive(true);
                textcount = 1;
            }
        }
    }

    public void OK1()
    {
        A1.SetActive(false);
        B1.SetActive(false);
        C1.SetActive(false);
        Text1.SetActive(false);
        TextAnswer1.SetActive(true);
        NextButton.SetActive(true);
    }
    public void OK2()
    {
        A2.SetActive(false);
        B2.SetActive(false);
        C2.SetActive(false);
        Text2.SetActive(false);
        TextAnswer2.SetActive(true);
        NextButton.SetActive(true);
    }
    public void OK3()
    {
        A3.SetActive(false);
        B3.SetActive(false);
        C3.SetActive(false);
        Text3.SetActive(false);
        TextAnswer3.SetActive(true);
        End.SetActive(true);
    }
    //äOÇµÇΩèÍçá
    public void NO1()
    {
        A1.SetActive(false);
        B1.SetActive(false);
        C1.SetActive(false);
        Text1.SetActive(false);
        TextAnswer1.SetActive(true);
        End.SetActive(true);
    }
    public void NO2()
    {
        A2.SetActive(false);
        B2.SetActive(false);
        C2.SetActive(false);
        Text2.SetActive(false);
        TextAnswer2.SetActive(true);
        End.SetActive(true);
    }
    public void NO3()
    {
        A3.SetActive(false);
        B3.SetActive(false);
        C3.SetActive(false);
        Text3.SetActive(false);
        TextAnswer3.SetActive(true);
        End.SetActive(true);
    }
    //ñ‚ëËâÊñ Ç™è¡Ç¶ÇÈ
    public void EndButton()
    {
        PanelB.SetActive(false);
         PanelL.SetActive(false);
        Text1.SetActive(false);
        Text2.SetActive(false);
        Text3.SetActive(false);
        TextAnswer1.SetActive(false);
         TextAnswer2.SetActive(false);
        TextAnswer3.SetActive(false);
        Name.SetActive(false);
        Image.SetActive(false);
        A1.SetActive(false);
        B1.SetActive(false);
        C1.SetActive(false);
        A2.SetActive(false);
        B2.SetActive(false);
        C2.SetActive(false);
        A3.SetActive(false);
        B3.SetActive(false);
        C3.SetActive(false);
        NextButton.SetActive(false);
        End.SetActive(false);
        Enemy.SetActive(false);
    }

    public void NextButton12()

    {
        A2.SetActive(true);
        B2.SetActive(true);
        C2.SetActive(true);
        TextAnswer1.SetActive(false);
        Text2.SetActive(true);
        NextButton.SetActive(false);
    }

    public void NextButton23()

    {
        A3.SetActive(true);
        B3.SetActive(true);
        C3.SetActive(true);
        TextAnswer2.SetActive(false);
        Text3.SetActive(true);
        NextButton.SetActive(false);
    }


}