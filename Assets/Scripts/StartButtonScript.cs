using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Threading.Tasks;//�ǉ�


public class StartButtonScripts : MonoBehaviour
{
    //�@�X�^�[�g�{�^��������������s����

    public Fade fades;

    public void StartGame()
    {
        Invoke("DelayedAction", 1f);
        fades.FadeIn(0.5f, () => print("�t�F�[�h�C������"));
    }
    private void DelayedAction()
    {
        SceneManager.LoadScene("Level 1");
        
    }
}
