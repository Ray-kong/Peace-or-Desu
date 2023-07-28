using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Threading.Tasks;//追加


public class StartButtonScripts: MonoBehaviour
{
    //　スタートボタンを押したら実行する
    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }
}