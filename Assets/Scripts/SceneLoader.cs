using UnityEngine;

public class SceneLoader : MonoBehaviour
{
    public void LoadNewScene(string sceneName)
    {
        // プレイヤーの位置を保存
        Vector3 playerPosition = PlayerPositionSaver.Instance.GetSavedPlayerPosition();
        PlayerPositionSaver.Instance.SavePlayerPosition(playerPosition);

        // 新しいシーンをロード
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }
}