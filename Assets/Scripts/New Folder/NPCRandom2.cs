using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCRandom2 : MonoBehaviour
{
    public float moveSpeed = 3f; // NPC�̈ړ����x
    public float changeDirectionInterval = 3f; // ������ς���Ԋu

    private float timeSinceLastDirectionChange = 0f; // �O��̕����ύX����̌o�ߎ���
    private Vector2 currentDirection; // ���݂̈ړ�����

    private void Start()
    {
        // ����̕����������_���Ɍ���
        ChangeDirection();
    }

    private void Update()
    {
        timeSinceLastDirectionChange += Time.deltaTime;

        // ������ς���Ԋu�𒴂�����V���������������_���Ɍ���
        if (timeSinceLastDirectionChange >= changeDirectionInterval)
        {
            ChangeDirection();
        }

        // �ړ�
        Move();
    }

    public void ChangeDirection()
    {
        // �����_���ȕ���������i-1.0 ���� 1.0 �̊Ԃ̃����_���� x �� y �̒l�����x�N�g���j
        currentDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;

        // �����ύX�̃^�C�}�[���Z�b�g
        timeSinceLastDirectionChange = 0f;

        // NPC�̌������ړ������ɍ��킹��
        transform.up = currentDirection;
    }

    private void Move()
    {
        // �ړ�
        transform.position += (Vector3)(currentDirection * moveSpeed * Time.deltaTime);
    }
}
