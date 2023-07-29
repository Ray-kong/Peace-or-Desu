using UnityEngine;

public class SceneLoader : MonoBehaviour
{
    public void LoadNewScene(string sceneName)
    {
        // �v���C���[�̈ʒu��ۑ�
        Vector3 playerPosition = PlayerPositionSaver.Instance.GetSavedPlayerPosition();
        PlayerPositionSaver.Instance.SavePlayerPosition(playerPosition);

        // �V�����V�[�������[�h
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }
}