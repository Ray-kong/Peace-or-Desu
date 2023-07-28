using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Threading.Tasks;//追加


public class StartButtonScripts : MonoBehaviour
{
    //　スタートボタンを押したら実行する

    public Fade fades;

    public void StartGame()
    {
        Invoke("DelayedAction", 1f);
        fades.FadeIn(0.5f, () => print("フェードイン完了"));
    }
    private void DelayedAction()
    {
        SceneManager.LoadScene("Game");
        
    }
}
