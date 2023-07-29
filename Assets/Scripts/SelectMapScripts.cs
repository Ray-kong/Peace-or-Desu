using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectMapScripts : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SelectMapA()
    {
        SceneManager.LoadScene("DestinationName");//シーンチェンジ
    }

    private void SelectMapB()
    {
        SceneManager.LoadScene("DestinationName");//シーンチェンジ
    }

    private void SelectMapC()
    {
        SceneManager.LoadScene("DestinationName");//シーンチェンジ
    }
}
