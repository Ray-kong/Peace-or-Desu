using UnityEngine;

public class PlayerPositionSaver : MonoBehaviour
{
    public static PlayerPositionSaver Instance { get; private set; }
    private Vector3 playerStartPosition;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SavePlayerPosition(Vector3 position)
    {
        // プレイヤーの位置を保存
        playerStartPosition = position;
    }

    public Vector3 GetSavedPlayerPosition()
    {
        // 保存したプレイヤーの位置を取得
        return playerStartPosition;
    }
}
