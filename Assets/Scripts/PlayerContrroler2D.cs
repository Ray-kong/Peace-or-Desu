using UnityEngine;

public class PlayerControler2D : MonoBehaviour
{
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        LoadPlayerPosition();
    }

    private void Update()
    {
        // 移動の制御などの処理を記述
    }

    private void LoadPlayerPosition()
    {
        // 保存した位置にプレイヤーを移動
        Vector3 savedPosition = PlayerPositionSaver.Instance.GetSavedPlayerPosition();
        rb.position = savedPosition;
    }
}
