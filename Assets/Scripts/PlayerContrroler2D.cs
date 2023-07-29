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
        // �ړ��̐���Ȃǂ̏������L�q
    }

    private void LoadPlayerPosition()
    {
        // �ۑ������ʒu�Ƀv���C���[���ړ�
        Vector3 savedPosition = PlayerPositionSaver.Instance.GetSavedPlayerPosition();
        rb.position = savedPosition;
    }
}
