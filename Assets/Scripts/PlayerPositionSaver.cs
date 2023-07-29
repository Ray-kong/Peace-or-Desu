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
        // �v���C���[�̈ʒu��ۑ�
        playerStartPosition = position;
    }

    public Vector3 GetSavedPlayerPosition()
    {
        // �ۑ������v���C���[�̈ʒu���擾
        return playerStartPosition;
    }
}
