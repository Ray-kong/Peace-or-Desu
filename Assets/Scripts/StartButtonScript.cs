using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Threading.Tasks;//�ǉ�


public class StartButtonScripts: MonoBehaviour
{
    //�@�X�^�[�g�{�^��������������s����
    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }
}